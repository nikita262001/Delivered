using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using PracticWork4_Volkov_;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CheckWork
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathTxt = @"C:\Users\student\Desktop\Text.txt";
            string pathTxtJs = @"C:\Users\student\Desktop\TextJS.txt";

            BinaryFormatter formatter = new BinaryFormatter();
            JsonSerializer serializer = new JsonSerializer();
            XmlSerializer formatterXml = new XmlSerializer(typeof(Person));

            // 2 задание
            using (FileStream file = new FileStream(pathTxt, FileMode.Open))
            {
                Person person = (Person)formatter.Deserialize(file);
                Console.WriteLine("Имя: " + person.Name + "\nФамилия: " + person.Surname);
            }

            // 3 задание
            using (FileStream fs = new FileStream(@"D:\PracticWork4(Volkov)\PracticWork4(Volkov)\bin\Debug\person.xml", FileMode.OpenOrCreate))
            {
                Person newpersonXml = (Person)formatterXml.Deserialize(fs);

                Console.WriteLine("Имя: " + newpersonXml.Name + "\nФамилия: " + newpersonXml.Surname);
            }

            // 4 задание (просто так)
            using (StreamReader file = new StreamReader(pathTxtJs))
            using (JsonReader reader = new JsonTextReader(file))
            {
                Person newpersonJson = serializer.Deserialize<Person>(reader);
                Console.WriteLine("Имя: " + newpersonJson.Name + "\nФамилия: " + newpersonJson.Surname);
            }
        }
    }
}
