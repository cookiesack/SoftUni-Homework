using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class WordCount
{
    static void Main(string[] args)
    {
        StreamReader words = new StreamReader("words.txt");
        StreamReader text = new StreamReader("text.txt");
        StreamWriter results = new StreamWriter("results.txt");
        string line = "";
        List<string> sWords = new List<string>();
        do
        {
            line = words.ReadLine();
            sWords.Add(line);
        }
        while (line != null);
        List<int> count = new List<int>();
        for (int i = 0; i < sWords.Count; i++)
        {
            count.Add(0);
        }
        string sText = text.ReadToEnd().ToLower();
        for (int i = 0; i < sWords.Count-1; i++)
        {
            for (int j = 0; j <= sText.Length - sWords[i].Length; j++)
            {
                if (j == 0)
                {
                    if (sWords[i] == sText.Substring(j, sWords[i].Length) && Char.IsLetter(sText[j+sWords[i].Length])==false) count[i]++;
                }
                else
                {
                    if (sWords[i] == sText.Substring(j, sWords[i].Length) && Char.IsLetter(sText[j-1]) == false && Char.IsLetter(sText[j + sWords[i].Length]) == false) count[i]++;
                }
            }
        }
        for (int i = 0; i < sWords.Count-1; i++)
        {
            sWords[i] = count[i].ToString() + sWords[i];
        }
        sWords.Sort();
        for (int i = sWords.Count - 1; i > 0; i--)
        {
            results.WriteLine(sWords[i].Substring(1) + " - " + sWords[i][0]);
        }

        words.Close();
        text.Close();
        results.Close();
    }
}