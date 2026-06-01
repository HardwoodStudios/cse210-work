/* References Used or Borrowed from
 * 1. https://chatgpt.com/share/6a18ac43-58f4-83e8-9a4a-4f0656ba9c95
 * 2. https://chatgpt.com/share/6a19e56f-d17c-83e8-b981-b725cb694c3c
 * 3. https://chatgpt.com/share/6a1c558f-16fc-83e8-a6ee-a93ef12904de
 */
using System.Text.Json;
public class JsonScripture_Utility
{
    private string _VolumeName_PTE;  // NOTE: Probably won't use now, but might be useful in future
    private Dictionary<string, Dictionary<string, List<string>>>? _ScriptureObject_PTE;

    // Reference Attributes to pass on
    private string _BookName_PTE;
    private int _ChapterNumber_PTE;
    private int _VerseNumber_PTE;
    private int? _EndVerseNumber_PTE;
    private string _VerseText_PTE;
    private bool _IsSingleVerse_PTE;



    public JsonScripture_Utility(string NameOfScripture, string filename){
        _VolumeName_PTE = NameOfScripture;

        if (filename.Contains(".json")) {    
            // See Reference 2.     (Use for testing -> "NT-Truncated-lds-scriptures-filtered.json")
            string json_PTE = File.ReadAllText(GetJsonPath(filename));

            _ScriptureObject_PTE =
                JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, List<string>>>>(json_PTE);
            if (_ScriptureObject_PTE == null) {
                throw new Exception("Failed to deserialize scripture data.");
            }

            // Get the Values for Reference and the Text for the Words
            GetRandScripture();

        }
        else {throw new Exception("NOT A VALID JSON FILE");}    // Idk if this will work, TEST LATER
    }

    // Import JSON from Relative directory - Taken from ChatGPT
    //      See Reference 2
    private string GetJsonPath(string JsonFileName)
    {
        string path = Path.Combine(
        // Console.WriteLine(AppContext.BaseDirectory);   // DEV NOTE: Use to find where your relative directory is and adjust accordingly
        AppContext.BaseDirectory,
        "..",
        "..",
        "..",
        "GPT_lazyimports",
        "Truncated JSONs",
        JsonFileName
        );
        return Path.GetFullPath(path);
    }

    // Pull random scripture from JSON file.
    // Part of the Constructor????
    private void GetRandScripture()
    {
        Random random_PTE = new Random();
        _IsSingleVerse_PTE = random_PTE.Next(2) == 0;  // See Reference 3.
        // _IsSingleVerse_PTE = false; // For Testing

        // Console.WriteLine($"{ ["John"]["3"][16-1]}\n");    // Test Print

        if (_ScriptureObject_PTE == null) {
            throw new Exception("Failed to deserialize scripture data.");
        }
        // Randomly select the Book
        List<string> bookNames_PTE = _ScriptureObject_PTE.Keys.ToList();
        string randomBook_PTE = bookNames_PTE[random_PTE.Next(bookNames_PTE.Count)];
        _BookName_PTE = randomBook_PTE;

        // Randomly select the Chapter in that book
        List<string> chapterList_PTE = _ScriptureObject_PTE[randomBook_PTE].Keys.ToList();
        string randomChapter_PTE = chapterList_PTE[Random.Shared.Next(chapterList_PTE.Count)];

        // Randomly Select a Verse in that chapter
        List<string> VerseList_PTE = _ScriptureObject_PTE[randomBook_PTE][randomChapter_PTE];
        int VerseIndex_PTE = Random.Shared.Next(VerseList_PTE.Count);
        // Make Sure Multi-Verses chooses a valid verse range
        while (!_IsSingleVerse_PTE && VerseIndex_PTE > (VerseList_PTE.Count - 3) )
        {
            VerseIndex_PTE = Random.Shared.Next(VerseList_PTE.Count);
        };
        string randomVerse_PTE = VerseList_PTE[VerseIndex_PTE];
        

        // "Return" the values
        _BookName_PTE = randomBook_PTE;
        int.TryParse(randomChapter_PTE, out _ChapterNumber_PTE);
        _VerseNumber_PTE = FindVerseNumber(VerseList_PTE, randomVerse_PTE);

        // Multiple Verses Return for Text Value.
        if (!_IsSingleVerse_PTE)
        {
            for (int i = 1; i <= 2; i++ ) {
                randomVerse_PTE += "\n";
                randomVerse_PTE += string.Join("\n", VerseList_PTE[VerseIndex_PTE + i]);
            }
            _EndVerseNumber_PTE = _VerseNumber_PTE + 2;
        }
        
        _VerseText_PTE = randomVerse_PTE;
    }

    private int FindVerseNumber(List<string> BookVerses_PTE, string chosenVerse_PTE)
    {
        int VerseNumber_PTE = BookVerses_PTE.IndexOf(chosenVerse_PTE) + 1;   // Actual Verse Number
        return VerseNumber_PTE;
    }

    // Getters

    public string GetBookName() { return _BookName_PTE; }
    public int GetChapterNumber() { return _ChapterNumber_PTE; }
    public int GetVerseNumber() { return _VerseNumber_PTE; }
    public int? GetEndVerseNumber() { return _EndVerseNumber_PTE; }
    public string GetVerseText() { return _VerseText_PTE; }
    public bool GetIsSingleVerse() { return _IsSingleVerse_PTE; }

    // Setters Should not be needed for this class
}