using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Problem_6._Zipping_Sliced_Files
{
    class Program
    {
        static void Main()
        {
            var sourceFile = "../Materials/sliceMe.mp4";
            Console.Write("Type in the number of slices:");
            var destination = "../Output/Sliced File/";
            int parts = int.Parse(Console.ReadLine());

            Slice(sourceFile, destination, parts);

            var files = new List<string>();

            for (int i = 0; i < parts; i++)
            {
                files.Add($"Part-{i}.mp4.gz");
            }

            Assemble(files, destination);
            Console.WriteLine($"{parts} zipped and 1 assembled files  have successfuly been saved in the {destination} folder.");
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                var pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {

                    var currentPart = destinationDirectory + $"Part-{i}.mp4.gz";

                    using (var writer = new FileStream(currentPart, FileMode.Create))
                    {
                            using (var compressStream = new GZipStream(writer, CompressionMode.Compress, false))
                            {
                                byte[] buffer = new byte[pieceSize]; 
                                int readBytes = reader.Read(buffer, 0, buffer.Length);
                                compressStream.Write(buffer, 0, readBytes);
                            }
                        
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {

            var outputFile = $"{destinationDirectory}Assembled.mp4";

            using (var writer = new FileStream(outputFile, FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                foreach (var file in files)
                {
                    using (var reader = new FileStream($"{destinationDirectory}{file}", FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, buffer.Length) == buffer.Length)
                        {
                            writer.Write(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}
