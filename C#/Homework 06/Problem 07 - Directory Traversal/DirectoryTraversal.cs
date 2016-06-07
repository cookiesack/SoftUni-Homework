using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


class DirectoryTraversal
{
    static void Main(string[] args)
    {
        int kor;

        string input = Console.ReadLine();
        List<string> files = Directory.GetFiles(input).ToList(),
                     extensions = new List<string>();
        FileStream output = new FileStream("report.txt", FileMode.Create);
        for (int i = 0; i < files.Count; i++)
        {
            extensions.Add(Path.GetExtension(files[i]));
        }
        extensions = extensions.Distinct().ToList();
        int[] count = new int[extensions.Count];
        for (int i = 0; i < count.Length; i++)
        {
            count[i] = 0;
        }
        for (int i = 0; i < files.Count; i++)
        {
            count[extensions.IndexOf(Path.GetExtension(files[i]))]++;
        }
        List<List<string>> names = new List<List<string>>();
        for (int i = 0; i < extensions.Count; i++)
        {
            names.Add(new List<string>());
            for (int j = 0; j < files.Count; j++)
            {
                if (Path.GetExtension(files[j]) == extensions[i]) names[i].Add(files[j]);
            }
        }
        for (int i = 0; i < names.Count; i++)
        {

        }
        for (int i = 0; i < extensions.Count; i++)
        {
            extensions[i] = count[i] + extensions[i];
        }
        extensions.Sort();
        extensions.Reverse();
        for (int i = 0; i < extensions.Count; i++)
        {
            Console.WriteLine(Path.GetExtension(extensions[i]));
            names[i].OrderBy(n => n.Substring(n.LastIndexOf('-') + 1, n.LastIndexOf('k') - n.LastIndexOf('-') - 1));
            names.OrderByDescending(n => n.Count);
            for (int j = 0; j < names[i].Count; j++)
            {
                Console.WriteLine("--" + Path.GetFileName(names[i][j]) + " - {0:0.000}", (double)new FileInfo(names[i][j]).Length/1024);
            }
        }
    }
}