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
                //Image = image, // можно добавить изображение, если нужно
            };

            if (string.IsNullOrEmpty(name))
            {
                await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля!", "Ок");
                return;
            }

        try 
        { 

            if ((await db.GetShops()).Any(s => s.Name == name))
            {
                await DisplayAlert("Ошибка", "Магазин с таким названием уже существует!", "Ок");
                return;
            }
           
        }
        catch (Exception)
        {
            await DisplayAlert("Ошибка", "Не получилось создать новый магазин!", "Ок");
            return;
        }
        await DisplayAlert("Успех", "Магазин успешно создан!", "Ок");
        await db.AddShop(shop);
    }
}