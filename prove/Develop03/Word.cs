using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
public class Word
{
    public string jjmWordText;
    private bool jjmHiddenFlag;

    public Word(string text)
    {
        jjmWordText = text;
        jjmHiddenFlag = false;
    }

    public bool GetHidden()
    {
        return jjmHiddenFlag;
    }

    public void SetHidden(bool value)
    {
        jjmHiddenFlag = value;
    }

    public void Hide()
    {
        if (jjmHiddenFlag == false)
        {
            jjmHiddenFlag = true;
        }
        else if (jjmHiddenFlag == true)
        {
            jjmHiddenFlag = false;
        }

    }

    override public string ToString()
    {
        string jjminput = "";
        
        if (jjmHiddenFlag == false)
        {
            jjminput = jjmWordText;
        }
        else if (jjmHiddenFlag == true)
        {    
            int jjmWordleng = jjmWordText.Length;
            jjminput = new string('-',jjmWordleng);
        }
        return jjminput;
    }
}