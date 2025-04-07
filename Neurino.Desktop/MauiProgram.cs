using Microsoft.Extensions.Logging;

namespace Neurino.Desktop
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                System.Diagnostics.Debug.WriteLine("UNHANDLED: " + args.ExceptionObject);
            };


            TaskScheduler.UnobservedTaskException += (sender, args) =>
            {
                System.Diagnostics.Debug.WriteLine("UNOBSERVED: " + args.Exception.Message);
                args.SetObserved();
            };

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
