using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LP15
{
    class Program
    {
        public static int cus = 1;
        static void Main(string[] args)
        {
            int[,] mt1 = new int[,] { { 1, 2, 3, 7, 9 }, { 4, 6, 6, 14, 17 }, { 5, 9, 7, 4, 10 } };
            int[,] mt2 = new int[,] { { 2, 11,44 }, { 7, 9,17 }, { 8, 7,9 }, { 6, 8,4 }, { 15, 40,15 } };
            Console.WriteLine("Matrix 1:");
            Matrices.PrintMatr(mt1);
            Console.WriteLine("Matrix 2:");
            Matrices.PrintMatr(mt2);
            Stopwatch time = new Stopwatch();

            Task task1 = new Task(() => {
                Console.WriteLine($"Current task id: {Task.CurrentId}");
                Console.WriteLine("Matrix 3:");
                int[,] newMAtrix = Matrices.MatrMul(mt1, mt2);
                Matrices.PrintMatr(newMAtrix);
            });
            Console.WriteLine("<---------------------------- (Task1)Task ---------------------------->");
            Console.WriteLine($"Is completed: {task1.IsCompleted}");
            Console.WriteLine($"Status: {task1.Status}");
            time.Start();
            task1.Start();
            Console.WriteLine($"Is completed: {task1.IsCompleted}");
            Console.WriteLine($"Status: {task1.Status}");
            task1.Wait();
            time.Stop();
            Console.WriteLine($"Lead time: {time.ElapsedMilliseconds} ms");

            Console.WriteLine("<---------------------------- (Task2)CancellationToken ---------------------------->");


            CancellationTokenSource cst = new CancellationTokenSource();
            CancellationToken token = cst.Token;

            Task task2 = new Task(() => {
                try
                {
                    if (token.IsCancellationRequested)
                    {
                        throw new OperationCanceledException(token);
                    }
                    else
                    {
                        Console.WriteLine($"Current task id: {Task.CurrentId}");
                        Console.WriteLine("Matrix 3:");
                        var newMAtrix = Matrices.MatrMul(mt1, mt2);
                        Matrices.PrintMatr(newMAtrix);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            });

            task2.Start();
            cst.Cancel();
            task2.Wait();

            Console.WriteLine("<---------------------------- (Task3)For 4 task ---------------------------->");

            Task<Int32> t1 = new Task<int>((n) => Matrices.Div((int)n), 18);
            Task<Int32> t2 = new Task<int>((n) => Matrices.Div((int)n), 1000);
            Task<Int32> t3 = new Task<int>((n) => Matrices.Div((int)n), 123);
            t1.Start();
            t2.Start();
            t3.Start();
            Task.WaitAll();
            Console.WriteLine($"Result 1 = {t1.Result};\n" +
                              $"Result 2 = {t2.Result};\n" +
                              $"Result 3 = {t3.Result};\n");


            Console.WriteLine("<---------------------------- (Task4)Continue with ---------------------------->");
            //Console.WriteLine("<---------------------------- Part 1 ---------------------------->");

            var cwt = t1.ContinueWith(task =>
            {
                Console.WriteLine($"Result t1: {t1.Result}");
            });

            //Console.WriteLine("<---------------------------- Part 2 ---------------------------->");

            var cwt2 = t2.GetAwaiter().GetResult();
            Console.WriteLine($"Result t2: {cwt2}");

            
            Console.WriteLine("<---------------------------- (Task5)Comprassion parallel and standard cycles ---------------------------->");

            Task.WaitAll(t1, t2, t3);
            Console.WriteLine("For:");
            long ForStd = Matrices.forStd();
            long ForeachStd = Matrices.forPrll();
            Console.WriteLine("ForEach:");
            long ForPrll = Matrices.foreachStd();
            long ForeachPrll = Matrices.foreachPrll();

            Console.WriteLine("<---------------------------- Comparsion ---------------------------->");
            if (ForStd > ForPrll)
                Console.WriteLine("Standard \"For\" coped slower then Parallel on " + (ForStd- ForPrll) + "ms");
            else
                Console.WriteLine("Parallel \"For\" coped slower then Standard on " +(ForPrll - ForStd) + "ms");

            if (ForeachStd > ForeachPrll)
                Console.WriteLine("Standard \"Foreach\" coped slower then Parallel on " + (ForeachStd - ForeachPrll) + "ms");
            else
                Console.WriteLine("Parallel \"Foreach\" coped slower then Standard on " + (ForeachPrll - ForeachStd) + "ms");


            Console.WriteLine("<---------------------------- (Task6)Parallel Invoke ---------------------------->");

            Task.WaitAll(t1, t2, t3);
            Parallel.Invoke(
                () => Matrices.CreateArr(10000),
                () => Matrices.CreateArr(1000),
                () => Matrices.CreateArr(100000));

            Console.WriteLine("<---------------------------- (Task7)Comprassion parallel and standard cycles ---------------------------->");


            BlockingCollection<string> blockcoll = new BlockingCollection<string>();
            Task Seller = new Task(
                () =>
                {
                    List<string> Appliances = new List<string> { "Fridge", "Аir conditioning", "Plate", "Washing machine", "Teapot" };
                    int choose = 0;
                    Random rnd = new Random();
                    for (int i = 0; i < 5; i++)
                    {
                        choose = rnd.Next(0, Appliances.Count - 1);
                        Console.WriteLine($"Add \"{Appliances[choose].ToUpper()}\" in the shop");
                        blockcoll.Add(Appliances[choose]);
                        Appliances.RemoveAt(choose);
                        Thread.Sleep(choose);
                    }
                    blockcoll.CompleteAdding();
                });

            Task Customer = new Task(
                () =>
                {
                    string str;
                    while (blockcoll.IsCompleted == false)
                    {
                        if (blockcoll.TryTake(out str) == true)
                            Console.WriteLine($"Selled: \"{str.ToUpper()}\" to Customer{cus}");
                        else
                            Console.WriteLine($"Customer{cus} didn't buy anything");
                        cus++;
                    }

                });

            Seller.Start();
            Customer.Start();
            Customer.Wait();
            Seller.Wait();


            Console.WriteLine("<---------------------------- (Task8)Async ---------------------------->");

            Matrices.DivAsync();
            Console.Read();
        }
    }
}
