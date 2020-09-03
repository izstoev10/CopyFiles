using System;
using System.IO;

namespace DirectoryChange
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("please enter the path that you wish to copy");
            string sourcePath = Console.ReadLine();

            Console.WriteLine("now enter the destination you wish to copy it to");
            string destinationPath = Console.ReadLine();

            //Get directory info for both paths

            var sourceInfo = new DirectoryInfo(sourcePath);
            var destinationInfo = new DirectoryInfo(destinationPath);

            CopyFiles.CopyDirectory(sourceInfo, destinationInfo);

            Console.WriteLine("Type 'D' if you want the source files deleted");

            //Delete already copied files if user proceeds
            if (Console.ReadKey().Key == ConsoleKey.D)
            {
                DeleteOldFiles.Delete(sourceInfo);
            }
            

        }
    }
}
