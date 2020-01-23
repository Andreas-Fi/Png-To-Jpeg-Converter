using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace PngToJpegConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Andreas\OneDrive\Wallpapers";
            IEnumerable<string> files = Directory.EnumerateFiles(path, "*.png");
            Console.WriteLine("{0} files found.", files.Count());
            foreach (var item in files)
            {
                Image image = Image.FromFile(item);
                string fileName = item.Substring(item.LastIndexOf('\\') +1, item.LastIndexOf('.')-1 - item.LastIndexOf('\\'));
                string newFile = @"C:\Users\Andreas\Desktop\pics\" + fileName + ".jpeg";
                image.Save(newFile, ImageFormat.Jpeg);
                image.Dispose();
            }
            Console.WriteLine("Conversion succeeded.");
            Console.ReadLine();
            return;
        }
    }
}
