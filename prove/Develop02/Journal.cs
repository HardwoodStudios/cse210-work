using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.IO;

public class Journal{
    List<Entry> entries;
    public Journal(){
        entries = new List<Entry>();
    }
    public void Add(Entry entry){
        // Entry ne = new Entry();
        // ne.time = time;
        // ne.prompt = prompt;
        // ne.text = text;
        entries.Add(entry);
    }
    public string toString(){
        string rstring = "";
        foreach(Entry entry in entries){
            int debugCount = 0;
            string entryStr = entry.toString();
            rstring = rstring+entryStr+"\n\n";
            
            Console.WriteLine($"ENTRY COUNT: {debugCount}");
        }
        return rstring;
    }
    public void SaveFile(string filename)
    {
        foreach(Entry entry in entries)
        {
            using (StreamWriter outputFile = new StreamWriter(filename +".txt"))
            {
                outputFile.WriteLine(entry.MakeStr());
            }
            
        }
    }
    public void LoadFile(string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename +".txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split("#");
            string time = parts[0];
            string prompt = parts[1];
            string text = parts[2];
            Entry Loadtest = new Entry(time,prompt,text);
            this.Add(Loadtest);
        }
    }
}