namespace Shop;

public partial class AddPage : ContentPage
{
    private readonly classDb db;

    public AddPage(classDb db)
	{
		InitializeComponent();
        this.db = db;
    }
}