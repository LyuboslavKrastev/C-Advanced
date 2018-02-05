namespace Problem_7._Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private static string DestinationPath = DesktopPath + "/report.txt";

        public static void Main(string[] args)
        {
            Console.Write("Input the directory to be traveresed:");
            var traversedDirectory = Console.ReadLine();
            if (traversedDirectory == "")
            {
                traversedDirectory = "../Materials";
                Console.WriteLine($"Traversing directory {traversedDirectory}");
            }
            Console.WriteLine($"A report file [report.txt] has successfuly been exported to your desktop!");
            var fileKeeper = new Dictionary<string, List<FileInfo>>();
            
            var folder = Directory.GetFiles(traversedDirectory);

            foreach (var file in folder)
            {
                var currentFileInfo = new FileInfo(file);

                var extension = currentFileInfo.Extension;
                var size = currentFileInfo.Length;

                if (!fileKeeper.ContainsKey(extension))
                {
                    fileKeeper[extension] = new List<FileInfo>();
                }

                fileKeeper[extension].Add(currentFileInfo);
            }
            fileKeeper = fileKeeper.OrderByDescending(f => f.Value.Count).ThenBy(f => f.Key).ToDictionary(f => f.Key, f=>f.Value);
            using (var writer = new StreamWriter(DestinationPath))
            {
                foreach (var file in fileKeeper)
                {
                    writer.WriteLine(file.Key);

                    foreach (var info in file.Value)
                    {
                        var fileName = info.Name;
                        var size = (double)info.Length / 1024;

                        writer.WriteLine($"--{fileName} - {size:f3}kb");
                    }
                }
            }
        }
    }
}
