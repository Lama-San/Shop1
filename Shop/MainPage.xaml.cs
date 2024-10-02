namespace Shop
{
    public partial class MainPage : ContentPage
    {
        private classDb db;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void CreateShop(object sender, EventArgs e)
        {
            try
            {
                var shop = new Shop
                { /*Тут должен быть код откуда мы получаем значения для магазина*/ };
                if (shop == null)
                {
                    await DisplayAlert("Ошибка", "Магазин с такими параметрами уже существует!", "Ок");
                }
                else
                {
                    await DisplayAlert("Ошибка", "Магазин с такими параметрами уже существует!", "Ок");
                }
                /*Сюда ещё проверка на название магазина, если оно совпадает с уже существующим*/
                db.AddShop(shop);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Не получилось создать новый магазин!", "Ок");
            }
        }
        private async void CreateSection(object sender, EventArgs e)
        {
            try
            {
                var shop = new Shop
                { /*Тут должен быть код откуда мы получаем значения для магазина*/ };
                if (shop == null)
                {
                    await DisplayAlert("Ошибка", "Магазин с такими параметрами уже существует!", "Ок");
                }
                else
                {
                    await DisplayAlert("Ошибка", "Магазин с такими параметрами уже существует!", "Ок");
                }
                /*Сюда ещё проверка на название магазина, если оно совпадает с уже существующим*/
                db.AddShop(shop);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Не получилось создать новый магазин!", "Ок");
            }
        }
        private async void CreateProduct(object sender, EventArgs e)
        {
            try
            {
                var product = new Product 
                {
                };

                db.AddProduct(product);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка", "Не получилось создать новый магазин!", "Ок");
            }
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}

