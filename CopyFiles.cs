using System;
using System.IO;

namespace DirectoryChange
{
    public class CopyFiles
    {
        public static void CopyDirectory(DirectoryInfo source, DirectoryInfo target)
        {
            // Check if target path exists, if not create
            Directory.CreateDirectory(target.FullName);
            
            try
            {
                foreach (var file in source.GetFiles())
                {
                    //Copy all single files
                    file.CopyTo(Path.Combine(target.FullName, file.Name), true);
                    var migrator = new Migrator(new FileLogger("/Users/izstoev/textLog.txt"));
                    migrator.Migrate(file.FullName + "has been moved to" + target.FullName);
                }

                //Find subdirectory in source
                try
                {
                    foreach (var subDirectory in source.GetDirectories())
                    {
                        var targetSubDirectory = target.CreateSubdirectory(source.Name);

                        //Copy all directories and subdirectories 
                        CopyDirectory(subDirectory, targetSubDirectory);
                    }
                }
                catch(SystemException)
                {
                    Console.WriteLine("file already exists");
                }
                
            //Catch if directory is not valid
            }catch (DirectoryNotFoundException)
            {
                Console.WriteLine("source directory not found" + source);
            }
        }
    }
}
