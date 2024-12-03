using System.Xml.Linq;

namespace Shop;

public partial class CrShop : ContentPage
{
    private readonly ClassDb db;
    public CrShop(ClassDb db)
    {
        InitializeComponent();
        this.db = db;
    }

    private async void AddShopClick(object sender, EventArgs e)
    {
        
            //byte[] image = new byte[] { };

            //string type = Type.Text;
            string name = ShopName.Text;

            var shop = new Shop
            {
                Name = name,
                //Type = type,
                //Image = image, // ����� �������� �����������, ���� �����
            };

            if (string.IsNullOrEmpty(name))
            {
                await DisplayAlert("������", "����������, ��������� ��� ����!", "��");
                return;
            }

        try 
        { 

            if ((await db.GetShops()).Any(s => s.Name == name))
            {
                await DisplayAlert("������", "������� � ����� ��������� ��� ����������!", "��");
                return;
            }
           
        }
        catch (Exception)
        {
            await DisplayAlert("������", "�� ���������� ������� ����� �������!", "��");
            return;
        }
        await DisplayAlert("�����", "������� ������� ������!", "��");
        await db.AddShop(shop);
    }
}