using InventorySystem.DTOs;

namespace InventorySystem.Responses;

public static class ProductResponse
{
    public class GetIndex
    {
        public List<ProductDTO.Index> Products { get; set; } = new();
        public int TotalAmount { get; set; }
    }
}
