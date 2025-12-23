using CapcoTechnicalTest.Application.Carts;
using CapcoTechnicalTest.Domain.Pricing;
using Microsoft.Extensions.Logging;

namespace CapcoTechnicalTest
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
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<IPricePolicy, PricePolicy>();
            builder.Services.AddTransient<ICartTotalCalculator, CartTotalCalculator>();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
