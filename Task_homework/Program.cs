using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_homework
{
    internal class Program
    {
        static bool Search(List<int> my_list, int search_elem)
        {
            foreach (int item in my_list)
            {
                if (item == search_elem)
                {
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            List<int> my_List1 = new List<int>();
            List<int> my_List2 = new List<int>();
            List<int> my_List3 = new List<int>();
            List<int> my_List4 = new List<int>();
            List<int> my_List5 = new List<int>();

            Random rand = new Random();
        
            for (int i = 0; i < 100; i++)
            {
                my_List1.Add(rand.Next(500));
            }

            for (int i = 0; i < 10; i++)
            {
                my_List2.Add(rand.Next(50));
            }

            for (int i = 0; i < 100; i++)
            {
                my_List3.Add(rand.Next(50));
            }

            for (int i = 0; i < 100; i++)
            {
                my_List4.Add(rand.Next(500));
            }

            for (int i = 0; i < 10; i++)
            {
                my_List5.Add(rand.Next(50));
            }

            Task<bool> task1 = new Task<bool>(() => Search(my_List1, 5));
            Task<bool> task2 = new Task<bool>(() => Search(my_List2, 10));
            Task<bool> task3 = new Task<bool>(() => Search(my_List3, 55));
            Task<bool> task4 = new Task<bool>(() => Search(my_List4, 55));
            Task<bool> task5 = new Task<bool>(() => Search(my_List5, 55));

            List<Task> my_Task = new List<Task>();

            my_Task.Add(task1);
            my_Task.Add(task2);
            my_Task.Add(task3);
            my_Task.Add(task4);
            my_Task.Add(task5);

            foreach (Task item in my_Task)
            {
                item.Start();
            }

            foreach (Task<bool> item in my_Task)
            {
                Console.WriteLine(item.Result);
            }
        }
    }
}
