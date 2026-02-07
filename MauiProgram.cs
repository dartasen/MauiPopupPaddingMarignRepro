using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Shapes;
using PopupRepro.ViewModels;
using PopupRepro.Views;

namespace PopupRepro;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();

        builder.UseMauiApp<App>()
               .UseMauiCommunityToolkit(static options =>
               {
                   options.SetPopupOptionsDefaults(new DefaultPopupOptionsSettings()
                   {
                       CanBeDismissedByTappingOutsideOfPopup = false,
                       PageOverlayColor = Color.FromRgba(0, 0, 0, 200),
                       Shape = new RoundRectangle()
                       {
                           CornerRadius = new CornerRadius(20, 20, 20, 20),
                           StrokeThickness = 0d
                       },
                       Shadow = null,
                       OnTappingOutsideOfPopup = null
                   });

                   options.SetPopupDefaults(new DefaultPopupSettings()
                   {
                       CanBeDismissedByTappingOutsideOfPopup = false,
                       BackgroundColor = Color.FromArgb("190649"),
                       HorizontalOptions = LayoutOptions.Center,
                       VerticalOptions = LayoutOptions.Center,
                       Margin = new Thickness(12), // Those properties doesn't do anything after version 14
                       Padding = new Thickness(10) // :(
                   });
               })
               .ConfigureFonts(static fonts =>
               {
                   fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                   fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
               })
               .ConfigureLogging()
               .ConfigureServices();

        return builder.Build();
    }

    private static MauiAppBuilder ConfigureLogging(this MauiAppBuilder builder)
    {
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder;
    }

    private static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
    {
        IServiceCollection services = builder.Services;

        services.AddTransient<MainPage>();
        services.AddTransient<MainPageViewModel>();

        services.AddTransient<MessagePopup>();
        services.AddTransient<MessagePopupViewModel>();

        services.AddTransientPopup<MessagePopup, MessagePopupViewModel>();

        return builder;
    }
}
