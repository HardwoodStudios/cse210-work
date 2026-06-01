// Patrick works on this
class Reference
{
    // Attributes
    private string _book_PTE;
    private int _chapter_PTE;
    private int? _singleVerse_PTE;  // nullable;
    private int? _startVerse_PTE;   // nullable; use with _endVerse_PTE
    private int? _endVerse_PTE;   // nullable; use with _startVerse_PTE

    // Constructors
    // DEV NOTE: Is this first one redundant? Maybe test later
    public Reference(string book, int chapter, int verse)
    {
        _book_PTE = book;
        _chapter_PTE = chapter;
        _singleVerse_PTE = verse;
        _startVerse_PTE = null;
        _endVerse_PTE = null;
    }
    public Reference(string book, int chapter, int startVerse, int? endVerse)
    {
        _book_PTE = book;
        _chapter_PTE = chapter;
        _singleVerse_PTE = null;
        _startVerse_PTE = startVerse;
        _endVerse_PTE = endVerse;
    }

    // Methods
    public string GetReference()
    {
        string formattedReference_PTE;
        // If single verse
        if(_singleVerse_PTE != null)
        {
            formattedReference_PTE = _book_PTE + " " + _chapter_PTE + ":" + _singleVerse_PTE;
        }
        // If multi- verse
        else
        {
            formattedReference_PTE = _book_PTE + " " + _chapter_PTE + ":" + _startVerse_PTE + "-" + _endVerse_PTE;
        }
        return formattedReference_PTE;
    }

    // Possibly redundant now that we're not using Console.WriteLine, 
        // which I relied on in planning for formatting & presentation
    override public string ToString()    // Formerly "public void ShowReference() {...}"
    {
        string referenceString_PTE = GetReference();
        return referenceString_PTE;
    }
}