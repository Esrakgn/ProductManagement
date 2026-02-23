using ProductApp.Interfaces;
using ProductApp.Models;
using ProductApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductApp.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>();
        private int _idCounter = 1;

        public Product Add(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ValidationException("Product name cannot be empty.");

            if (product.Price < 0)
                throw new ValidationException("Product price cannot be negative.");

            if (product.Stock < 0)
                throw new ValidationException("Product stock cannot be negative.");

            product.Id = _idCounter++;
            _products.Add(product);
            return product;
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                throw new NotFoundException("Product not found.");

            return product;
        }

        public Product Update(Product product)
        {
            var existing = GetById(product.Id);

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ValidationException("Product name cannot be empty.");

            if (product.Price < 0)
                throw new ValidationException("Product price cannot be negative.");

            if (product.Stock < 0)
                throw new ValidationException("Product stock cannot be negative.");

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Stock = product.Stock;
            existing.IsActive = product.IsActive;
            existing.CategoryId = product.CategoryId;

            return existing;
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            _products.Remove(product);
        }

        public List<Product> GetActiveProducts()
        {
            return _products
                .Where(p => p.IsActive)
                .ToList();
        }

        public List<Product> GetActiveInStockProducts()
        {
            return _products
                .Where(p => p.IsActive && p.Stock > 0)
                .ToList();
        }

        public List<Product> GetTopExpensiveProducts(int count)
        {
            if (count <= 0)
                throw new ValidationException("Count must be greater than 0.");

            return _products
                .OrderByDescending(p => p.Price)
                .Take(count)
                .ToList();
        }
    }
}