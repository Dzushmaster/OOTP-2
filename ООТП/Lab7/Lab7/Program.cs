using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    interface IUser<T>
    {
        void Add(T element);
        void Delete(int index);
        void PrintAll();
    }
    class Set<T>: IUser<T>
    {
        public Set() { }
        public List<T> items = new List<T>();//список элементов
        public void Add(T element)
        {
            this.items.Add(element);
        }
        public void Delete(int index)
        {
            this.items.RemoveAt(index);
        }
        public void PrintAll()
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
        public static int isNumber(string Snumber) 
        {
            T a = default(T);
            if (!Int32.TryParse(Snumber, out int result))
                throw new isntNumber();
            return result;
        }
        public static double isDNumber(string Snumber)
        {
            if (!Double.TryParse(Snumber, out double result))
                throw new isntNumber();
            return result;
        }
        public static Set<T> operator +(Set<T> set, T newelem)
        {
            set.items.Add(newelem);
            return set;
        }
        public static Set<T> operator +(T newelem, Set<T> set)
        {
            set.items.Add(newelem);
            return set;
        }
        public static Set<T> operator +(Set<T> set, Set<T> set1)
        {
            Set<T> Union = new Set<T>();
            Union.items.AddRange(set.items);
            for (int i = 0; i < set1.items.Count; i++)
            {
                int counter = 0;
                for (int j = 0; j < set.items.Count; j++)
                {
                    if (set1.items.Equals(set.items[j]))
                        counter++;
                }
                if (counter == set.items.Count)
                    Union.items.Add(set1.items[i]);
            }
            Union.items.Sort();
            return Union;
        }
        public static Set<T> operator *(Set<T> set, Set<T> set1)
        {
            Set<T> Intersection = new Set<T>();
            for (int i = 0; i < set1.items.Count; i++)
            {
                bool counter = false;
                for (int j = 0; j < set.items.Count; j++)
                {
                    if (set1.items[i].Equals(set.items[j]))
                        counter = true;
                }
                if (counter)
                    Intersection.items.Add(set1.items[i]);
            }
            Intersection.items.Sort();
            return Intersection;
        }

        public static explicit operator int(Set<T> set) => set.items.Count;

        public static bool operator false(Set<T> array) => array.items.Count <= 15 && array.items.Count >= 1 ? true : false;
        public static bool operator true(Set<T> array) => array.items.Count <= 15 && array.items.Count >= 7 ? true : false;
    }
    class engine<T>
    {
        public engine(T capacity, T torque)
        {
            this.capacity = capacity;
            this.torque = torque;
        }
        T capacity;
        public T Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
            }
        }

        T torque;
        public T Torque
        {
            get
            {
                return Torque;
            }
            set
            {
                torque = value;
            }
        }

    }

    class Engine<T> where T:class
    {
        public Engine() { }
        public Engine(engine<T> eng)
        {
            this.capacity = eng.Capacity;
            this.torque = eng.Torque;
        }
        public Engine(T capacity, T torque)
        {
            this.capacity = capacity;
            this.torque = torque;
        }
        T capacity;//мощность 
        public T Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
            }
        }
        T torque;//крутящий момент
        public T Torque
        {
            get
            {
                return Torque;
            }
            set
            {
                torque = value;
            }
        }
        public override string ToString()
        {
            return "Capacity of this engine is " + this.capacity + "\ntorque:" + this.torque + "\n";
        }
    }


    //наследовать класс set от интерфейса, т.к. там все уже есть и будет норм работать
    //Обработку исключений для правильности ввода значений
    //ограничить обобщение
    //

    class Program
    {
        static void Pause()
        {
            Console.Read();
        }
        static void Main(string[] args)
        {
            Set<int> IntSet = new Set<int>();
            Set<double> DoubleSet= new Set<double>();
            IntSet.Add(5);
            IntSet.Delete(0);
            DoubleSet.Add(5.6);
            DoubleSet.Delete(0);
            engine<int> en = new engine<int>(500,700);
            Engine<engine<int>> Engine= new Engine<engine<int>>();
            Set<Engine<engine<int>>> EngineSet = new Set<Engine<engine<int>>>();
            EngineSet.Add(Engine);
            Console.WriteLine(EngineSet.items[0]);
            EngineSet.Delete(0);
            Set<int> firstset = new Set<int>();
            Console.WriteLine("Введите размер множества");
            int size = 0;
            try
            {
                size = Set<int>.isNumber(Console.ReadLine());
            }
            catch(isntNumber ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Сработал finally");
            }
            for (int i = 0; i < size; i++)
            {
                try
                {
                    firstset += Set<int>.isNumber(Console.ReadLine());
                }
                catch (isntNumber ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Сработал finally");
                }
            }
            Console.WriteLine("");
            firstset.PrintAll();

            Console.WriteLine("Введите размер множества");
            try
            {
                size = Set<int>.isNumber(Console.ReadLine());
            }
            catch (isntNumber ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Сработал finally");
            }
            Set<int> secondset = new Set<int>();
            for (int i = 0; i < size; i++)
            {
                try
                {
                    secondset += Set<int>.isNumber(Console.ReadLine());
                }
                catch (isntNumber ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Сработал finally");
                }
            }
            Console.WriteLine("");
            secondset.PrintAll();

            Set<int> thirdset = new Set<int>();
            thirdset = firstset + secondset;//объединение
            Console.WriteLine("---------------------------------------");
            thirdset.PrintAll();
            Console.WriteLine("---------------------------------------");
            Set<int> fourthset = firstset * secondset;//пересечение
            fourthset.PrintAll();
            Console.WriteLine("Размер третьего множества = {0}", (int)thirdset);
            if (thirdset)
                Console.WriteLine("Размер списка принадлежит промежутку от 7 до 15 ");
            else
                Console.WriteLine("Размер списка не принадлежит промежутку от 7 до 15 ");
            StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab7\Lab7\Text.txt", false);
            for (int i = 0; i < firstset.items.Count; i++)
            { sw.WriteLine(firstset.items[i]);}
            sw.Close();
            StreamReader sr = new StreamReader(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab7\Lab7\Text.txt");
            Set<int> read = new Set<int>();
            for (int i = 0; i < firstset.items.Count; i++)
                read.Add(Set<int>.isNumber(sr.ReadLine()));
            for (int i = 0; i < read.items.Count; i++)
                Console.Write("{0} ",read.items[i]);
            sr.Close();
            Pause();
        }
    }
}
