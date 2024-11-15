using InventorySystem.Services;
using InventorySystem.Services.Mock;
using InventorySystem.ViewModels;
using InventorySystem.Views;
using Microsoft.Extensions.Logging;

namespace InventorySystem
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register dependencies
            builder.Services.AddSingleton<IProductService, MockProductService>();

            //ViewModels
            builder.Services.AddTransient<ProductsOverviewViewModel>();

            // Pages
            builder.Services.AddTransient<ProductsOverviewPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
