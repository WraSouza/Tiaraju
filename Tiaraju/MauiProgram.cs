

using UraniumUI;

namespace Tiaraju;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .UseMauiCommunityToolkit()
            .UseSentry(options =>
            {
                // The DSN is the only required setting.
                options.Dsn = "https://f89361361eee43df9d0ab32c2b46921f@o4505269022752768.ingest.sentry.io/4505269026684928";

                // Use debug mode if you want to see what the SDK is doing.
                // Debug messages are written to stdout with Console.Writeline,
                // and are viewable in your IDE's debug console or with 'adb logcat', etc.
                // This option is not recommended when deploying your application.
                options.Debug = true;

                // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
                // We recommend adjusting this value in production.
                options.TracesSampleRate = 1.0;

                // Other Sentry options can be set here.
            })

            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});           


        builder.Services.AddSingleton<MainViewModel>();

		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddSingleton<BlankViewModel>();

		builder.Services.AddSingleton<BlankPage>();

		return builder.Build();
	}
}
