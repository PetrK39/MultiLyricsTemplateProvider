using MultiLyricsProviderInterface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using PreferenceManagerLibrary.Preferences;
using System.Threading;
using System.Threading.Tasks;
using System.Resources;

namespace TemplateLyricsProviderPlugin
{
    public class TemplateLyricsProviderPlugin : IMultiLyricsProvider
    {
        public string Name => "Template";
        public PreferenceCollection Preferences
        {
            get
            {
                if (preferences == null)
                {
                    var locKey = $"%{Name}%";
                    var prefTab = new PreferenceCollection($"{locKey}.name", $"{locKey}.description", Name);
                    var general = new PreferenceCollection($"{locKey}.general", "", $"{Name}.general");

                    prefTab.ChildrenPreferences.Add(general);

                    preferences = prefTab;
                }
                return preferences;
            }
        }
        private PreferenceCollection preferences;

        public TemplateLyricsProviderPlugin() : base()
        {
            // initialise api here
        }

        public Task<IEnumerable<FoundTrack>> FindLyricsAsync(string album, string title, string artist, CancellationToken token)
        {
            //you can return any track properties depending on your source
            //see FoundTrack
            return Task.FromResult(Enumerable.Empty<FoundTrack>());
        }

        public string GetResource(string key, CultureInfo culture)
        {
            if (!GetAvailableLanguages().Contains(culture))
                culture = CultureInfo.CreateSpecificCulture("en-US");

            return Properties.Resources.ResourceManager.GetString(key, culture);
        }
        private static IEnumerable<CultureInfo> GetAvailableLanguages()
        {
            var result = new List<CultureInfo>();

            var rm = new ResourceManager(typeof(Properties.Resources));

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (var culture in cultures)
            {
                try
                {
                    if (culture.Equals(CultureInfo.InvariantCulture)) continue;

                    var rs = rm.GetResourceSet(culture, true, false);

                    if (rs != null) result.Add(culture);
                }
                catch (CultureNotFoundException)
                {
                    // NOP
                }
            }
            return result;
        }

    }
    public class CosturaInitialization
    {
        public CosturaInitialization()
        {
            CosturaUtility.Initialize();
        }
    }
}