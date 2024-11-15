using InventorySystem.Requests;
using InventorySystem.Responses;

namespace InventorySystem.Services;

internal class ProductService : IProductService
{
    public Task<ProductResponse.GetIndex> GetAll(ProductRequest.GetIndex request)
    {
        throw new NotImplementedException();
    }
}
