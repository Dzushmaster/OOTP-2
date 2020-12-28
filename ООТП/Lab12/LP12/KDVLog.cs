using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP12
{
  /*Используя данный класс выполните запись всех последующих действиях 
  * пользователя с указанием действия, детальной информации (имя файла, путь)
  * и времени (дата/время) 
  */
    class KDVLog
    {
        public static void WriteUserInfo(string username, string time)
        {
            using (StreamWriter write = new StreamWriter(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab12\LP12\KDVlogfile.txt", true))
            {
                if (write == null)
                    throw new Exception("[KDVlog]Невозможно открыть файл для записи");
                write.Write("Name: " + username + " Time: " + time);
            }
        }
        public static void LogWrite(string writestr)
        {
            using (StreamWriter write = new StreamWriter(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab12\LP12\KDVlogfile.txt", true))
            {
                if (write == null)
                    throw new Exception("[KDVlog]Невозможно открыть файл для записи");
                write.WriteLine(writestr);
            }
        }
        public static void LogRead()
        {
            using (StreamReader read = new StreamReader(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab12\LP12\KDVlogfile.txt"))
            {
                if (read == null)
                    throw new Exception("[KDVlog]Невозможно открыть файл для чтения");
                Console.WriteLine(read.ReadToEnd());
            }
        }
        public static void FindInfo(string Name)
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab12\LP12\KDVlogfile.txt"))
            {
                string buf = null;
                while ((buf = sr.ReadLine()) != null)
                {
                    if (buf.Contains(Name))
                    {
                        buf = sr.ReadLine();
                        if (buf != null) Console.WriteLine(buf);
                    }
                }
            }
        }
    }
}
