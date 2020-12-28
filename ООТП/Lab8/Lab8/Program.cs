using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    //события:
    //Повысить и штраф
    //часть объектов подписать на одно событие, часть на 2.
    //Проверить состояние зарплаты после наступления событий

    //пять методов пользовательской обработки строки(удаление знаков препинания, добавление символов, замена на заглавные, удаление лишних пробелов)
    //использову стандартные типы делегатов организуйте алгоритм послед обработки строки, написанными вами методами.
    //
    delegate void MakeSth(string message);

    class Boss
    {
        Action<string> Str;
        Func<float,float> Lymba;
        int post;
        float calary;
        float calaryWithFines;
        string surname;
        public event MakeSth MakeFine;
        public event MakeSth MakeRaise;
        public Boss(int calary, int post, string surname)
        {
            this.calary = calary;
            this.calaryWithFines = calary;
            this.post = post;
            this.surname = surname;
        }
        public void MakeFin(float Fine)
        {
            if (Fine < 0)
                throw new Exception("Штраф не может иметь значение меньше нуля");
            Func<float,float>lymda = (fine) => fine = calary - calary * (fine / 100);
            calaryWithFines = calary - lymda(Fine);
            MakeFine?.Invoke($"Штраф сотруднику {surname}, который находится на должности {ChoosePost()}, составляет {Fine}% от зарплаты в {calary}$, то есть {calaryWithFines}$");
        }
        public void MakeRais(int number)
        {
            if (number < 0)
                throw new Exception("Уровень, на который происходит повышение не может иметь значение меньше нуля");
            if (number > (int)position.Flomaster)
                post = (int)position.Flomaster;
            else
                post += number;
            calary = calary * post;
            calaryWithFines = calaryWithFines * post;
            MakeRaise?.Invoke($"Произошло повышение сотрудника {surname}, на должность {ChoosePost()}, теперь он имеет зарплату {calary}$(без учета штрафов)");
        }
        string ChoosePost()
        {
            switch (post)
            {
                case 0:
                    return "стажер";
                case 1:
                    return "токарь";
                case 2:
                    return "мастер";
                case 3:
                    return "киломастер";
                case 4:
                    return "мегамастер";
                case 5:
                    return "фломастер";
            }
            return "Error";
        }
        public void ShowInformation()
        {
            Console.WriteLine($"Сотрудник {surname}\nДолжность: {ChoosePost()}\nЗарплата без учета штрафов: {calary}$\nЗарплата: {calary - calaryWithFines}$\n");
        }
        public string Surname
        {
            get { return surname; }
        }
        enum position { Trainee, Turner, master, kilomaster, Megamaster, Flomaster };
        public int Post
        {
            get { return post; }
        }

        //-------------------------Функции работы со строками--------------------------------
        public static void Comms(ref string input)//добавляет после всех слов
        {
            char[] charInput = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                    charInput[i] = ',';
            }
        }
        public static void DeleteSpace(ref string str)//лишние пробелы
        {
            str.Trim();
        }
        public static void AllUpReg(ref string str)
        {
            str.ToUpper();
        }
        public static void DelAllComms(ref string input)
        {
            char[] charInput = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ',')
                    charInput[i] = ' ';
            }
            input = new string(charInput);
        }
        public static void CommsToDots(ref string input)
        {
            char[] charInput = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ',')
                    charInput[i] = '.';
            }
            input = new string(charInput);
        }
    }

    class Program
    {
        static void Pause()
        {
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            string Text = "Повседневная   практика    показывает, что начало повседневной работы" +
                " по формированию позиции      обеспечивает    широкому кругу специалистов участие" +
                " в формировании форм    воздействия.";
            Console.WriteLine(Text + "\n");
            //Boss std0 = new Boss(200, 1, "Vitalya");
            Str str = Boss.Comms;
            str += Boss.AllUpReg;
            str += Boss.DeleteSpace;
            str += Boss.CommsToDots;
            str?.Invoke(ref Text);
            Console.WriteLine(Text);
            Boss std = new Boss(200, 1, "Vitalya");
            Boss std1 = new Boss(250, 2, "Valera");
            Boss std2 = new Boss(400, 3, "Igor");
            Boss std3 = new Boss(50, 0, "Andrey");
            Boss std4 = new Boss(220, 1, "Stas");
            Boss std5 = new Boss(1500, 5, "Gena");
            Boss std6 = new Boss(300, 2, "Artem");
            std.ShowInformation();
            std1.ShowInformation();
            std2.ShowInformation();
            std3.ShowInformation();
            std4.ShowInformation();
            std5.ShowInformation();
            std6.ShowInformation();

            std.MakeFine += A_MakeFine;
            std.MakeRaise += A_MakeFine;
            std.MakeRais(2);
            std.MakeFin(20);
            std.ShowInformation();
            
            std1.MakeRaise += A_MakeFine;
            std1.MakeRais(1);
            std1.ShowInformation();

            std2.MakeFine += A_MakeFine;
            std2.MakeFin(15);
            std2.ShowInformation();

            std3.MakeRaise += A_MakeFine;
            std3.MakeRais(3);
            std3.ShowInformation();

            std4.MakeFine += A_MakeFine;
            std4.MakeRaise += A_MakeFine;
            std4.MakeRais(1);
            std4.MakeFin(25);
            std4.ShowInformation();

            std5.MakeFine += A_MakeFine;
            std5.MakeRaise += A_MakeFine;
            std5.MakeRais(2);
            std5.MakeFin(20);
            std5.ShowInformation();

            std6.MakeRaise += A_MakeFine;
            std6.MakeFine += A_MakeFine;
            std6.MakeRais(2);
            std6.MakeFin(20);
            std6.ShowInformation();


            Pause();
        }

        private static void A_MakeFine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
