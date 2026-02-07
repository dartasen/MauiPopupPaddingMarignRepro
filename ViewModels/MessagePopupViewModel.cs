using CommunityToolkit.Mvvm.ComponentModel;

namespace PopupRepro.ViewModels;

public sealed partial class MessagePopupViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    public partial string? Icon { get; set; }

    [ObservableProperty]
    public partial string? Title { get; set; }

    [ObservableProperty]
    public partial string? Message { get; set; }

    [ObservableProperty]
    public partial string DestructiveLabel { get; set; } = "Cancel";

    [ObservableProperty]
    public partial string AffirmativeLabel { get; set; } = "Ok";

    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query) => LoadParameters(query);

    public static Dictionary<string, object> BuildParameters(string icon, string title, string message)
    {
        return new Dictionary<string, object>()
        {
            { nameof(Icon), icon },
            { nameof(Title), title },
            { nameof(Message), message },
        };
    }

    public void LoadParameters(IDictionary<string, object> parameters)
    {
        Icon = (string)parameters[nameof(Icon)];
        Title = (string)parameters[nameof(Title)];
        Message = (string)parameters[nameof(Message)];
    }
}