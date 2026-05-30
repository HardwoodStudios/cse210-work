public class Entry{
    public string time;
    public string text;
    public string prompt;

    public Entry(){
        time  = "Wednesday";
        text = "";
        prompt  = randPrompt();
    }
    public Entry(string loadtime, string loadprompt, string loadtext){
        time= loadtime;
        text = loadtext;
        prompt  = loadprompt;
    }
    public string toString()
    {
        string rstring = "";
        rstring += prompt + '\n'+text;
        return rstring;
    }
    
    static public string randPrompt(){
        List<string> prompts = new List<string>()
        {
            "What is one thing you learned today?",
            "What did you see today?",
            "What was the best thing about today?",
            "What was the hardest part about today?",
            "What goals do you have",
        };
        Random rand = new Random();
        int number = rand.Next(1,prompts.Count);
        return prompts[number];
    }
    public string MakeStr()
        {
            string savestring = $"{prompt}#{text}#{time}";
            return savestring;
        } 
}