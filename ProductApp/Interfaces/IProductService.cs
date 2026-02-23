using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Interfaces
{
    public interface IProductService
    {
        //Ürünlerle ilgili bütün işleri yapan katman
        // sevice = backend logic
        Product Add(Product product);
        List<Product> GetAll();
        Product GetById(int id);
        Product Update(Product product);
        void Delete(int id);

        // LINQ Methodları burada başlıyor
        List<Product> GetActiveProducts();
        List<Product> GetActiveInStockProducts();
        List<Product> GetTopExpensiveProducts(int count);
    }
}
