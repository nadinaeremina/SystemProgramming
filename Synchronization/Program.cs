using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Synchronization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Random rand = new Random();

            bank.putCash(100000);

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(bank.ToString());
                Thread thread = new Thread(bank.getCash);
                thread.Name = $"Поток {i}";
                Console.WriteLine($"{thread.Name}");
                thread.Start(rand.Next(50000));            
            }

            Console.ReadKey();
        }
        public class Bank
        {
            private int balance;
            private readonly Mutex mutex = new Mutex();
            public void getCash(object moneyObj)
            {
                // 1 // синхронизация с помощью 'lock'

                //lock (this)
                //{
                //    if (moneyObj is int moneyCount)
                //    {
                //        if (balance - moneyCount >= 0)
                //        {
                //            balance -= moneyCount;
                //        }
                //        else
                //        {
                //            Console.WriteLine("Вы пытаетесь снять недостающую сумму!");
                //        }
                //    }
                //}

                // 2 // синхронизация с помощью 'mutex'

                mutex.WaitOne(); // ожидаем получения свободного места

                if (moneyObj is int moneyCount)
                {
                    if (balance - moneyCount >= 0)
                    {
                        balance -= moneyCount;
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно денег на счету!");
                    }
                }

                mutex.ReleaseMutex(); // освобождаем место в семафоре
            }
            public void putCash(int money)
            {
                balance += money;
            }
            public override string ToString()
            {
                return ($"Баланс составляет: {balance} рублей");
            }
        }
    }
}
