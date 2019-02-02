using KeyValueStore;
using System;

namespace ClientRead
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
            KVS database = new KVS(@"/var/tmp/database");

            foreach (Tuple<string, string> record in database.GetAllRecords())
            {
                Console.WriteLine(record.Item1 + ": " + record.Item2);
            }
            
        }
    }
}
