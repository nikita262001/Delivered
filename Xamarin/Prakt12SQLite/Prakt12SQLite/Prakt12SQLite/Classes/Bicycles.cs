using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Prakt12SQLite
{
    public class Bicycles
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int ModelNumber { get; set; }
        public int NumberOfGears { get; set; }
        public int MaxSpeed { get; set; }
        public int Price { get; set; }
        public DateTime DateOfIssue { get; set; }
        public bool OnTheRun { get; set; }
        public string Image { get; set; }
    }
}