using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using InventorySystem.DTOs;
using InventorySystem.Services;
using System.Collections.ObjectModel;

namespace InventorySystem.ViewModels;

public partial class ProductsOverviewViewModel : ObservableObject
{
    private readonly IProductService productService;

    [ObservableProperty]
    ObservableCollection<ProductDTO.Index> _products;


    [ObservableProperty]
    bool _isRefreshing = false;


    [ObservableProperty]
    bool _isBusy = false;

    public ProductsOverviewViewModel(IProductService productService)
    {

        _products = new ObservableCollection<ProductDTO.Index>();

        WeakReferenceMessenger.Default.Register<RefreshMessage>(this, async (r, m) =>
        {
            await LoadData();
        });

        Task.Run(LoadData);
        this.productService = productService;

    }



    [RelayCommand]
    async Task LoadData()
    {
        if (IsBusy)
            return;

        try
        {
            IsRefreshing = true;
            IsBusy = true;

            var productsResponse = await productService.GetAll(new Requests.ProductRequest.GetIndex { });
            var productsCollection = productsResponse.Products;

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Products.Clear();

                foreach (var product in productsCollection)
                {
                    Products.Add(product);
                }
            });
        }
        finally
        {
            IsRefreshing = false;
            IsBusy = false;
        }
    }

}
