using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP12
{
    /*
    a.  свободном месте на диске 
    b. Файловой системе 
    c. Для каждого существующего диска  - имя, объем, доступный объем, метка тома. 
    d. Продемонстрируйте работу класса 
    */
    class KDVDiskInfo
    {
        //a
        static public void DriveSpace(StreamWriter file, string path)
        {
            KDVLog.WriteUserInfo(path, File.GetCreationTime(path).ToString());
            KDVLog.LogWrite("Drive space");
            DriveInfo[] Drives = DriveInfo.GetDrives();
            file.WriteLine("--------------- Drive space --------------- ");
            foreach (var item in Drives)
                file.WriteLine("Drive name: " + item.Name + " " + item.TotalFreeSpace + "/" + item.TotalSize + " is empty");
        }
        //b
        static public void FileSystem(StreamWriter file,string path)
        {
            KDVLog.WriteUserInfo(path,File.GetCreationTime(path).ToString());
            KDVLog.LogWrite("file System");
            DriveInfo[] Drives = DriveInfo.GetDrives();
            file.WriteLine("--------------- file system --------------- ");
            foreach (var item in Drives)
            {
                file.WriteLine("________________________________________________");
                file.WriteLine("Drive name: " + item.Name);
                file.WriteLine("Volume label: " + item.VolumeLabel);
                if (!item.IsReady)
                    continue;
                file.WriteLine("file system: " + item.DriveFormat);
                file.WriteLine("Drive type: " + item.DriveType);
                file.WriteLine("Root: " + item.RootDirectory);
                file.WriteLine("Free space:" + item.TotalFreeSpace + "/" + item.TotalSize + " is empty");
                file.WriteLine("________________________________________________");
            }

        }
        //c
        static public void AllDrivesInfo(StreamWriter file,string path)
        {
            KDVLog.WriteUserInfo(path, File.GetCreationTime(path).ToString());
            KDVLog.LogWrite("All drivers info");
            DriveInfo[] Drives = DriveInfo.GetDrives();
            file.WriteLine("--------------- Information about all drives --------------- ");
            foreach (var item in Drives)
            {
                file.WriteLine("________________________________________________");
                file.WriteLine("Drive name: " + item.Name);
                file.WriteLine("Volume label: " + item.VolumeLabel);
                file.WriteLine("file system: " + item.DriveFormat);
                file.WriteLine("Free space:" + item.TotalFreeSpace + "/" + item.TotalSize + " is empty");
                file.WriteLine("________________________________________________");

            }
        }
    }
}
