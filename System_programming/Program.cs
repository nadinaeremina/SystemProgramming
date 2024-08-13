using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices; // подключаем для 'DllImport' // позволяет вызывать фуекционал из неуправляемого кода

namespace System_programming
{
    internal class Program
    {
        internal static class NativeMethods
        {
            [DllImport("msvcrt.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
            // 'Cdecl' - можем работать c 'params'
            // есть также: 'StdCall' - очистится стек, 'ThisCall', 'FastCall' - кинет 'Exception'
            internal static extern int printf(string format, int i, double d);

            [DllImport("msvcrt.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
            internal static extern int printf(string format, int i, string s);
        }

        // 'DllImportAttribute' - доп. приписка для св-в
        // указывает, что атрибутированный метод предоставляется неуправляемой динамической библиотекой (DLL) как статич. точка входа

        [DllImport("user32.dll", EntryPoint = "MessageBox", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        // 'CharSet' - кодировка (Ansi, Unicode)
        // 'EntryPoint' - указывает имя или порядковый номер точки входа DLL, которую необходимо вызвать
        // Псевдоним для нашего вызова
        static extern int NewMessageBox(IntPtr hWnd, string text, string caption, int options);

        [DllImport("user32.dll")]
        static extern int MessageBox(IntPtr hWnd, string text, string caption, int options);
        // 'DllImport' - это класс, наследуемый от класса 'Attribute'

        static void Main(string[] args)
        {
            // 1
            //NewMessageBox(IntPtr.Zero, "Hello!", "My Message", 0);

            //MessageBox(IntPtr.Zero, new Product { Title = "Молоко", Count = 15 }.ToString(), "Message", 0);
            //MessageBox(IntPtr.Zero, new Product { Title = "Колбаса", Count = 5 }.ToString(), "Message", 0);
            //MessageBox(IntPtr.Zero, new Product { Title = "МХлеб", Count = 10 }.ToString(), "Message", 0);

            //2
            //NativeMethods.printf("\nPrint params: %i %f", 99, 99.99);
            //NativeMethods.printf("\nPrint params: %i %s", 99, "abcd");

            // 3
            Plus(1, 2, 4);
            Plus(2, 2, 1, 3);
        }

        public static int Plus(params int[] numbers)
        {
            // 1
            // return numbers[0] + numbers[1];

            //2 
            int sum = 0;
            foreach (var item in numbers)
                sum += item;

            return sum;
        }
    }
}
