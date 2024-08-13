using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads__join
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var thread = new Thread(Method);
            Console.WriteLine("Сейчас будет запущен поток");

            thread.Start();
            Thread.Sleep(200);
            Console.WriteLine("Ожидание завершения работы потока");
            thread.Join();
            Console.WriteLine("Завершение работы программы");
        }

        static void Method()
        {
            Console.WriteLine("Поток работает");
            Thread.Sleep(2000);
            Console.WriteLine("Поток завершил работу");
        }
    }
}
