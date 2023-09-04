This solution contains Interface and template provider project for MultiLyrics project

# Known MultuLyrics providers
 - [VocaDB provider](https://github.com/PetrK39/VocaDBMultiLyricsProvider)
 
# Making your own

Clone code.
Initialise your API in the constructor.  
Implement `FindLyricsAsync` function.  
This function must return list of `FoundTrack` objects where you can define set of displayed track properties as title, lyrics language etc.  
Optionally you can implement preferences using `Preferences` property. See [Preference Manager](https://github.com/PetrK39/PreferenceManager) library.  
Locallise .resx strings. Your implementation must contain "en-US" as default localisation.  

See known providers for examples.
