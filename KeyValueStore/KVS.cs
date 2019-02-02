using System;
using System.Collections.Generic;
using System.IO;

namespace KeyValueStore
{
    public class KVS
    {
        private string filePath = "";
        private Dictionary<string, long> hashMap;
        public KVS(string path)
        {
            filePath = path;
            hashMap = new Dictionary<string, long>();

            if (!File.Exists(filePath))
            {
                using (FileStream stream = File.Create(filePath))
                {
                    Console.WriteLine("File created");
                }
            }
            else
            {
                PopulateHashMap();
                Console.WriteLine("File read");
            }

        }

        private void PopulateHashMap()
        {
            using (BinaryReader binaryReader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                string index = "";
                long pos = 0;
                char c;
                bool flag = true;

                while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                {
                    c = binaryReader.ReadChar();

                    if (c == ',' && flag)
                    {
                        flag = false;

                        if (hashMap.ContainsKey(index))
                            hashMap[index] = pos;
                        else
                            hashMap.Add(index, pos);

                        index = string.Empty;

                    }

                    if (flag)
                    {
                        index += c;
                    }

                    if(c == '\r' && !flag)
                    {
                        pos = binaryReader.BaseStream.Position;
                        flag = true;
                    }
                }
            }
        }
        public void SetData(string index, string value)
        {
            long lastOffset = new FileInfo(filePath).Length;
            if (!hashMap.ContainsKey(index))
                hashMap.Add(index, lastOffset);
            else
                hashMap[index] = lastOffset;

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.Write(index + "," + value + "\r");
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public Tuple<string, string> GetData(string index)
        {
            long offset = hashMap[index];
            string value = "";

            try
            {
                using (BinaryReader binaryReader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    binaryReader.BaseStream.Seek(offset + index.Length + 1, SeekOrigin.Begin);
                    char c;

                    do
                    {
                        c = binaryReader.ReadChar();
                        value += c;
                    } while (c != '\r' && binaryReader.BaseStream.Position != binaryReader.BaseStream.Length);
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }

            return Tuple.Create(index, value);
        }

        public List<Tuple<string, string>> GetAllRecords()
        {
            List<Tuple<string, string>> listOfRecords = new List<Tuple<string, string>>();

            foreach(string key in hashMap.Keys)
            {
                listOfRecords.Add(GetData(key));
            }

            return listOfRecords;
        }

    }
}
