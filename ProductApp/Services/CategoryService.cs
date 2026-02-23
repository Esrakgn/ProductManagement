using System;
using System.Collections.Generic;
using System.Text;
using ProductApp.Interfaces;
using ProductApp.Models;
using ProductApp.Exceptions;
using System.Linq;

namespace ProductApp.Services
{
    public class CategoryService : ICategoryService // interface'i implement ediyoruz ne yazıyorsa hepsini burda da yapacak 
    {
        private readonly List<Category> _categories = new List<Category>(); //fake database
        private int _idCounter = 1; // id'leri otomatik arttırmak için sayaç

        public Category Add (Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new ValidationException("Category name cannot be empty.");
            category.Id = _idCounter++;
            _categories.Add(category);
            return category;
        }

        public List<Category> GetAll() // tüm kategorileri döndüren metot
        {
            return _categories;
        }

        public Category GetById(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);  // listeyi gezer  c => c.Id bulursa verir bulamazsa null döner 
            if (category == null)
                throw new NotFoundException("Category not found.");
            return category;
        }
    }
}
