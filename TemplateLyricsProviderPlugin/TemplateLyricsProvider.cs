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
    public class TemplateLyricsProviderPlugin : LocalisationProviderBase, IMultiLyricsProvider
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
    }
    public class CosturaInitialization
    {
        public CosturaInitialization()
        {
            CosturaUtility.Initialize();
        }
    }
}