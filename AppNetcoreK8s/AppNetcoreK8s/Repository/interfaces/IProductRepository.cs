using AppNetcoreK8s.Models;

namespace AppNetcoreK8s.Repository.interfaces;

public interface IProductRepository
{
    Task<ServiceResponse<List<Product>>> GetProductsAsync();
}