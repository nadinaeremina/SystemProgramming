//var list = Enumerable.Range(8, 100);

//// 'AsParallel()' - все, что будет вып-ся далее - будет вып-ся параллельно
//var new_list = list.AsParallel().Select(x => x * x);

//// выводим на экран с помощью 
//foreach (var item in new_list)
//{
//    Console.WriteLine(item);
//}

// homework
var range = Enumerable.Range(5, 25);

var new_range = range.AsParallel().Select(x => x * x * x);

foreach (var item in new_range)
{
    Console.WriteLine(item);
}