using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using LP10;
using LPLab4;

namespace LP11
{
    static class Reflector
    {
        static public string pole;
        public static string GetAssemblyInfo(Type t) => t.Assembly.GetName().Name;
        public static bool ThereIsPublicConstructors(Type t)
        {
            var a = t.GetConstructors();
            return a.Length > 0;
        }
        public static IEnumerable<string> ThereIsPublicMethods(Type t)=> from s in t.GetMethods() select s.Name;
        public static IEnumerable<string> GetFieldsInfo(Type t)=> from s in t.GetFields() select s.Name;
        public static IEnumerable<string> GetInterfaceInfo(Type t) => from s in t.GetInterfaces() select s.Name;
        public static void GetParametrsByName(Type type)
        {
            Console.WriteLine("Введите полное имя класса");
            string className = Console.ReadLine();
            Type Type = Type.GetType(className,false,false);
            if(Type == null)
            {
                Console.WriteLine("Такого типа не найдено");
                return;
            }
            var methods = type.GetMethods();
            var result = methods.Where(a => a.GetParameters().Where(t => t.ParameterType == type).Count() != 0);
            Console.WriteLine($"Все методы, содержащие заданный параметр {type.Name}: ");
            foreach (var el in result)
                Console.WriteLine(el.Name);
        }
        public static void Invoke(object t, string metodName, object[] arr)
        {
            MethodInfo m = t.GetType().GetMethod(metodName);
            m.Invoke(t, arr);
        }
        public static object Create(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Student student = new Student();
            StreamWriter Writer = new StreamWriter(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab12\LP11\Info.txt",false);
            Writer.WriteLine("<---------------------------------------------- Class 1 ---------------------------------------------->");

            Writer.WriteLine(Reflector.GetAssemblyInfo(typeof(Student)));
            Writer.WriteLine("----------------------------------------------------");

            if (Reflector.ThereIsPublicConstructors(typeof(Student)))
                Writer.WriteLine("There is public constructors");
            else
                Writer.WriteLine("There isn't public constructors");
            Writer.WriteLine("----------------------------------------------------");

            var PublicMethods1 = Reflector.ThereIsPublicMethods(typeof(Student));
            foreach (var item in PublicMethods1)
            {
                Writer.WriteLine("Имя метода: " + item);
            }
            var FieldsInfo1 = Reflector.GetFieldsInfo(typeof(Student));
            Writer.WriteLine("----------------------------------------------------");
            foreach (var item in FieldsInfo1)
            {
                Writer.WriteLine("Имя поля: " + item);
            }
            Writer.WriteLine("----------------------------------------------------");
            Reflector.GetParametrsByName(typeof(string));
            Console.WriteLine();

            Writer.WriteLine("<---------------------------------------------- Class 2 ---------------------------------------------->");

            Transformer transformer = new Transformer();
            Writer.WriteLine(Reflector.GetAssemblyInfo(typeof(Transformer)));
            Writer.WriteLine("----------------------------------------------------");

            if (Reflector.ThereIsPublicConstructors(typeof(Transformer)))
                Writer.WriteLine("There is public constructors");
            else
                Writer.WriteLine("There isn't public constructors");
            Writer.WriteLine("----------------------------------------------------");

            var PublicMethods2 = Reflector.ThereIsPublicMethods(typeof(Transformer));
            foreach (var item in PublicMethods2)
            {
                Writer.WriteLine("Имя метода: " + item);
            }
            var FieldsInfo2 = Reflector.GetFieldsInfo(typeof(Transformer));
            Writer.WriteLine("----------------------------------------------------");
            foreach (var item in FieldsInfo2)
            {
                Writer.WriteLine("Имя поля: " + item);
            }
            Writer.WriteLine("----------------------------------------------------");
            Reflector.GetParametrsByName(typeof(int));


            Writer.WriteLine("<---------------------------------------------- Standart type ---------------------------------------------->");
            
            List<int> list = new List<int> { 2, 3, 5, 8 };
           
            Writer.WriteLine(Reflector.GetAssemblyInfo(list.GetType()));
            Writer.WriteLine("----------------------------------------------------");

            if (Reflector.ThereIsPublicConstructors(list.GetType()))
                Writer.WriteLine("There is public constructors");
            else
                Writer.WriteLine("There isn't public constructors");
            Writer.WriteLine("----------------------------------------------------");

            var PublicMethods3 = Reflector.ThereIsPublicMethods(list.GetType());
            foreach (var item in PublicMethods3)
            {
                Writer.WriteLine("Имя метода: " + item);
            }
            var FieldsInfo3 = Reflector.GetFieldsInfo(list.GetType());
            Writer.WriteLine("----------------------------------------------------");
            foreach (var item in FieldsInfo3)
            {
                Writer.WriteLine("Имя поля: " + item);
            }
            Writer.WriteLine("----------------------------------------------------");

            Writer.WriteLine("<---------------------------------------------- Invoke ---------------------------------------------->");

            FileStream File = new FileStream(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab12\LP11\File.txt", FileMode.Open);
            StreamReader ReadFile = new StreamReader(File);
            object[] parametr= new object[1];
            parametr[0] = Convert.ToInt32(ReadFile.ReadLine());
            Reflector.Invoke(list,"Add",parametr);
            parametr[0] = Convert.ToInt32(ReadFile.ReadLine());
            Reflector.Invoke(list, "Add", parametr);
            foreach (var item in list)
            {
                Writer.WriteLine(item);
            }
            File.Close();
            Console.WriteLine("\n<---------------------------------------------- Creater ---------------------------------------------->");
            object stud = Reflector.Create(typeof(Transformer));
            Console.WriteLine(stud.GetType());
            Writer.Close();
            Console.Read();
        }
    }
}
