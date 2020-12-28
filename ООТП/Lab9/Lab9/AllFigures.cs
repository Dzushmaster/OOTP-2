using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class AllFigures:IEnumerator,IEnumerable
    {
        private Stack<Figure> StackFigures = new Stack<Figure>();
        private List<Figure> PopFigures = new List<Figure>();
        public AllFigures() { }
        public AllFigures(params Figure[]figures) { AddFigures(figures); }
        public void AddFigures(params Figure[] figures)
        {
            foreach (Figure item in figures)
            {
                AddFigure(item);
            }
        }
        public void AddFigure(float length, float width)
        {
            Figure figure = new Figure(length, width);
            StackFigures.Push(figure);
        }
        public void AddFigure(float length, float width, float heigth)
        {
            Figure figure = new Figure(length, width, heigth);
            StackFigures.Push(figure);
        }
        public void AddFigure(Figure figure) => StackFigures.Push(figure);
        //----------------------------- Exercise 1--------------------------------------
        public object Current
        {
            get { return StackFigures.Peek(); }
        }
        public bool MoveNext()
        {
            if (StackFigures.Count <= 1)
            {
                Console.WriteLine("Error: There are 1 or less elements on the stack, add another and try again");
                return false;
            }
            PopFigures.Add(StackFigures.Pop());
            return true;
        }
        public void Reset()
        {
            int i = PopFigures.Count-1;
            while (i >= 0) StackFigures.Push(PopFigures[i--]);
            PopFigures.Clear();
            Console.WriteLine("\n----------------------------Установлено в начальное положение-------------------------\n");
        }
        public void Delete()
        {
            if(StackFigures.Count == 0)
                throw new Exception("Exception: Unable to delete item");
            StackFigures.Pop();
        }
        public void Delete(int count)
        {
            if(count>StackFigures.Count)
                throw new Exception($"Exception: you try to delete {count} elements but you can delete only {StackFigures.Count}");
            while(StackFigures.Count - count!=0)
                StackFigures.Pop();
        }
        public void DeleteAll() => StackFigures.Clear();

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)StackFigures).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)StackFigures).GetEnumerator();
        }
    }
}
