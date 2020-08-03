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
            string path = "";
            if (args.Count() >= 1)
            {
                if (args.Contains("-h") || args.Contains("-?"))
                {
                    Console.WriteLine("Usage: PngToJpegConverter -h [Input path]\n" +
                        "\nOptions:" +
                        "\n\t-h\t\tDisplays the help");
                    return;
                }
                if (args.Count() == 1 )
                {
                    path = args[0];
                }
            }
            else
            {
                Console.Write("Full path: ");
                path = Console.ReadLine();
            }
            IEnumerable<string> files = Directory.EnumerateFiles(path, "*.png");
            string folder = path.Substring(path.LastIndexOf('\\') + 1);
            Console.WriteLine("{0} files found.", files.Count());

            if (!Directory.Exists(@"C:\Users\Andreas\Desktop\" + folder)) 
            {
                Directory.CreateDirectory(@"C:\Users\Andreas\Desktop\" + folder);
            }

            foreach (var item in files)
            {
                Image image = Image.FromFile(item);
                string fileName = item.Substring(item.LastIndexOf('\\') +1, item.LastIndexOf('.')-1 - item.LastIndexOf('\\'));
                string newFile = path + "\\" + fileName + ".jpeg";
                File.Copy(item, @"C:\Users\Andreas\Desktop\" + folder + "\\" + fileName + ".png");
                image.Save(newFile, ImageFormat.Jpeg);
                image.Dispose();
                File.Delete(item);
            }
            Console.WriteLine("Conversion succeeded.");
            Console.ReadLine();
            return;
        }
    }
}
