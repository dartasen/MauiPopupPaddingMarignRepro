using CommunityToolkit.Maui.Views;
using PopupRepro.ViewModels;

namespace PopupRepro.Views;

public sealed partial class MessagePopup : Popup<bool>
{
    public MessagePopup(MessagePopupViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnOKButtonClicked(object? sender, EventArgs e)
    {
        try
        {
            await CloseAsync(true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async void OnCancelButtonClicked(object? sender, EventArgs e)
    {
        try
        {
            await CloseAsync(false);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}