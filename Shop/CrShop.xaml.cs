using System.Xml.Linq;

namespace Shop;

public partial class CrShop : ContentPage
{
    private readonly classDb db;
    public CrShop(classDb db)
    {
        InitializeComponent();
        this.db = db;
    }

    private async void CreateShop(object sender, EventArgs e)
    {
        try
        {
            byte[] image = new byte[] { };
            string name = Name.Text;
            string type = Type.Text;

            var shop = new Shop
            {
                Name = name,
                Type = type,
                Image = image, // ����� �������� �����������, ���� �����
            };

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(type))
            {
                await DisplayAlert("������", "����������, ��������� ��� ����!", "��");
                return;
            }

            if ((await db.GetShops()).Any(s => s.Name == name))
            {
                await DisplayAlert("������", "������� � ����� ��������� ��� ����������!", "��");
                return;
            }
            await db.AddShop(shop);
        }
        catch (Exception)
        {
            await DisplayAlert("������", "�� ���������� ������� ����� �������!", "��");
        }
    }
}