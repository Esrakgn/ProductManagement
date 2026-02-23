using ProductApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductApp.Interfaces
{
    public interface ICategoryService   // nasıl yapacağımız yazmaz ne yapılacak yazar 
    {                                   // ınterface = kurallar / service = uygulama
        Category Add(Category category);
        List<Category> GetAll();
        Category GetById(int id);


    }
}
