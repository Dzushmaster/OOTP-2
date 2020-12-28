using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{

    //части класса:
    //Название
    //Количество углов
    //Длина, ширина, высота
    //Фигура в основании(если есть высота)
    class Program
    {
        static void Main(string[] args)
        {
            //----------------------------- Exercise 1 ---------------------------
            Console.WriteLine("------------------------Exercise 1 ---------------------------");
            AllFigures figures = new AllFigures(new Figure(44,12),new Figure(44,12,97), new Figure(89, 2, 13), new Figure(4, 1, 7));
            figures.AddFigure(15,28);
            figures.AddFigure(15, 28, 45);
            figures.AddFigure(1, 8);
            figures.AddFigure(5, 8, 4);
            Figure figure = (Figure)figures.Current;
            Console.WriteLine(figure.ToString() + '\n');
            figures.MoveNext();
            Figure figure1 = (Figure)figures.Current;
            Console.WriteLine(figure1.ToString() + '\n');
            figures.MoveNext();
            Figure figure2 = (Figure)figures.Current;
            Console.WriteLine(figure2.ToString());
            figures.Reset();
            Figure figure3 = (Figure)figures.Current;
            Console.WriteLine(figure3.ToString() + '\n');
            //------------------------------- Exercise 2 ---------------------------
            Console.WriteLine("------------------------Exercise 2 ---------------------------");
            //a
            foreach (Figure item in figures)
            {
                Console.WriteLine(item.ToString() + "\n");
            }
            //b
            figures.Delete(4);
            Console.WriteLine("После удаления\n");
            foreach (Figure item in figures)
            {
                Console.WriteLine(item.ToString() + "\n");
            }
            //c
            Figure figure4 = new Figure(17, 19, 20);
            Figure figure5 = new Figure(17, 19);
            Figure figure6 = new Figure(17, 20);
            Figure figure7 = new Figure(19, 20);
            Figure figure8 = new Figure(19, 20);
            Figure figure9 = new Figure(14, 12, 9);
            figures.AddFigures( figure4,figure5,figure6,figure7,figure8,figure9);
            foreach (Figure item in figures)
                Console.WriteLine(item.ToString() + "\n");
            //d
            List<Figure> ListFigures = new List<Figure>();
            foreach (Figure item in figures)
                ListFigures.Add(item);
            //e
            foreach (Figure item in ListFigures)
                Console.WriteLine("Item in ListFigures: {0}", item);
            //f
            if(ListFigures.Contains(figure7))
                Console.WriteLine($"figure7 {figure7.ToString()} is in the list");

            //------------------------------- Exercise 3 ---------------------------
            Console.WriteLine("------------------------Exercise 3 ---------------------------");
            ObservableCollection <Figure> collection = new ObservableCollection<Figure>();
            collection.CollectionChanged += CollectionChanges;
            collection.Add(figure1);
            Console.WriteLine('\n');
            collection.Add(figure2);
            Console.WriteLine('\n');
            collection.Add(figure3);
            Console.WriteLine('\n');
            Console.WriteLine("After add");
            foreach (Figure item in collection)
            {
                Console.WriteLine(item.ToString() + '\n');
            }
            collection.Remove(figure2);
            Console.WriteLine('\n');
            Console.WriteLine("After delete");
            foreach (Figure item in collection)
            {
                Console.WriteLine(item.ToString() + '\n');
            }
            Console.Read();
        }
        static void CollectionChanges(object obj, System.Collections.Specialized.NotifyCollectionChangedEventArgs notify)
        {
            if (notify.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("You deleted ");
                foreach (var item in notify.OldItems)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else if(notify.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("You added ");
                foreach (var item in notify.NewItems)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
