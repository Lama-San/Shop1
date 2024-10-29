using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Shop
{
    public class classDb
    {
        public List<Shop> Shops { get; set; }
        public List<Section> Sections { get; set; }
        public List<Product> Products { get; set; }
        int shopId = 0;
        int sectionId = 0;
        int productId = 0;
        public void DB()
        {
            Sections = new List<Section>();
            Shops = new List<Shop>();
        }

        //Получение сущностей
        public async Task<List<Shop>> GetShops()
        {
            await Task.Delay(100);
            return new List<Shop>(Shops);
        }
        //А нужно ли это?
        public async Task<List<Section>> GetSections()
        {
            await Task.Delay(100);
            return new List<Section>(Sections);
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
                Image = shop.Image,
                Name = shop.Name,
                Type = shop.Type,
                Id = shopId++,
            };
            this.Shops.Add(newShop);
        }

        public async Task AddSection(Section section)
        {
            await Task.Delay(100);
            Section newSect = new Section 
            { 
                IdShop = shopId,
                Id = sectionId++,
                Type = section.Type,
                Image = section.Image,
            };
            this.Sections.Add(newSect);
        }

        public async Task AddProduct(Product product)
        {
            await Task.Delay(100);
            Product newProd = new Product
            {
                Id = productId++,
                IdSection = sectionId,
                Name = product.Name,
                Type = product.Type,
                Price = product.Price,
                Image = product.Image,
            };
            this.Products.Add(newProd);
        }

        //Удаление сущностей
        public async Task RemoveShop(Shop shop)
        {
            await Task.Delay(100);
            Shops.Remove(shop);
            await UpdateId();
        }

        public async Task RemoveSection(Section section)
        {
            await Task.Delay(100);
            Sections.Remove(section);
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

            int sectionId = 0;
            foreach (var section in Sections)
            {
                section.Id = sectionId++;
            }

            int productId = 0;
            foreach (var product in Products)
            {
                product.Id = productId++;
            }
        }
    }
}
