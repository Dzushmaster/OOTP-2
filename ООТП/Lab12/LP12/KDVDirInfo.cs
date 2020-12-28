using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP12
{
    class KDVDirInfo
    {
        public static void CountOfFiles(StreamWriter file,string pathDirect,string pathToFile)
        {
            KDVLog.WriteUserInfo(pathToFile, File.GetCreationTime(pathToFile).ToString());
            KDVLog.LogWrite("Count of files");
            DirectoryInfo directoryInfo = new DirectoryInfo(pathDirect);
            file.WriteLine("--------------- Count of files --------------- ");
            file.WriteLine("Count of files in the directory is: " + directoryInfo.GetFiles().Length);
        }
        public static void TimeCreating(StreamWriter file,string pathDirect,string pathToFile)
        {
            KDVLog.WriteUserInfo(pathToFile, File.GetCreationTime(pathToFile).ToString());
            KDVLog.LogWrite("Time creating");
            DirectoryInfo directoryInfo = new DirectoryInfo(pathDirect);
            file.WriteLine("--------------- Time of creating direct --------------- ");
            file.WriteLine("Count of files in the directory is: " + directoryInfo.CreationTimeUtc);
        }
        public static void CountDirects(StreamWriter file, string pathDirect, string pathToFile)
        {
            KDVLog.WriteUserInfo(pathToFile, File.GetCreationTime(pathToFile).ToString());
            KDVLog.LogWrite("Count directs");
            DirectoryInfo directoryInfo = new DirectoryInfo(pathDirect);
            file.WriteLine("--------------- Count of directory --------------- ");
            file.WriteLine("Count of directory in the directory is: " + directoryInfo.GetDirectories().Length);
        }
        public static void ParentDirects(StreamWriter file, string pathDirect,string pathToFile)
        {
            KDVLog.WriteUserInfo(pathToFile, File.GetCreationTime(pathToFile).ToString());
            KDVLog.LogWrite("Parent directs");
            DirectoryInfo directoryInfo = new DirectoryInfo(pathDirect);
            file.WriteLine("--------------- Parents of directory --------------- ");
            file.WriteLine("Parent directory: " + directoryInfo.Parent.FullName);
        }
    }
}
