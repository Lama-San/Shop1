using System.Xml.Linq;

namespace Shop;

public partial class CrSect : ContentPage
{
    private readonly classDb db;
    public CrSect(classDb db)
    {
        InitializeComponent();
        this.db = db;
    }

    private async void CreateSection(object sender, EventArgs e)
    {
        try
        {
            byte[] image = new byte[] { };
            string name = (string)Type.SelectedItem;

            var sect = new Section
            {
                Type = name,
                Image = image, // можно добавить изображение, если нужно
            };

            if (string.IsNullOrEmpty(name))
            {
                await DisplayAlert("Ошибка", "Пожалуйста, заполните все поля!", "Ок");
                return;
            }
            if ((await db.GetSections()).Any(s => s.Type == name))
            {
                await DisplayAlert("Ошибка", "Магазин с таким названием уже существует!", "Ок");
                return;
            }

            await db.AddSection(sect);
        }
        catch (Exception )
        {
            await DisplayAlert("Ошибка", "Не получилось создать новый магазин!", "Ок");
        }
    }
}