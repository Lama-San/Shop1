using static Shop.ClassDb;

namespace Shop
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel viewModel;
        public ClassDb db;
        public MainPage(ClassDb db)
        {
            InitializeComponent();
            this.db = db;
            viewModel = new MainViewModel(db);
            BindingContext = db; // Установка контекста привязки
        }

        private async void DeleteShop(object sender, EventArgs e)
        {
            // Получите магазин, который нужно удалить
            var button = (Button)sender;
            var shop = (Shop)button.BindingContext;
            await db.RemoveShop(shop);
            viewModel._shops.Remove(shop); // Удалите магазин из коллекции в ViewModel
        }

        private async void DeleteProduct(object sender, EventArgs e)
        {
            // Получите продукт, который нужно удалить
            var button = (Button)sender;
            var product = (Product)button.BindingContext;
            await db.RemoveProduct(product);
            viewModel._products.Remove(product); // Удалите продукт из коллекции в ViewModel
        }

        private async void AddProductClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChoosePage(db));
        }
    }
}

