using InventorySystem.ViewModels;

namespace InventorySystem.Views;

public partial class ProductsOverviewPage : ContentPage
{
    public ProductsOverviewPage(ProductsOverviewViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}