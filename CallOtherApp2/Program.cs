using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOtherApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var proc = new Process();

            // устанавливаем имя файла, который будет запущен в рамках данного процесса
            proc.StartInfo.FileName = "C:\\Users\\Nadya\\source\\repos\\System_programming\\WpfApp1\\bin\\Debug\\net8.0-windows\\WpfApp1.exe";

            // запускаем процесс
            proc.Start();

            // выводим имя процесса
            Console.WriteLine("Запущен процесс: " + proc.ProcessName);

            // ожидаем закрытия процесса
            proc.Kill();
            proc.WaitForExit();

            // выводим код, с которым завершился процесс
            Console.WriteLine("Процесс завершился с кодом: " + proc.ExitCode);
            Console.WriteLine("Текущий процесс имеет имя: " + Process.GetCurrentProcess().ProcessName);

            Console.ReadLine();

        }
    }
}
