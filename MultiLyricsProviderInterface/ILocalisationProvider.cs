using System.Globalization;

namespace MultiLyricsProviderInterface
{
    public interface ILocalisationProvider
    {
        string GetResource(string key, CultureInfo culture);
    }
}
