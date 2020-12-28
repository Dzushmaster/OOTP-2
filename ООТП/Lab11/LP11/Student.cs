using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP10
{
    class Student:IEnumerable
    {
        public List<Student> Students = new List<Student>();
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
        public int years;
        public string Adress
        {
            get
            {
                return adress;
            }
            private set
            {
                adress = value;
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
        //static string dress = "Студент обязан носить штаны";
        const string univers = "BSTU";

        public static int ALLSTUDENTS = 0;
        //-------------------------------------------------------------------------------------------------------
        public Student()
        {
            id = 0;
            secondName = "";
            name = "";
            dateOfBirth = "";
            adress = "";
            telephone = 0;
            faculty = "";
            curse = 0;
            group = 0;
            ALLSTUDENTS++;
        }
        //-------------------------------------------------------------------------------------------------------
        //public Student(int id = 314214251, string secondName = "Popov", string name = "Alex", string dateOFBirth = "12.12.2012",
        //    string adress = "Pushkin's street", int telephone = 789543213, string faculty = "radio electronics", int curse = 4, int group = 3)
        //{
        //    this.id = id;
        //    this.secondName = secondName;
        //    this.name = name;
        //    this.dateOfBirth = dateOFBirth;
        //    this.adress = adress;
        //    this.telephone = telephone;
        //    this.faculty = faculty;
        //    this.curse = curse;
        //    this.group = group;
        //    ALLSTUDENTS++;
        //}
        //-------------------------------------------------------------------------------------------------------
        public Student(int id, string secondName, string name, int years, string faculty, int group)//для аббитуриентов
        {
            if (!CheckParametres(secondName, name))
                Console.WriteLine("Ошибка: в конструкторе {0} находится неверное значение");
            else
            {
                this.id = id;
                this.secondName = secondName;
                this.name = name;
                this.years = years;
                this.faculty = faculty;
                this.group = group;
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
        //static Student()
        //{
        //    Console.WriteLine(dress);
        //}
        //-------------------------------------------------------------------------------------------------------
        void SumOfStudents(out int Sum, int group1, int group2)
        {
            Sum = group1 + group2;
        }

        void SumOfStudents(ref int Sum, int group1, int group2, int group3)
        {
            Sum = group1 + group2 + group3;
        }
        bool CheckParametres(string secondName, string name)
        {
            foreach (char symbol in secondName)
            {
                if (symbol >= '0' && symbol <= '9')
                    return false;
            }
            foreach (char symbol in name)
            {
                if (symbol >= '0' && symbol <= '9')
                    return false;
            }
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
            return "id: "+ id + "\nSecond name: " + SecondName + "\nName: " + Name + "\nYears old: " + years + "\nFaculty: " + Faculty + '\n';
        }
        public int AgeStudent()
        {
            int year = Int32.Parse(ToString());
            return 2020 - year;
        }
        //-------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------
        //public override bool Equals(object obj)
        //{
        //    if (obj == null)
        //        return false;
        //    if (obj as string == null)
        //        return false;
        //    Student stud = obj as Student;
        //    return stud.id == this.id && this.dateOfBirth == stud.dateOfBirth && this.secondName == stud.secondName;
        //}

        public override int GetHashCode()
        {
            return (this.secondName.Length - this.telephone / 3 + this.name.Length * 457) / (this.name.Length);
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Students).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Students).GetEnumerator();
        }

        //public int CompareTo(Student Years)
        //{
        //    int minYears = Int32.MaxValue;
        //    foreach (var item in Years)
        //        if (item.years < minYears)
        //            minYears = item.years;
        //    return minYears;
        //}
    }
    class University
    {
        public University() { }
        public University(int group, int size)
        {
            this.size = size;
            this.group = group;
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
        private int size;
        public int Size
        {
            get => size;
            set => size = value;
        }
    }
}
