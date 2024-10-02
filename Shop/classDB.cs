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
        public List<Shop> GetShops()
        {
            return new List<Shop>(Shops);
        }
        //А нужно ли это?
        public List<Section> GetSections()
        {
            return new List<Section>(Sections);
        }
        //Тот же вопрос
        public List<Product> GetProducts()
        {
            return new List<Product>(Products);
        }

        //Добавление сущностей (Переписать то, что связанно с Id. Оно так как щас написанно работать не будет)
        public void AddShop(Shop shop)
        {
            Shop newShop = new Shop
            {
                Image = shop.Image,
                Name = shop.Name,
                Type = shop.Type,
                Id = shopId++,
            };
            this.Shops.Add(newShop);
        }

        public void AddSection(Section section)
        {
            Section newSect = new Section 
            { 
                IdShop = shopId,
                Id = sectionId++,
                Type = section.Type,
                Image = section.Image,
            };
            this.Sections.Add(newSect);
        }

        public void AddProduct(Product product)
        {
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
        public void RemoveShop(Shop shop)
        {
            Shops.Remove(shop);
            UpdateId();
        }

        public void RemoveSection(Section section)
        {
            Sections.Remove(section);
            UpdateId();
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
            UpdateId();
        }

        //Обновление Id( не нужно  )
        private void UpdateId()
        {
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
