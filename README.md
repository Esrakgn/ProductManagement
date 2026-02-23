# Product Management (Console)

A console-based mini backend simulation built with C#.
Demonstrates layered architecture (Model/Service/Interface), CRUD operations, LINQ queries, and custom exception handling.

## Features
- Category CRUD (Add/List/GetById)
- Product CRUD (Add/List/GetById/Update/Delete)
- LINQ queries:
  - Active products
  - Active & in-stock products
  - Top expensive products

## Project Structure
- Models: `Product`, `Category`
- Interfaces: `IProductService`, `ICategoryService`
- Services: `ProductService`, `CategoryService`
- Exceptions: `ValidationException`, `NotFoundException`, `BusinessException`
- Program.cs: menu-driven controller-like flow

