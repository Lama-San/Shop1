using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public byte[] Image { get; set; }
        //public List<Section> Sections { get; set; }
    }

    public class Section
    {
        public int IdShop { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public byte[] Image { get; set; }
        //public List<Product> Products { get; set; }
    }

    public class Product
    {
        public int IdSection { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public byte[] Image { get; set; }
    }
}
    

