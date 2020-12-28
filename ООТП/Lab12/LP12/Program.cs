using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP12
{

    class Program
    {
        static void Main(string[] args)
        {
            string pathToFile = "C:/Users/User/Desktop/Универ/2 курс/ООТП/Lab12/LP12/KDVDiskInfo.txt";
            using (StreamWriter driveInfo = new StreamWriter(pathToFile))
            {
                if (driveInfo == null)
                    throw new Exception("DiskInfo] Невозможно открыть файл для записи");
                KDVDiskInfo.FileSystem(driveInfo,pathToFile);
                KDVDiskInfo.DriveSpace(driveInfo,pathToFile);
                KDVDiskInfo.AllDrivesInfo(driveInfo,pathToFile);
            }
            pathToFile = "C:/Users/User/Desktop/Универ/2 курс/ООТП/Lab12/LP12/KDVFileInfo.txt";
            using (StreamWriter infoFile = new StreamWriter(pathToFile))
            {
                if (infoFile == null)
                    throw new Exception("[FileInfo] Невозможно открыть файл для записи");
                KDVFileInfo.FullPath(infoFile, pathToFile);
                KDVFileInfo.SizeExpansName(infoFile, pathToFile);
                KDVFileInfo.DateCreateChange(infoFile, pathToFile);
            }
            pathToFile = "C:/Users/User/Desktop/Универ/2 курс/ООТП/Lab12/LP12/KDVDriveInfo.txt";
            using (StreamWriter dirInfo = new StreamWriter(pathToFile))
            {
                if (dirInfo == null)
                    throw new Exception("[DriveInfo] Невозможно открыть файл для записи");
                string pathDirect = Path.GetDirectoryName(pathToFile);
                KDVDirInfo.CountOfFiles(dirInfo, pathDirect,pathToFile);
                KDVDirInfo.TimeCreating(dirInfo, pathDirect,pathToFile);
                KDVDirInfo.CountDirects(dirInfo, pathDirect,pathToFile);
                KDVDirInfo.ParentDirects(dirInfo, pathDirect,pathToFile);
            }
            pathToFile = @"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab12\LP12\KDVdirinfo.txt";
            using (StreamWriter dirInfo = new StreamWriter(pathToFile))
            {
                if (dirInfo == null)
                    throw new Exception("[] Невозможно открыть файл для записи");
                string pathDirect = Path.GetDirectoryName(pathToFile);
                Directory.CreateDirectory(pathDirect + @"\KDVInspect");
                KDVFileManager.AllFilesDirects(dirInfo,pathToFile);
                dirInfo.Close();
                KDVFileManager.CopyRenameFile(pathToFile, pathDirect + @"\Renamed.txt",pathToFile);
                File.Delete(pathToFile);
                Directory.CreateDirectory(pathDirect + @"\KDVFiles");
                KDVFileManager.CopyAllType(pathDirect, pathDirect + @"\KDVFiles", "*.txt",pathToFile);
                KDVFileManager.MoveToOther(pathDirect + @"\KDVFiles", @"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab12\LP12\KDVInspect",pathToFile);
                //создать архив директория и разархивировать в другой
            }
            pathToFile = @"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab12\LP12\KDVInspect";
            string zip = @"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab12\LP12\Zip.zip";
            string ToFile = @"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab12\LP12\bin";
            //KDVFileManager.ArhivationReArh(pathToFile,ToFile,zip,pathToFile);
            string str = DateTime.Now.Hour.ToString();
            KDVLog.FindInfo(str);
            Console.Read();
        }
    }
}
