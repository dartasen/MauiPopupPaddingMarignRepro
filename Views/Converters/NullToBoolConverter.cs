using System.Globalization;

namespace PopupRepro.Views.Converters;

[AcceptEmptyServiceProvider]
public sealed class NullToBoolConverter : IMarkupExtension, IValueConverter
{
    public bool Invert { get; set; }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        bool @bool = value is not null;

        if (Invert)
        {
            @bool = !@bool;
        }

        return @bool;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}