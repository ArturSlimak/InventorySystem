using InventorySystem.DTOs;
using InventorySystem.Models;
using InventorySystem.Requests;
using InventorySystem.Responses;

namespace InventorySystem.Services.Mock;


public class MockProductService : IProductService
{
    private static readonly List<Product> products = new();

    static MockProductService()
    {
        var productFaker = new ProductFaker();
        products = productFaker.Generate(50);
    }

    public async Task<ProductResponse.GetIndex> GetAll(ProductRequest.GetIndex request)
    {
        await Task.Delay(100);
        ProductResponse.GetIndex response = new();
        var query = products.AsQueryable();
        response.TotalAmount = query.Count();

        query = query.Skip(request.PageSize * request.Page);
        query = query.Take(request.PageSize);
        query.OrderBy(x => x.Name);
        response.Products = query.Select(x => new ProductDTO.Index
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Price = x.Price,
            ImageUrl = x.ImageUrl,
        }).ToList();

        return response;
    }
}
