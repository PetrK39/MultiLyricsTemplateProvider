using System;
using System.Collections.Generic;

namespace MultiLyricsProviderInterface
{
    public class FoundTrack
    {
        public FoundTrack(Dictionary<string, string> trackProperties, string lyrics)
        {
            TrackProperties = trackProperties;
            Lyrics = lyrics;
        }

        public Dictionary<string, string> TrackProperties { get; }
        public string Lyrics { get; }
    }
}