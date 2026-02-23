// See https://aka.ms/new-console-template for more information

using ProductApp.Models;
using ProductApp.Services;
using ProductApp.Exceptions;

var productService = new ProductService();  // Backend servislerimizi oluşturuyoruz
var categoryService = new CategoryService();

while (true)
{
    Console.WriteLine("\n==== Product Management System ====");
    Console.WriteLine("1. Add Category");
    Console.WriteLine("2. List Categories");
    Console.WriteLine("3. Add Product");
    Console.WriteLine("4. List Products");
    Console.WriteLine("5. Active Products");
    Console.WriteLine("6. Active In-Stock Products");
    Console.WriteLine("7. Top Expensive Products");
    Console.WriteLine("0. Exit");

    Console.WriteLine("Select an option: ");
    var choice = Console.ReadLine();


    try
    {
        switch (choice)
        {
            case "1":
                Console.WriteLine("category name: ");
                var categoryName = Console.ReadLine();

                var category = new Category
                {
                    Name = categoryName
                };
                categoryService.Add(category);  // kategori ekleme işlemi. Kategori eklemeyi program değil service yapıyor
                Console.WriteLine("Category added successfully.");
                break;

            case "2":
                var categories = categoryService.GetAll();
                foreach (var c in categories)
                {
                    Console.WriteLine($"ID: {c.Id}, Name: {c.Name}");
                }
                break;


            case "3":
                Console.WriteLine("product name: "); // kullanıcıdan veri alıyoruz , service'e gönderiyoruz 
                var name = Console.ReadLine();

                Console.WriteLine("product price: ");
                var price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("product stock: ");
                var stock = int.Parse(Console.ReadLine());

                Console.WriteLine("category id: ");
                var categoryId = int.Parse(Console.ReadLine());

                var product = new Product
                {
                    Name = name,
                    Price = price,
                    Stock = stock,
                    CategoryId = categoryId,
                    IsActive = true // yeni eklenen ürünler aktif olarak başlar
                };

                productService.Add(product);  //girdileri al product objesi oluştur ve service'e yolla 
                Console.WriteLine("Product added successfully.");
                break;

            case "4":
                var products = productService.GetAll();
                foreach (var p in products)
                {
                    Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Price: {p.Price}, Stock: {p.Stock}, Active: {p.IsActive}, CategoryId: {p.CategoryId}");
                }
                break;

            case "5": // aktif ürünler
                var activeProducts = productService.GetActiveProducts();

                foreach (var p in activeProducts)
                {
                    Console.WriteLine($"{p.Name} - Active");
                }
                break;

            case "6": // aktif stokta olanlar 
                var inStock = productService.GetActiveInStockProducts();
                foreach (var p in inStock)
                {
                    Console.WriteLine($"{p.Name} - Stock:{p.Stock}");
                }
                break;

            case "7": // en pahalı n ürün 
                Console.Write("How many?: ");
                var count = int.Parse(Console.ReadLine());

                var top = productService.GetTopExpensiveProducts(count);

                foreach (var p in top)
                {
                    Console.WriteLine($"{p.Name} - {p.Price}");
                }
                break;

            case "0":
                return;

        
        }

    }
    // Hata yönetimi için try-catch blokları kullanıyoruz

    catch (ValidationException ex)
    {
        Console.WriteLine($"Validation error: {ex.Message}");
    }
    catch (NotFoundException ex)
    {
        Console.WriteLine($"Not found: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Unexpected Error: {ex.Message}");
    }
}   

