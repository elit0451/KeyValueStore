using KeyValueStore;
using System;

namespace ClientWrite
{
    public class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
            Console.ReadKey();
        }

        private void Run()
        {
            KVS database = new KVS(@"\usr\temp");
            database.SetData("ananas", "3");
            database.SetData("banana", "23");
            database.SetData("cranberry", "5809");
            database.SetData("ananas", "42");
            database.SetData("date", "78");

            Console.WriteLine("Done");

        }
    }
}
