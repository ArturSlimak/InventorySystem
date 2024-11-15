using InventorySystem.Requests;
using InventorySystem.Responses;

namespace InventorySystem.Services;

public interface IProductService
{
    public Task<ProductResponse.GetIndex> GetAll(ProductRequest.GetIndex request);
}
