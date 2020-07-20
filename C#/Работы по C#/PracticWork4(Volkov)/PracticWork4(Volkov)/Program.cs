using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PracticWork4_Volkov_
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathTxt = @"C:\Users\student\Desktop\Text.txt";
            string pathTxtJs = @"C:\Users\student\Desktop\TextJS.txt";
            Person person1 = new Person("Nikita", "Volk", 18, "Работяга", new DateTime(2001, 4, 27));
            Person person2 = new Person("Shiro", "Nai", 14, "Геймер", new DateTime(2005, 1, 1));
            Company company = new Company("NPGoogle", new DateTime(2010, 4, 27));

            BinaryFormatter formatterB = new BinaryFormatter();
            JsonSerializer serializer = new JsonSerializer();
            XmlSerializer formatterXml = new XmlSerializer(typeof(Person));

            // 1 задание
            using (IsolatedStorageFile f = IsolatedStorageFile.GetMachineStoreForDomain())
            using (var s = new IsolatedStorageFileStream("hi.txt", FileMode.Create, f))
            using (var writer = new StreamWriter(s))
            {
                writer.WriteLine("Прога работает , и это хорошо!");
                formatterB.Serialize(s,company);
                
                s.Position = 0;
                Company newComp = (Company)formatterB.Deserialize(s);
                Console.WriteLine("Название компании: " + newComp.NameCompany + "\n" + "Дата основания компании: " + newComp.CompanyFounded);
            }

            // 2 задание
            using (FileStream file = new FileStream(pathTxt, FileMode.Create))
            {
                formatterB.Serialize(file,person1);
            }

            // 3 задание
            using(FileStream file = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                formatterXml.Serialize(file, person1);
            }

            // 4 задание
            using (StreamWriter file = new StreamWriter(pathTxtJs))
            using (JsonWriter writer = new JsonTextWriter(file))
            {
                serializer.Serialize(writer, person1);
            }
        }
    }
}
