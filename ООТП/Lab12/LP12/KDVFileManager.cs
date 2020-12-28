using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
namespace LP12
{
    class KDVFileManager
    {   
        public static void AllFilesDirects(StreamWriter file, string pathToFile)
        {
            KDVLog.WriteUserInfo(pathToFile, File.GetCreationTime(pathToFile).ToString());
            KDVLog.LogWrite("Full Path");
            foreach (string item in Directory.GetFileSystemEntries(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab12\LP12"))
            {
                file.WriteLine(item);
            }
        }
        public static void CopyRenameFile(string sourceFileName, string destFile, string pathToFile)
        {
            KDVLog.WriteUserInfo(pathToFile, File.GetCreationTime(pathToFile).ToString());
            KDVLog.LogWrite("Full Path");
            FileInfo a = new FileInfo(sourceFileName);
            a.CopyTo(destFile,true);
        }
        public static void CopyAllType(string sourceFiles, string destFile, string Exstencion, string pathToFile)
        {
            KDVLog.WriteUserInfo(pathToFile, File.GetCreationTime(pathToFile).ToString());
            KDVLog.LogWrite("Full Path");
            var nedeedFiles = Directory.GetFiles(sourceFiles, Exstencion);
            int index = 0;
            foreach (var item in nedeedFiles)
            {
                File.Copy(item, destFile +"/" + index++ + ".txt" ,true);
            }
        }
        public static void MoveToOther(string sourceAdress, string destAdress, string pathToFile)
        {
            KDVLog.WriteUserInfo(pathToFile, File.GetCreationTime(pathToFile).ToString());
            KDVLog.LogWrite("Full Path");
            var a = Directory.CreateDirectory(destAdress + @"\KDVFiles");
            int index = 0;
            foreach (var item in Directory.GetFiles(sourceAdress))
            {
                File.Copy(item, a.FullName + @"\"+index++ + ".txt",true);    
            }
            Directory.Delete(sourceAdress,true);
        }
        public static void ArhivationReArh(string Adress,string NewAdress,string Zip, string pathToFile)
        {
            KDVLog.WriteUserInfo(pathToFile, File.GetCreationTime(pathToFile).ToString());
            KDVLog.LogWrite("Full Path");
            ZipFile.CreateFromDirectory(Adress, Zip);
            ZipFile.ExtractToDirectory(Zip,NewAdress);
        }
    }
}
