using AppNetcoreK8s.Models;
using AppNetcoreK8s.Repository.interfaces;

namespace AppNetcoreK8s.Repository.implementation;

public class ProductRepository : IProductRepository
{
    private readonly ApiContext _dbcontext;
    private readonly IHttpContextAccessor _contextAccessor;

    public ProductRepository(ApiContext dbcontext, IHttpContextAccessor contextAccessor){
        _dbcontext = dbcontext;
        _contextAccessor = contextAccessor;
    }

    public async Task<ServiceResponse<List<Product>>> GetProductsAsync(){
        var requestedListOfProducts =await _dbcontext.Products
            .ToListAsync();
        return new ServiceResponse<List<Product>>() {
            Data = requestedListOfProducts
        };
    }
}