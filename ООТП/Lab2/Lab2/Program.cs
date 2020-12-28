using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Lab2;
namespace Lab2
{
   
    //поле константу
    //свойства для всех полей класс(поля должны быть закрыты) для одного из свойств огриничить доступ по set
    //в одном их методов класса для работы с аргументами использовать ref- и out- параметры
    //создайте в классе статическое поле, хранящее количество созданных объектов(инкрементируется в конструкторе) и статический метод вывода инфморации о классе
    //сделайте класс partial
    // переопределяете методы класса Object: Equals, для сравнения объектов,  GetHashCode; для алгоритма вычисления хэша руководствуйтесь стандартными рекомендациями, ToString – вывода строки – информации об объекте. 
    partial class PrintClass
    {
        public static string PrintStudent()
        {
            return "University {0}\nid: {1}\nFull Name: {2} {3} {4}\nDate of birth: {5}\nAdress: {6}\nTelephone: {7}\nFaculty: {8}\nCurse: {9}\nGroup: {10}\n";
        }
    }
    class Student
    {
        //создайте несколько объектов вашего типа.Выполните вызов конструкторов, свойств, методов, сравнение объекты, проверьте тип созданного объекта и т.п.  3
        // Создайте массив объектов вашего типа. И выполните задание, выделенное курсивом в таблице
        //Создайте и выведите анонимный тип(по образцу вашего класса). 
        public readonly int id;
        private string secondName;
        public string SecondName
        {
            get
            {
                return secondName;
            }
            set
            {
                secondName = value;
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private string patronymic;
        public string Patronymic
        {
            get
            {
                return patronymic;
            }
            set
            {
                patronymic = value;
            }
        }
        private string dateOfBirth;
        public string DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
            }
        }
        private string adress;
        public string Adress
        {
            get
            {
                return adress;
            }
            private set
            {
                adress= value;
            }
        }
        private int telephone;
        public int Telephone
        {
            get
            {
                return telephone;
            }
            set
            {
                telephone = value;
            }
        }
        private string faculty;
        public string Faculty
        {
            get
            {
                return faculty;
            }
            set
            {
                faculty = value;
            }
        }
        private int curse;
        public int Curse
        {
            get
            {
                return curse;
            }
            set
            {
                curse = value;
            }
        }
        private int group;
        public int Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }
        static string dress = "Студент обязан носить штаны";
        const string univers = "BSTU";

        public static int ALLSTUDENTS = 0;
        public void PrintStudent(Student stud)
        {
            Console.WriteLine(PrintClass.PrintStudent(),univers,stud.id,stud.secondName,stud.name,stud.patronymic,stud.dateOfBirth,stud.adress,stud.telephone, stud.faculty, stud.curse, stud.group);
        }
        //-------------------------------------------------------------------------------------------------------
        public Student()
        {
            id = 0;
            secondName = "";
            name = "";
            patronymic = "";
            dateOfBirth = "";
            adress = "";
            telephone = 0;
            faculty = "";
            curse = 0;
            group = 0;
            ALLSTUDENTS++;
        }
        //-------------------------------------------------------------------------------------------------------
        public Student(int id = 314214251, string secondName = "Popov", string name = "Alex", string patronymic = "Vasilevich", string dateOFBirth = "12.12.2012",
            string adress = "Pushkin's street", int telephone = 789543213, string faculty = "radio electronics", int curse = 4, int group = 3)
        {
            this.id = id;
            this.secondName = secondName;
            this.name = name;
            this.patronymic = patronymic;
            this.dateOfBirth = dateOFBirth;
            this.adress = adress;
            this.telephone = telephone;
            this.faculty = faculty;
            this.curse = curse;
            this.group = group;
            ALLSTUDENTS++;
        }
        //-------------------------------------------------------------------------------------------------------
        public Student(int id, string secondName, string name, string patronymic, string dateOfBirth)//для аббитуриентов
        {
            if (!CheckParametres(secondName, name, patronymic, dateOfBirth))
                Console.WriteLine("Ошибка: в конструкторе {0} находится неверное значение");
            else
            {
                this.id = id;
                this.secondName = secondName;
                this.name = name;
                this.patronymic = patronymic;
                this.dateOfBirth = dateOfBirth;
                ALLSTUDENTS++;
            }
        }
        //-------------------------------------------------------------------------------------------------------
        Student(int id) 
        {
            this.id = id;
        }
        //-------------------------------------------------------------------------------------------------------
        public Student GetID(int id)
        {
            return new Student(id);
        }
        //-------------------------------------------------------------------------------------------------------
        static Student()
        {
            Console.WriteLine(dress);
        }
        //-------------------------------------------------------------------------------------------------------
        void SumOfStudents(out int Sum,int group1, int group2)
        {
            Sum = group1 + group2;
        }

        void SumOfStudents(ref int Sum, int group1, int group2, int group3)
        {
            Sum = group1 + group2 + group3;
        }
        bool CheckParametres(string secondName, string name, string patronymic, string dateOfBirth)
        {
            foreach(char symbol in secondName)
            {
                if (symbol >= '0' && symbol <= '9')
                    return false;
            }
            foreach (char symbol in name)
            {
                if (symbol >= '0' && symbol <= '9')
                    return false;
            }
            foreach (char symbol in patronymic)
            {
                if (symbol >= '0' && symbol <= '9')
                    return false;
            }
            int dotes = 0;
            if (dateOfBirth.Length !=10)
                return false;
            foreach (char symbol in dateOfBirth)
            {
                if ((symbol < '0' || symbol > '9') && symbol != '.')
                    return false;
                if (symbol == '.')
                    dotes++;
            }
            if (dotes < 2 || dotes > 2)
                return false;
            return true;
        }
        public static bool CheckNumbers(string Numbers)
        {
            if (!Int32.TryParse(Numbers, out int Number))
            {
                Console.WriteLine("Ошибка {0} содержит не только цифры", Numbers);
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            string[] fullDate = this.dateOfBirth.Split('.');
            return fullDate[2];
        }
        public int AgeStudent()
        {
            int year = Int32.Parse(ToString());
            return 2020 - year;
        }
        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj as Student == null)
                return false;
            Student stud = obj as Student;
            return stud.id == this.id && this.dateOfBirth == stud.dateOfBirth && this.secondName == stud.secondName;
        }
        
        public override int GetHashCode()
        {
            return (this.secondName.Length - this.telephone / 3 + this.name.Length*457)/(this.name.Length); 
        }
        
    }

    class Program
    {
        static void Pause()
        {
            Console.Read();
        }
        static void Main()
        {
            Student student1 = new Student(523412, "Valeriy", "Lex", "Asdeqwe", "12.05.2020");
            Student student2 = new Student(12345);
            Student student3 = new Student();
            student3.Curse = 3;
            student3.DateOfBirth = "03.10.2003";
            student3.Faculty = "radio electronics";
            student3.Group = 3;
            student3.Name = "Fedor";
            student3.SecondName = "Ant";
            student3.Patronymic = "Sparcle";
            student3.Telephone = 235633525;
            student3.PrintStudent(student1);
            student3.PrintStudent(student2);
            //-------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------
            if (student2.Equals(student1))
                Console.WriteLine("They are equals");
            else
                Console.WriteLine("They are not equals");
            //-------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------
            Console.WriteLine("Type of student 3 = " + student3.GetType());
            Student[] fourStudents = new Student[4];
            for(int i =0;i<4;i++)
            {
                fourStudents[i] = new Student();
            }
            string[] names = { "Arkady", "Vladimir", "Diana", "Valentina" };
            string[] secondNames = { "Birch", "Brown", "Farrell", "Bradberry" };
            string[] patronymices = { "Aleksandrovich", "Anatolyevich", "Valeryevna", "Evgen`evna" };
            string[] faculty = {"radio electionics", "information technologies", "forestry", "linguistic"};
            string[] dates = {"14.05.2001","17.09.2002","17.01.2000","10.06.1998"};
            //-------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------
            Random rnd = new Random(); 
            for (int i =0;i<4;i++)
            {
                fourStudents[i].Name = names[i];
                fourStudents[i].SecondName = secondNames[i];
                fourStudents[i].Patronymic = patronymices[i];
                fourStudents[i].Faculty = faculty[rnd.Next(1, 4)];
                fourStudents[i].Group = rnd.Next(1, 13);
                fourStudents[i].Curse = rnd.Next(1, 4);
                fourStudents[i].Telephone = rnd.Next(123456789, 999999999);
                fourStudents[i].DateOfBirth = dates[i];
            }
            //-------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------
            Student[] sevenStudents = new Student[7];
            fourStudents.CopyTo(sevenStudents,0);
            sevenStudents[4] = student1;
            sevenStudents[5] = student2;
            sevenStudents[6] = student3;
            PrintClass a = new PrintClass();
            //-------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------
            a.PrintNumberStudents(Student.ALLSTUDENTS);
            //-------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------
            for (int i =0;i<Student.ALLSTUDENTS;i++)
            {
                student1.PrintStudent(sevenStudents[i]);
            }


            Console.WriteLine("Input name of faculty");
            string Snumber = Console.ReadLine();
            Console.WriteLine("----------------------Вывожу информацию--------------------------");
            foreach (Student stud in sevenStudents)
            {
                if (stud.Faculty == Snumber)
                    student1.PrintStudent(stud);
            }
            Console.WriteLine("Input number of group");
            Snumber = Console.ReadLine();
            if (!Student.CheckNumbers(Snumber))
            {
                Console.WriteLine("Ошибка, введена не цифра");
            }
            int number = Int32.Parse(Snumber);
            Console.WriteLine("----------------------Вывожу информацию--------------------------");
            for (int i = 0; i < Student.ALLSTUDENTS; i++)
                if (sevenStudents[i].Group == number)
                    student1.PrintStudent(sevenStudents[i]);


            Console.WriteLine("Input number of student to calculation his years old");
            Snumber = Console.ReadLine();
            number = Int32.Parse(Snumber);
            Console.WriteLine("student: {0} is {1} years old",number, sevenStudents[number].AgeStudent());

            var std = new Student(12341241);
            std.PrintStudent(std);

            int NewID = student2.GetHashCode();
            student2 = student2.GetID(NewID);
            NewID = student1.GetHashCode();
            student1 = student1.GetID(NewID);
            Pause();
        }

    }
}
