using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // обращаемся к статич св-ву Thread и он возвращает нам текущий поток
            Thread currentThread = Thread.CurrentThread;

            // получаем имя потока
            Console.WriteLine($"Имя потока: {currentThread.Name}");
            currentThread.Name = "Метод Main";
            Console.WriteLine($"Имя потока: {currentThread.Name}");

            Console.WriteLine($"Запущен ли поток: {currentThread.IsAlive}");
            Console.WriteLine($"Id потока: { currentThread.ManagedThreadId}");
            Console.WriteLine($"Приоритет потока: {currentThread.Priority}"); // по умолчанию - 'Normal'
            Console.WriteLine($"Статус потока: {currentThread.ThreadState}");

            // создаем новый поток
            var myThread1 = new Thread(Print); // передаем экземпляр делегата
            var myThread2 = new Thread(new ThreadStart(Print)); // создаем экземпляр делегата и передаем туда ф-цию
            var myThread3 = new Thread(() => Console.WriteLine("Hello, Threads")); // передаем анонимную ф-цию - лямбду
            // 'ThreadStart' - это делегат

            //myThread1.Start();
            //myThread2.Start();
            //myThread3.Start();

            var myThread4 = new Thread(Print2); // передаем экземпляр делегата
            //myThread4.Start(1000);

            var param = new Parametr
            {
                Value1 = 1,
                Value2 = 2,
            };

            // запускаем поток
            myThread4.Start(param);

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Я выполняюсь в основном потоке");
                Thread.Sleep(1000);
            }

            // преобразование значимого типа к ссылочному - 'boxing' - упаковка - дорогая операция
            int t = 1000;
            object t1 = t;

            // преобразование ссылочного типа к значимому - 'unboxing' - распаковка - еще дороже
            int t3 = (int)t1;
        }

        static void Print()
        {
            // Console.WriteLine("Hello, Threads");

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Я выполняюсь во втором потоке");
                Thread.Sleep(1000); // заглушка // замедление программы
            }
        }

        // можем передать пар-р
        static void Print2(object obj)
        {
            // Console.WriteLine("Hello, Threads");

            // чтобы не происходило упаковки и распаковки -проверяем
            // идентично 
            //if (obj is int)
            //    int number1 = (int)obj;
            // далее идет безопасная проверка
            if (obj is int number) // если обьект типа 'int' - то делаем преобразование в тип 'int' и даем ему название
            {
                for (int i = 0; i < number; i++)
                {
                    Console.WriteLine("Я выполняюсь во втором потоке");
                    Thread.Sleep(1000);
                }
            }
            if (obj is Parametr param)
            {
                for (int i = 0; i < param.Value2; i+=param.Value1)
                {
                    Console.WriteLine("Я выполняюсь во втором потоке");
                    Thread.Sleep(1000);
                }
            }
            //else
            //    throw new Exception();

            // либо можно сделать преобразование вместо 'if'
            // int number = (int)obj; // если передадим в ф-цию строку - здесь будет ошибка
        }

        // если мы хотим передавать несколько пар-ов - создаем класс - упаковываем пар-ра в класс
        class Parametr
        {
            public int Value1 { get; set; }
            public double Value2 { get; set; }
        }
    }
}
