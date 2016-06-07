using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Directory_Contents
{
    class Program
    {
        static void Main(string[] args)
        {
            Folder folder = new Folder();
            folder.LoadFolderInfos(@"C:\Windows\", true);
        }
    }
}
