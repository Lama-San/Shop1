using System.Diagnostics;
using System.Xml.Linq;
//using static Android.Preferences.PreferenceActivity;

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
            byte[] image = new byte[] { };//Заглушка на время
            int price = int.Parse(Price.Text);
            string name = Name.Text;
            string type = (string)Type.SelectedItem;

            var prod = new Product
            {
                Name = name,
                Price = price,
                Type = type,
                Image = image, // можно добавить изображение, если нужно
            };

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(type))
            {
                await DisplayAlert("Ошибка", "Пожалуйста, заполните поля имени и типа!", "Ок");
                return;
            }

            if ((await db.GetProducts()).Any(s => s.Name == name))
            {
                await DisplayAlert("Ошибка", "Продукт с таким названием уже существует!", "Ок");
                return;
            }

            await db.AddProduct(prod);
        }
        catch (Exception )
        {
            await DisplayAlert("Ошибка", "Не получилось создать новый продукт!", "Ок");
        }
    }
}