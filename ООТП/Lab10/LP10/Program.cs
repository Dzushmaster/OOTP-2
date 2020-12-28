using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP10
{
    class LINQ
    {
        string[] Months = { "June", "July", "May", "December", "November", "September", "October", "January", "February", "March", "April", "August" };
        public void sizeMonthN(int n)
        {
            if (n < 0)
                throw new Exception("Введите положительное число");
            var selectedMonths = from month in Months where month.Length == n select month;         //var = IEnumarable<string>
            foreach (var item in selectedMonths)
            {
                Console.WriteLine(item);
            }
        }
        public void SumWintMonths()
        {
            var selectedMonths = from month in Months
                                 where (month.Equals("June") || month.Equals("July")
                                 || month.Equals("August") || month.Equals("January") || month.Equals("February") || month.Equals("December"))
                                 select month;
            foreach (var item in selectedMonths)
            {
                Console.WriteLine(item);
            }
        }
        public void AlphPrint()
        {
            var selectedMonths = from month in Months orderby month select month;
            foreach (var item in selectedMonths)
            {
                Console.WriteLine(item);
            }
        }
        public void WithSymb()
        {
            var selectedMonths = from month in Months where (month.Contains('u') && month.Length >= 4) select month;
            foreach (var item in selectedMonths)
            {
                Console.WriteLine(item);
            }
        }
        public void Students()
        {

            Student students = new Student();
            students.Students.Add(new Student(1234, "Chess", "Andrey", 20, "Radio electronics", 7));
            students.Students.Add(new Student(1235, "Board", "Eugene", 18, "Radio electronics", 7));
            students.Students.Add(new Student(1236, "Vine", "Andrey", 17, "Radio electronics", 12));
            students.Students.Add(new Student(1237, "Bag", "Old", 35, "Med", 3));
            students.Students.Add(new Student(1238, "Chocolate", "Big", 37, "POM", 3));
            students.Students.Add(new Student(1239, "Mr", "Stark", 33, "Med", 5));
            students.Students.Add(new Student(1240, "Parker", "Piter", 17, "POM", 8));
            students.Students.Add(new Student(1241, "Luk", "I am your FATHER", 19, "Med", 8));
            SpecAlph(students, "Med");
            GroupFaculty(students, "Radio electronics", 7);
            Yongest(students);
            AmountStudents(students, 8);
            FirstWithName(students, "Andrey");
            Super(students);
            List <University> group = new List<University>();
            group.Add(new University(3, 12));
            group.Add(new University(4, 17));
            group.Add(new University(5, 18));
            group.Add(new University(6, 20));
            WithJoin(students, group);
        }
        //--------------------------------------------------------------------------
        public void SpecAlph(Student students, string faculty)
        {
            Console.WriteLine("\n<---------------------------------- Заданной специальности по алфавиту ---------------------------------->");
            var student = from s in students.Students where (s.Faculty == faculty) orderby s.SecondName select s;
            foreach (var item in student)
            {
                Console.WriteLine(item);
            }
        }
        //------------------------------------------------------------------------
        public void GroupFaculty(Student students, string faculty, int group)
        {
            Console.WriteLine("\n<---------------------------------- Заданной группы и факультета ---------------------------------->");
            var student = from s in students.Students where (s.Faculty == faculty && s.Group == @group) select s;
            foreach (var item in student)
            {
                Console.WriteLine(item);
            }
        }
        //------------------------------------------------------------------------
        public void Yongest(Student students)
        {
            Console.WriteLine("\n<---------------------------------- Заданной группы и факультета ---------------------------------->");
            var student = (from s in students.Students select s.years).Min();
            var youngestStudent = from s in students.Students where s.years == student select s;
            foreach (var item in youngestStudent)
            {
                Console.WriteLine(item);
            }
        }
        //------------------------------------------------------------------------
        public void AmountStudents(Student students, int group)
        {
            Console.WriteLine("\n<---------------------------------- Количество студентов заданной группы упорядоченных по фамилии ---------------------------------->");
            var student = from s in students.Students where s.Group == @group select s;
            int amountStudent = (from s in students.Students where s.Group == @group orderby s.SecondName select s).Count();//метод расширения .Count();
            Console.WriteLine("Всего " + amountStudent + " студентов в этой группе");
            foreach (var item in student)
            {
                Console.WriteLine(item);
            }
        }
        //------------------------------------------------------------------------
        public void FirstWithName(Student students, string name)
        {
            Console.WriteLine("\n<---------------------------------- Первый студент с таким именем ---------------------------------->");
            var student = (from s in students.Students where s.Name == name select s).First();//метод расширения .First();
            Console.WriteLine(student.ToString());
        }
        public void Super(Student students)
        {
            var student = (from s in students.Students where s.years > 18 orderby s.SecondName group s by s.Group);
            int count = student.Count();
            var stud = student.Take(1);
            Console.WriteLine("\n<---------------------------------- Супер запрос ---------------------------------->");
            foreach (var item in student)
            {
                foreach (var item2 in item)
                {
                    Console.WriteLine(item2);
                }
            }
            Console.WriteLine("--------------------");
            foreach (var item in stud)
            {
                foreach (var item2 in item)
                {
                    Console.WriteLine(item2);
                }
            }
        }
        public void WithJoin(Student students,List<University> group)
        {
            Console.WriteLine("\n<---------------------------------- Запрос с Join ---------------------------------->");
            var res = from s in students.Students join gr in @group on s.Group equals gr.Group select new { Group = s.Group, CountGroup = gr.Group };
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
    }
    //запрос - выбрать всех начиная с какого-то возраста(where),сгруппировать по номеру группы, упорядочить по алфавиту, посчитать количество элементов(агрегиваровние) 

    class Program
    {
        static void Main(string[] args)
        {
            LINQ a = new LINQ();
            Console.WriteLine("<---------------------------------- Количество букв в месяце = n ---------------------------------->");
            a.sizeMonthN(4);
            Console.WriteLine("\n<---------------------------------- Летние и зимние месяцы ---------------------------------->");
            a.SumWintMonths();
            Console.WriteLine("\n<---------------------------------- Вывод в алфавитном порядке ---------------------------------->");
            a.AlphPrint();
            Console.WriteLine("\n<---------------------------------- Есть u и более 4 символов в названии ---------------------------------->");
            a.WithSymb();
            a.Students();
            Console.ReadLine();
        }
    }
}
