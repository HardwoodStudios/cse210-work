/* References used
 * 1. https://chatgpt.com/share/6a1c558f-16fc-83e8-a6ee-a93ef12904de - Used by PTE 
 * 2. 
 * 3.
 */
namespace Develop03;

public class Scripture
{
    private Reference _jlbReference;
    private List<Word> _jlbWordsList;
    private Random _jlbRandomGenerator;

    public Scripture(string jlbBook, int jlbChapter, int jlbVerse, string jlbScriptureText)
    {
        _jlbReference = new Reference(jlbBook, jlbChapter, jlbVerse);
        _jlbWordsList = new List<Word>();
        _jlbRandomGenerator = new Random();

        CreateWordList(jlbScriptureText);
    }

    public Scripture(string jlbBook, int jlbChapter, int jlbStartVerse, int? jlbEndVerse, string jlbScriptureText)
    {
        _jlbReference = new Reference(jlbBook, jlbChapter, jlbStartVerse, jlbEndVerse);
        _jlbWordsList = new List<Word>();
        _jlbRandomGenerator = new Random();

        CreateWordList(jlbScriptureText);
    }

    private void CreateWordList(string jlbScriptureText)
    {
        string[] jlbWordsArray = jlbScriptureText.Split(" ");

        foreach (string jlbWordText in jlbWordsArray)
        {
            Word jlbNewWord = new Word(jlbWordText);
            _jlbWordsList.Add(jlbNewWord);
        }
    }

    public void HideSomeWords()
    {
        int jlbWordsToHide = 5;
        int jlbUnhiddenWordsCount = _jlbWordsList.Count - CountHiddenWords();

        if (!IsCompletelyHidden())
        {
            // If there are less visible words than the amount that 
            //  need to be hidden, only hide what needs to be hidden
            if (jlbUnhiddenWordsCount < jlbWordsToHide)
            {
                jlbWordsToHide = jlbUnhiddenWordsCount;
            }

            int jlbHiddenThisTurn = 0;

            // While there are still words to hide, randomly find a word
            //  that is not hidden and toggle hide flag, then iterate the counter
            while (jlbHiddenThisTurn < jlbWordsToHide)
            {
                int jlbRandomIndex = _jlbRandomGenerator.Next(_jlbWordsList.Count);
                Word jlbRandomWord = _jlbWordsList[jlbRandomIndex];

                // Check if the word is hidden
                if (!jlbRandomWord.GetHidden())
                {
                    jlbRandomWord.Hide();
                    jlbHiddenThisTurn++;
                }
            }
        }
    }

    public int CountHiddenWords()
    {
        int jlbHiddenCount = 0;

        foreach (Word jlbWord in _jlbWordsList)
        {
            if (jlbWord.GetHidden())
            {
                jlbHiddenCount++;
            }
        }

        return jlbHiddenCount;
    }

    public bool IsCompletelyHidden()
    {
        return CountHiddenWords() == _jlbWordsList.Count;
    }

    // Formatting advice taken from ChatGPT. See Reference 1.
    //  As well as info about how to use .Join() correctly.
    override public string ToString()
    {
        // Add the reference string with a new-line char at the end.
        string result_PTE = _jlbReference.ToString() + "\n\n";

        // For each word in the WordsList, call ToString and put a 
        // space at the end. Add it to result before returning it.
        result_PTE += string.Join(" ", _jlbWordsList);

        return result_PTE;
    }

    // Due to Requirement Changes, ShowReference() does not exist anymore
    //  This function has been replaced with the above.
    // public void DisplayScripture()
    // {
    //     _jlbReference.ShowReference();   
    //     Console.WriteLine();

    //     foreach (Word jlbWord in _jlbWordsList)
    //     {
    //         jlbWord.ShowWord();
    //         Console.Write(" ");
    //     }

    //     Console.WriteLine();
    // }
}