using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace _02.Directory_Contents
{
    public class Folder
    {
        public string Name { get; private set; }

        public File[] Files { get; private set; }

        public Folder[] Folders { get; private set; }

        public void LoadFolderInfos(string path, bool log = false)
        {
            if (!path.EndsWith("\\")) path = path + "\\";
            string directoryFullPath = Path.GetDirectoryName(path);
            if (directoryFullPath != null)
            {
                Name = directoryFullPath.Split(Path.DirectorySeparatorChar).Last();
            }
            else
            {
                Name = path;
            }
            if(log) Console.WriteLine("Working on folder {0}...", Name);

            string[] directoriesPaths;
            try
            {
                Files = Directory.GetFiles(path)
                    .Select(p => new File(name: Path.GetFileName(p), size:(new FileInfo(p)).Length))
                    .ToArray();

                 directoriesPaths = Directory.GetDirectories(path);
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }

            Folders = new Folder[directoriesPaths.Length];

            for (int i = 0; i < Folders.Length; i++)
            {
                Folders[i] = new Folder();
                Folders[i].LoadFolderInfos(directoriesPaths[i], true);
            }
        }
    }
}
