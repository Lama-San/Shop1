namespace Shop
{
    public partial class MainPage : ContentPage
    {
        private classDb db = new classDb();
        public MainPage()
        {
            InitializeComponent();
        }


        private async void DeleteShop(object sender, EventArgs e)
        {
            
        }

        private async void DeleteSection(object sender, EventArgs e)
        {
            
        }

        private async void DeleteProduct(object sender, EventArgs e)
        {
           
        }


        private async void AddProductClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChoosePage(db));
        }
    }
}

