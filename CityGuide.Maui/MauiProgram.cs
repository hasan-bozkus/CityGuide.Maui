using Microsoft.Extensions.Logging;

namespace CityGuide.Maui
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

                    fonts.AddFont("HankenGrotesk-Regular.ttf", "HankenRegular");
                    fonts.AddFont("HankenGrotesk-Medium.ttf", "HankenMedium");
                    fonts.AddFont("HankenGrotesk-SemiBold.ttf", "HankenSemiBold");
                    fonts.AddFont("HankenGrotesk-Bold.ttf", "HankenBold");

                    fonts.AddFont("Inter_18pt-Regular.ttf", "Inter");

                    fonts.AddFont("material-symbols-outlined-latin-400-normal.ttf", "MaterialSymbols");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
