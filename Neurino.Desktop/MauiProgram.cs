using Microsoft.Extensions.Logging;
using Neurino.Core;

namespace Neurino.Desktop
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

            builder.Services.AddSingleton<ApplicationContext>();
            builder.Services.AddMauiBlazorWebView();


            // tylko poto, żeby nie wywalał się wspólny Main.razor dla Desktop i Web
            builder.Services.AddScoped<HttpClient>(_ =>new HttpClient { BaseAddress = new Uri("http://localhost") });



#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif





            return builder.Build();
        }
    }
}
