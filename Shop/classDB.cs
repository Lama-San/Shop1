using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Shop
{
    public class ClassDb
    {
        //private List<Shop> Shops = new List<Shop>(); 
        //private int shopId = 1; 

        private List<Shop> Shops;
        private List<Product> Products;
        int shopId = 0;
        int productId = 0;
        public ClassDb()
        {
            Shops = new List<Shop>();
            Products = new List<Product>();
        }

        //Получение сущностей
        public async Task<List<Shop>> GetShops()
        {
            await Task.Delay(100);
            return new List<Shop>(Shops);
        }

        //Тот же вопрос
        public async Task<List<Product>> GetProducts()
        {
            await Task.Delay(100);
            return new List<Product>(Products);
        }


        //Добавление сущностей (Переписать то, что связанно с Id. Оно так как щас написанно работать не будет)
        public async Task AddShop(Shop shop)
        {

            await Task.Delay(100);

            Shop newShop = new Shop
            {
                Name = shop.Name,
                Id = shopId++
            };

            this.Shops.Add(newShop); // Добавление нового магазина в коллекцию  
        }



        public async Task AddProduct(Product product)
        {

            await Task.Delay(100);

            Product newProd = new Product
            {
                Id = productId++,
                IdShop = shopId,
                Name = product.Name,
                Type = product.Type,
                Price = product.Price,
            };

            this.Products.Add(newProd); // Добавление нового продукта в коллекцию


        }

        //Удаление сущностей
        public async Task RemoveShop(Shop shop)
        {
            await Task.Delay(100);
            Shops.Remove(shop);
            await UpdateId();
        }



        public async Task RemoveProduct(Product product)
        {
            await Task.Delay(100);
            Products.Remove(product);
            await UpdateId();
        }

        //Обновление Id( не нужно  )
        private async Task UpdateId()
        {
            await Task.Delay(100);
            int shopId = 0;
            foreach (var shop in Shops)
            {
                shop.Id = shopId++;
            }

            int productId = 0;
            foreach (var product in Products)
            {
                product.Id = productId++;
            }

        }

        public class MainViewModel : INotifyPropertyChanged
        {
            private ClassDb _db; // Хранит ссылку на экземпляр ClassDb
            public ObservableCollection<Product> _products;
            public ObservableCollection<Shop> _shops;

            public ObservableCollection<Product> Products
            {
                get => _products;
                set
                {
                    _products = value;
                    OnPropertyChanged(nameof(Products));
                }
            }

            public ObservableCollection<Shop> Shops
            {
                get => _shops;
                set
                {
                    _shops = value;
                    OnPropertyChanged(nameof(Shops));
                }
            }

            // Конструктор
            public MainViewModel(ClassDb db)
            {
                _db = db; // Сохраняем переданный экземпляр ClassDb
                Products = new ObservableCollection<Product>();
                Shops = new ObservableCollection<Shop>();
                LoadData(); // Загружаем данные после инициализации _db
            }

            // Метод для загрузки данных
            private async void LoadData()
            {
                var products = await _db.GetProducts(); // Используем _db для получения продуктов
                var shops = await _db.GetShops(); // Используем _db для получения магазинов

                // Добавляем продукты в коллекцию
                foreach (var product in products)
                {
                    Products.Add(product);
                }

                // Добавляем магазины в коллекцию
                foreach (var shop in shops)
                {
                    Shops.Add(shop);
                }
            }

            public async Task RemoveShop(Shop shop)
            {
                await _db.RemoveShop(shop); // Удаляем магазин из базы данных
                Shops.Remove(shop); // Удаляем магазин из коллекции
            }

            public async Task RemoveProduct(Product product)
            {
                await _db.RemoveProduct(product); // Удаляем продукт из базы данных
                Products.Remove(product); // Удаляем продукт из коллекции
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}




