using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; } // ürün aktif mi sistemde 
        public int CategoryId { get; set; } // ürün hangi kategoriye ait





    }
}
