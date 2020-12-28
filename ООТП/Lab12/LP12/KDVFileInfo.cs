using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP12
{
    class KDVFileInfo
    {
        static public void FullPath(StreamWriter file, string pathToFile)
        {
            KDVLog.WriteUserInfo(pathToFile, File.GetCreationTime(pathToFile).ToString());
            KDVLog.LogWrite("Full Path");
            FileInfo Info = new FileInfo(pathToFile);
            file.WriteLine("--------------- Full path ---------------");
            file.WriteLine("Full path: " + Info.FullName);
        }
        static public void SizeExpansName(StreamWriter file ,string pathToFile)
        {
            KDVLog.WriteUserInfo(pathToFile, File.GetCreationTime(pathToFile).ToString());
            KDVLog.LogWrite("Size, Expans, Name");
            FileInfo Info = new FileInfo(pathToFile);
            file.WriteLine("--------------- Size, Extension, Name ---------------");
            file.WriteLine("Size of file: " + Info.Length);
            file.WriteLine("Extension of file: " + Info.Extension);
            file.WriteLine("Name of file: " + Info.Name);
        }

        static public void DateCreateChange(StreamWriter file, string pathToFile)
        {
            KDVLog.WriteUserInfo(pathToFile, File.GetCreationTime(pathToFile).ToString());
            KDVLog.LogWrite("Date of create of change");
            FileInfo Info = new FileInfo(pathToFile);
            file.WriteLine("--------------- Date of creating/changing ---------------");
            file.WriteLine("Date of creating/changing: " + Info.LastWriteTimeUtc);
        }

    }
}
