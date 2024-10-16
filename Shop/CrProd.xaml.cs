using System.Diagnostics;
using System.Xml.Linq;

namespace Shop;

public partial class CrProd : ContentPage
{
	private readonly classDb db;
    public CrProd(classDb db)
	{
		InitializeComponent();
		this.db = db;
	}

    private async void CreateProduct(object sender, EventArgs e)
    {
        try
        {
            byte[] image = new byte[] { };//�������� �� �����
            int price = int.Parse(Price.Text);
            string name = Name.Text;
            string type = Type1.Text;//���������

            var prod = new Product
            {
                Name = name,
                Price = price,
                Type = type,
                Image = image, // ����� �������� �����������, ���� �����
            };

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(type))
            {
                await DisplayAlert("������", "����������, ��������� ��� ����!", "��");
                return;
            }

            if ((await db.GetProducts()).Any(s => s.Name == name))
            {
                await DisplayAlert("������", "������� � ����� ��������� ��� ����������!", "��");
                return;
            }

            await db.AddProduct(prod);
        }
        catch (Exception ex)
        {
            await DisplayAlert("������", "�� ���������� ������� ����� �������!", "��");
        }
    }
}