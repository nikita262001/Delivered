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
            
            string path = @"D:\SerializeDeserialize\Test\text1.txt";
            string path22 = @"D:\SerializeDeserialize\Test\text2.txt";
            
            string path1 = @"D:\SerializeDeserialize\Test";
            string path2 = @"q\w\e\r\t\y";
            DirectoryInfo info = new DirectoryInfo(path1);
            if (info.Exists)
            {
                info.Create();
            }
            info.CreateSubdirectory(path2);
            Console.WriteLine(info.Name + "\n" + info.FullName);


            path1 = @"D:\SerializeDeserialize\Test\text1.txt";
            path2 = @"D:\SerializeDeserialize\text1.txt";


            var txt = new FileInfo(path);
            using (FileStream newFile = txt.Create())
            {

                byte[] infotext = new UTF8Encoding(true).GetBytes("Чтото написано.");
               newFile.Write(infotext, 0, infotext.Length);
            }

            if (!File.Exists(path2)) { File.Delete(path2); }

            using (StreamWriter writer = File.CreateText(path2)) // Создает text.txt по ссылке (path) и записывает данные 
            {
                writer.WriteLine("Lol");
                writer.WriteLine("Name");
                writer.WriteLine("FirstName");
            }


            using (StreamReader reader = txt.OpenText())
            {
                var s = "";
                while ((s = reader.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

            if (txt.Exists)
            {
                File.Move(path1, path2);
            }
            
            Person pers = new Person();
            pers.Age = 18;
            pers.Name = "Nikita";
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream s = new FileStream(path22, FileMode.Create))
            {
                formatter.Serialize(s, pers);
                s.Position = 0;

                Person newPers = (Person)formatter.Deserialize(s);
                Console.WriteLine(newPers.Age + "\n" + newPers.Name);
            }

            
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