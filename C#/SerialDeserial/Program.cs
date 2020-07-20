using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerialDeserial
{
    class Program
    {
        static void Main(string[] args)
        {


            /*
            string sourceDirectory = @"C:\current";
            string archiveDirectory = @"C:\archive";
            try
            {
                var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt");
                foreach (string currentFiles in txtFiles)
                {
                    string fileName = currentFiles.Substring(sourceDirectory.Length + 1);
                    Directory.Move(currentFiles, Path.Combine(archiveDirectory, fileName));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            */
            /*string path = @"C:\Users\1\Desktop\DesirialandSerial\text.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.WriteLine("Lol");
                    writer.WriteLine("Name");
                    writer.WriteLine("FirstName");
                }
            }
            
            using (StreamReader reader = File.OpenText(path))
            {
                string s;
                while((s = reader.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }*/

            /*Person pers = new Person();
            pers.Name = "Nikita";
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream s = new MemoryStream())
            {
                formatter.Serialize(s, pers);
                s.Position = 0;

                Person newPers = (Person)formatter.Deserialize(s);
                Console.WriteLine(newPers.Age + "\n" + newPers.Name);
            }*/
        }
    }
    [Serializable]
    public class Person
    {
        private int age;
        private string name;
        public int Age { get => age; set => age = value; }
        public string Name { get => name; set => name = value; }
    }
}