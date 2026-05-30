using System;
using System.IO;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;


class Program{
    static void Main(string[] args)
    {
        
        Journal newJournal = new Journal();
        int userinput = 0;
        string filename = "";
        while (userinput != 5){
            Console.WriteLine("Enter a number (1-5)");
            userinput = Convert.ToInt32(Console.ReadLine());
            if (userinput == 1)
            {
                string prompt = Entry.randPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string text = Console.ReadLine();
                Console.Write("Enter a time: ");
                string time = Console.ReadLine();
                Entry newEntry = new Entry(time, prompt, text);
                newJournal.Add(newEntry);
            }
            else if (userinput == 2)
            {
                string JournalString = newJournal.toString();
                Console.WriteLine(JournalString);
            }
            else if (userinput == 3)
            {
               Console.WriteLine("Enter the name of a text file");
               filename = Console.ReadLine();
               newJournal.LoadFile(filename);
               
            }
            else if (userinput == 4)
            {
               Console.WriteLine("Save file as: ");
               filename = Console.ReadLine(); 
               newJournal.SaveFile(filename);
               Console.WriteLine("Save successful");
            }
            else if (userinput == 5)
            {
               Console.WriteLine("Program End");
            }

        }
        Console.WriteLine("Done");
        /*
        Console.WriteLine(Journal.toString());
        Entry newEntry = new Entry();
        newEntry.text = "";
        newEntry.prompt = "";
        Random rand = new Random();
        string randPrompt = prompts[rand.Next(prompts.Count)]; 
        return randPrompt */
    }
}