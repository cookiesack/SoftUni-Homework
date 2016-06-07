namespace FindWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    class FindWordsInFile
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input consists of: file path, count of words to look for and each word to look for on a separate line."); // example file path: input.txt
            StreamReader file = new StreamReader(Console.ReadLine());
            Dictionary<string, int> words = new Dictionary<string, int>();
            int wordsToCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < wordsToCount; i++)
            {
                words.Add(Console.ReadLine(), 0);
            }
            string line = "";
            List<string> currentLineWords = new List<string>();
            while (true)
            {
                line = file.ReadLine();
                if (line == null) break;
                currentLineWords = line.Split(' ').ToList();
                foreach (var word in currentLineWords)
                {
                    if (words.Keys.Contains(word)) words[word]++;
                }
            }
            foreach (var word in words.Keys)
            {
                Console.WriteLine("{0} -> {1}", word, words[word]);
            }
        }
    }
}
