using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        delegate int NumberChaner();
        class TestDeleg
        {
            static int num = 10;
            public static int AddNum=>++num;
        }
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add( "aas");
            list.Add(55);
            Console.Read();
        }
    }
}
