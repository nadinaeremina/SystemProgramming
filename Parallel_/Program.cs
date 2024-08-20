//// 1 // Invoke
//Parallel.Invoke(
//    Print,
//    () =>
//    {
//        Console.WriteLine($"Выполняется {Task.CurrentId}");
//        Thread.Sleep(3000);
//    },
//    () => Square(10)
//); // передаем в 'Invoke' функцию, можно лямбду

//void Print()
//{
//    Console.WriteLine($"Выполняется {Task.CurrentId}");
//    Thread.Sleep(3000);
//}

//void Square(int value)
//{
//    Console.WriteLine($"Выполняется {Task.CurrentId}");
//    Thread.Sleep(3000);
//    Console.WriteLine(value + value);
//}

//// 2 // For
//Parallel.For(1, 10, Factorial);

//void Factorial(int value)
//{
//    Console.WriteLine($"Выполняется {Task.CurrentId}");

//    int res = 1;

//    for (int i = 0; i < value; i++)
//    {
//        res *= i;
//    }

//    Thread.Sleep(2000);
//    Console.WriteLine(res);
//}

// 3 // ForEach
//Parallel.ForEach(new List<int> { 1, 2, 3, 4, 5, 6 }, Fibonacci);

//void Fibonacci(int n)
//{
//    Console.WriteLine($"Id текущей задачи: {Task.CurrentId}");

//    int fib1 = 0;
//    int fib2 = 1;
//    int fibRes = 1;

//    for (int i = 0; i < n; i++)
//    {
//        fibRes = fib1 + fib2;
//        fib1 = fib2;
//        fib2 = fibRes;
//    }

//    Thread.Sleep(1000);

//    Console.WriteLine(fibRes);
//}

//// 4 // Parallel_loop
//var parallelloopResult = Parallel.For(1, 10, Fibonacci2);

//if (!parallelloopResult.IsCompleted)
//{
//    Console.WriteLine($"Параллельное вычисление приостановлено {parallelloopResult.LowestBreakIteration}");
//}

//void Fibonacci2(int n, ParallelLoopState parallelLoopState)
//{
//    Console.WriteLine($"Id текущей задачи: {Task.CurrentId}");

//    int fib1 = 0;
//    int fib2 = 1;
//    int fibRes = 1;

//    for (int i = 0; i < n; i++)
//    {
//        if (fibRes == 13)
//        {
//            parallelLoopState.Break();
//        }

//        fibRes = fib1 + fib2;
//        fib1 = fib2;
//        fib2 = fibRes;
//    }

//    Thread.Sleep(1000);

//    Console.WriteLine(fibRes);
//}

// 5 // Homework
Parallel.Invoke(() => Fibonacci3(8), () => Fibonacci3(4), () => Fibonacci3(10),
() => Fibonacci3(6), () => Fibonacci3(12));

void Fibonacci3(int number)
{
    Console.WriteLine($"Id текущей задачи: {Task.CurrentId}");

    int value;
    int fib1 = 0;
    int fib2 = 1;
    int fibRes = 1;

    if (number == 1)
    {
        value = fibRes;
    }
    else
    {
        for (int i = 1; ;)
        {
            fibRes = fib1 + fib2;
            i++;

            if (i == number)
            {
                value = fibRes;
                break;
            }

            fib1 = fib2;
            fib2 = fibRes;
        }
    }

    Thread.Sleep(1000);

    Console.WriteLine(value);
}
