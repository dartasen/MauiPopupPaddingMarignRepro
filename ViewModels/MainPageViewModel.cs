using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

namespace PopupRepro.ViewModels;

public sealed partial class MainPageViewModel(
    IPopupService popupService,
    ILogger<MainPageViewModel> logger
) : ObservableObject
{
    private readonly IPopupService popupService = popupService;
    private readonly ILogger<MainPageViewModel> logger = logger;

    [RelayCommand]
    public async Task ShowPopup()
    {
        Dictionary<string, object> parameters = MessagePopupViewModel.BuildParameters(
            "info",
            "I'm a title",
            "I'm a beautiful message with a lot of words for this beautiful popup, I hope my content is as beautiful as it was meant to be, otherwise I'll be sad :("
        );

        IPopupResult<bool> result = await popupService.ShowPopupAsync<MessagePopupViewModel, bool>(
            shell: Shell.Current,
            options: null,
            shellParameters: parameters
        );

        logger.LogInformation("MessagePopup returned {Result}", result);
    }
}