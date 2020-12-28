using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LP14
{
    class Proc
    {
        //1. Use GetProcess()
        public static void PrintProcInfo()
        {
            try
            {
                Console.WriteLine("<------------- Info about all runnig processes ------------->");
                var processes = Process.GetProcesses();
                foreach (var item in processes)
                {
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab14\LP14\Processes.txt", true))
                    {
                        sw.WriteLine("\n_____________________________________________________________");
                        sw.WriteLine($"Id of this process is {item.Id};\n" +
                                          $"Name of this proc is {item.ProcessName};\n" +
                                          $"Priority of this proc is {item.BasePriority};\n" +
                                          $"Current state of this proc id {item.Responding}.");
                        // $"Start time of this proc is {item.StartTime};\n" +
                        // $"Current state of this proc is {item.TotalProcessorTime}"
                        sw.WriteLine("\n_____________________________________________________________");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //2. Имя домена, детали конфигурации, все сборки, которые были загружены в домен
        public static void DomensInfo()
        {
            AppDomain appDomain = AppDomain.CurrentDomain;
            Console.WriteLine("<------------- Info about current domain ------------->");
            Console.WriteLine("\n_____________________________________________________________");

            Console.WriteLine($"Имя домена: {appDomain.FriendlyName};\n" +
                              $"Id домена: {appDomain.Id};\n" +
                              $"Разрешения предоставленные приложению: {appDomain.ApplicationTrust};" +
                              $"Базовый каталог: {appDomain.BaseDirectory}.");
            Console.WriteLine("\n_____________________________________________________________");
            try
            {
                AppDomain appDomain2 = AppDomain.CreateDomain("newDomain");
                Console.WriteLine("Lab7.exe was loaded");
                appDomain2.ExecuteAssembly(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab7\Lab7\bin\Debug\Lab7.exe");
                AppDomain.Unload(appDomain2);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //3. Отдельный поток
        public static void Streams()
        {
            Thread thread = new Thread(printNumber);
            thread.Start();
            thread.Name = "Numb";
            Console.WriteLine("The first thread is " + thread.ThreadState);
            Console.WriteLine($"Name of this thread is {thread.Name};\n" +
                              $"Id: {thread.ManagedThreadId} \n" +
                              $"Priority {thread.Priority}\n " +
                              $"State {thread.ThreadState} \n ");
            thread.Join();
        }
        static void printNumber()
        {
            UInt32 n = Convert.ToUInt32(Console.ReadLine());
            Console.Write("N = ");
            Console.WriteLine("Простые числа из диапазона ({0}, {1})", 1, n);
            for (UInt32 i = 1u; i < n; i++)
            {
                if (IsPrimeNumber(i))
                {
                    Console.Write($"{i} ");
                    using (StreamWriter stream = new StreamWriter(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab14\LP14\numb.txt", false))
                    {
                        stream.Write(i);
                    }
                }
            }
        }
        static bool IsPrimeNumber(uint n)
        {
            bool result = true;

            if (n > 1)
            {
                for (UInt32 i = 2u; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        //4. Два потока, первый выводит четные числа, второй нечетные. Запись в файл и консоль
        
        //5. 
    }
    class Threads
    {
        public Thread thr;
        public Thread thr2;
        int n;
        static int x = 0;
        public Threads(int n)
        {
            this.n = n;
            thr = new Thread(printEven);
            thr2 = new Thread(printOdd);
        }
        public Threads(int n, int k)
        {
            this.n = n;
            thr = new Thread(printEven);
            thr2 = new Thread(printOdd);
            if (k > 1)
            {
                thr.Priority = ThreadPriority.Highest;
                thr2.Priority = ThreadPriority.Lowest;
            }
            else
            {
                thr2.Priority = ThreadPriority.Highest;
                thr.Priority = ThreadPriority.Lowest;
            }
        }

        void printEven()//Четное
        {
            Console.WriteLine(Thread.CurrentThread.Priority);
            for (int i = 0; i < n; i++)
                if (i % 2 == 0)
                {
                    Console.Write(i + " ");
                    using (StreamWriter stream = new StreamWriter(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab14\LP14\FirstEven.txt",true))
                        stream.Write(i + " ");
                }
            Console.WriteLine();
            Thread.Sleep(500);
        }
        void printOdd()//Нечетное
        {
            Console.WriteLine(Thread.CurrentThread.Priority);
            for (int i = 0; i < n; i++)
                if (i % 2 != 0)
                {
                    Console.Write(i + " ");
                    using (StreamWriter stream = new StreamWriter(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab14\LP14\OddEven.txt",true))
                        stream.Write(i + " ");
                }
            Console.WriteLine();
            Thread.Sleep(700);
        }
        public static void COUNT(object obj)
        {
            Console.WriteLine("Таймер :");
            int x = (int)obj;
            for (int i = 1; i < 5; i++, x++)
            {
                Console.WriteLine(x * i - i);
            }

        }
    }

}
