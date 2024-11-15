using Bogus;
using InventorySystem.Models;

namespace InventorySystem.Services.Mock;

public class ProductFaker : Faker<Product>
{
    public ProductFaker()
    {
        CustomInstantiator(f => new Product(
            f.Commerce.ProductName(),
            f.Lorem.Paragraph(5),
            f.Random.Decimal(0, 200),
            f.Image.PicsumUrl()));
        RuleFor(x => x.Id, f => f.Random.Int(1));
        UseSeed(1337);
    }
}
