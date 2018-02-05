using System;
using System.IO;

namespace Problem_4._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var imagePath = "../Materials/copyMe.png";
            string outputPath = "../Output/imageCopy.png";
            var buffer = new byte[4096];
            using (var source = new FileStream(imagePath, FileMode.Open))
            {
                using (var destination =
                  new FileStream(outputPath, FileMode.Create))
                {
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                            break;
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }

        }
    }
}
