using System;
using System.Threading;

namespace LP14
{
    class Program
    {
        static int x= 0;
        static object locker = new object();
        static void Main(string[] args)
        {
            //1. Инфа о всех запущенных процессах:
            Proc.PrintProcInfo();
            
            
            //2. Вывод инфы о домене
            Proc.DomensInfo();

            //3. 
            Proc.Streams();


            Threads threads = new Threads(12);
            threads.thr.Start();
            threads.thr.Join();
            threads.thr2.Start();
            threads.thr2.Join();
            Console.WriteLine("\n_____________________________________________________________");
            Threads threads2 = new Threads(12,5);
            threads2.thr.Start();
            threads2.thr.Join();
            threads2.thr2.Start();
            threads2.thr2.Join();


            //4.
            for (int i=0;i<5;i++)
            {
                Thread th = new Thread(co);
                th.Name = "Поток " + i;
                th.Start();
            }

            //5.
            int number = 3;
            TimerCallback callback = new TimerCallback(Threads.COUNT);
            Timer timer = new Timer(callback, number, 9, 1000);
            Console.ReadLine();
        }
        public static void co()
        {
            lock (locker)
            {
                x = 1;
                for(int i =1;i<9;i++)
                {
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name,x);
                    x++;
                    Thread.Sleep(400);
                }
            }
        }
    }
}
