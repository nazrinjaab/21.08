using static _21._08.Models.CustomInit;

namespace _21._08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();

            list.Add(10);
            list.AddRange(20, 30, 40);

            Console.WriteLine(list);           
            Console.WriteLine("Count: " + list.Count);       
            Console.WriteLine("Capacity: " + list.Capacity); 

            list.Remove(20);
            Console.WriteLine(list);          

            list.RemoveRange(10, 40);
            Console.WriteLine(list);           

            list[0] = 99;
            Console.WriteLine(list[0]);       
        }
    }
}
