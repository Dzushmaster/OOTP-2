using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace prob
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("<------------------- JSON ------------------->");
            int ar = 5;
            using (FileStream fs = new FileStream(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab13\LP13\1.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<int>(fs, ar);
                Console.WriteLine("Saved in JSON");
            }
            using (FileStream fs = new FileStream(@"C:\Users\User\Desktop\Универ\2 курс\ООТП\Lab13\LP13\1.json", FileMode.OpenOrCreate))
            {
                int newCar = await JsonSerializer.DeserializeAsync<int>(fs);
                Console.WriteLine(newCar);
            }

        }

    }
}
