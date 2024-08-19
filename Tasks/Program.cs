using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 'Task' - рационально расходует память и ресурсы комп-ра при многопоточности
            Task task = new Task(Print); // 'Task' здесь - дочерний поток

            // task.RunSynchronously(); // должно быть до вызова 'Task'
            // пока не выполним один поток - дальше не пойдем
            
            task.Start();

            // task.Wait(); // дожидаемся завершения нашей параллельной ф-ции

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Основной поток");
                Task.Delay(1000).Wait();
            }  
        }

        static void Print() 
        {
            // основной поток
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Поток отдельно");
                Task.Delay(1000).Wait();
            }
        }
    }
}
