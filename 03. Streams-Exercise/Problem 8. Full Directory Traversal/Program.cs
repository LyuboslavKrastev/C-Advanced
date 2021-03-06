﻿namespace Problem_8._Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Program
    {
        private static string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private static string DestinationPath = DesktopPath + "/fullReport.txt";

        public static void Main(string[] args)
        {
            Console.Write("Input the directory to be traveresed:");
            var traversedDirectory = Console.ReadLine();
            if (traversedDirectory == "")
            {
                traversedDirectory = "../";
                Console.WriteLine($"Traversing directory {traversedDirectory}...");
            }
            Console.WriteLine($"A report file [fullReport.txt], containing information about all folders within the given directory has successfuly been exported to your desktop!");
            var fileKeeper = new Dictionary<string, List<FileInfo>>();

            var folder = Directory.GetFiles(traversedDirectory, "*.*", SearchOption.AllDirectories).Select(x => new FileInfo(x));

            foreach (var fileInfo in folder)
            {

                var extension = fileInfo.Extension;
                var size = fileInfo.Length;

                if (!fileKeeper.ContainsKey(extension))
                {
                    fileKeeper[extension] = new List<FileInfo>();
                }
                fileKeeper[extension].Add(fileInfo);
            }
            fileKeeper = fileKeeper.OrderByDescending(f => f.Value.Count).ThenBy(f => f.Key).ToDictionary(f => f.Key, f => f.Value);
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
