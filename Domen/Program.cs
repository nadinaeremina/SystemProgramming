using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Метод main выполняется в домене {AppDomain.CurrentDomain.Id}");

            var domain = AppDomain.CreateDomain("Second Domain");
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            string typeName = typeof(MyClass).FullName;
            var handle = domain.CreateInstance(assemblyName, typeName);
            var instance = handle.Unwrap() as MyClass;

            Console.WriteLine(instance);

            Console.ReadKey();
        }

        // позволяет работать с разными доменами
        class MyClass: MarshalByRefObject
        {
            public override string ToString()
            {
                return $"Метод main выполняется в домене {AppDomain.CurrentDomain.Id}";
            }
        }
    }
}
