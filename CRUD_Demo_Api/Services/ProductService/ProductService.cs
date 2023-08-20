using CRUD_Demo_Api.Data;
using CRUD_Demo_Api.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Demo_Api.Services.ProductService
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>
        {
            new Product
            {
                Id=1,
                Name="Milk",
                Category = "Dairy",
                Quantity = 20,
                Price = 100
            },
            new Product
            {
                Id=2,
                Name="Coca-cola",
                Category = "Drinks",
                Quantity = 200,
                Price = 300
            },
            new Product
            {
                Id=3,
                Name="Noodel",
                Category = "Snacks",
                Quantity = 60,
                Price = 20
            }
        };
        private readonly AppDbContext _db;
        public ProductService(AppDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task<List<Product>> AddProduct(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return products;
        }

        public async  Task<List<Product>> DeleteProduct(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return products;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return products = await _db.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

        public async Task<List<Product>> UpdateProduct(int id, Product request)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            product.Id = id;
            product.Name = request.Name;
            product.Category = request.Category;
            product.Quantity = request.Quantity;
            product.Price = request.Price;

            await _db.SaveChangesAsync();
            return products;
        }
    }
}
