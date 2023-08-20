using CRUD_Demo_Api.Model;

namespace CRUD_Demo_Api.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<List<Product>> AddProduct(Product product);
        Task<List<Product>> UpdateProduct(int id, Product request);
        Task<List<Product>> DeleteProduct(int id);
    }
}
