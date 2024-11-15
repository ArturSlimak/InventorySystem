namespace InventorySystem.Requests;

public static class ProductRequest
{
    public class GetIndex
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
