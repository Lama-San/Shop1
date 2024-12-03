using System.Diagnostics;
using System.Xml.Linq;
//using static Android.Preferences.PreferenceActivity;

namespace Shop;

public partial class CrProd : ContentPage
{
	private readonly ClassDb db;
    public CrProd(ClassDb db)
	{
        InitializeComponent(); /*DB()*/
        this.db = db;
        //this.db.ClassDB();
    }

    
    private async void CreateProduct(object sender, EventArgs e)
    {
        
            //byte[] image = new byte[] { };//�������� �� �����
            int price = int.Parse(Price.Text);
            string name = Name.Text;
            string type = (string)Type.SelectedItem;

            var prod = new Product
            {
                Name = name,
                Price = price,
                Type = type,
                //Image = image, // ����� �������� �����������, ���� �����
            };
        
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(type))
            {
                await DisplayAlert("������", "����������, ��������� ���� ����� � ����!", "��");
                return;
            }

        try
        {
            if ((await db.GetProducts()).Any(s => s.Name == name))
            {
                await DisplayAlert("������", "������� � ����� ��������� ��� ����������!", "��");
                return;
            }
        }
        catch (Exception )
        {
            await DisplayAlert("������", "�� ���������� ������� ����� �������!", "��");
        }
        await DisplayAlert("�����", "������� ������� ������!", "��");
        
        await db.AddProduct(prod); 
    }
}