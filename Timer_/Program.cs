using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimerCallback callback = new TimerCallback(TimerMethod);
            Timer timer = new Timer(callback);
            timer.Change(2000, 500); // 1-ый - через сколько запустится, 2-ой - через сколько повторится
            Console.ReadKey();
        }
        public static void TimerMethod(object a)
        {
            Console.WriteLine("Hello in timer");
        }
    }
}
