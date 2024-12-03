
namespace Shop;

public partial class ChoosePage : ContentPage
{
    private readonly ClassDb db;
    public ChoosePage(ClassDb db)
	{
		InitializeComponent();
        this.db = db;

    }
    private async void AddShopClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrShop(db));
    }

    private async void AddProductClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrProd(db));
    }
}