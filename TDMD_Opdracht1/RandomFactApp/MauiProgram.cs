using Microsoft.Extensions.Logging;
using RandomFactApp.Domain.Clients;
using RandomFactApp.Infrastructure.UselessFactApi;
using RandomFactApp.ViewModels;

namespace RandomFactApp
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

            builder.Services.AddHttpClient<IRandomFactClient, UselessFactApiClient>(o =>
            {
                o.BaseAddress = new Uri("https://uselessfacts.jsph.pl/api/v2/");
                o.Timeout = TimeSpan.FromSeconds(3);
            });

            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
