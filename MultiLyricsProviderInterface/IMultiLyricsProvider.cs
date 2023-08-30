using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using PreferenceManagerLibrary.Preferences;

namespace MultiLyricsProviderInterface
{
    public interface IMultiLyricsProvider
    {
        string Name { get; }
        Task<IEnumerable<FoundTrack>> FindLyricsAsync(string album, string title, string artist, CancellationToken token);
        string GetResource(string key, CultureInfo culture);
        PreferenceCollection Preferences { get; }
    }
}