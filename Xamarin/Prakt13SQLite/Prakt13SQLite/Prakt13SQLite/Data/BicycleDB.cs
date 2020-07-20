using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prakt13SQLite
{
    public class BicycleDB
    {
        private List<Bicycles> _startData = new List<Bicycles>
        {
            new Bicycles { Name = "Ardis", DateOfIssue = new DateTime(2000,1,1),MaxSpeed = 50,ModelNumber =  3,
                NumberOfGears = 18,Price = 3000, OnTheRun = true, Image = "Images/Ardis.jpg"},
            new Bicycles { Name = "Assembly", DateOfIssue = new DateTime(2000,1,1),MaxSpeed = 40,ModelNumber =  2,
                NumberOfGears = 24,Price = 4000, OnTheRun = false, Image = "Images/Assembly1.jpg"},
            new Bicycles { Name = "Assembly", DateOfIssue = new DateTime(2001,2,1),MaxSpeed = 45,ModelNumber =  2,
                NumberOfGears = 27,Price = 7000, OnTheRun = false, Image = "Images/Assembly2.jpg"},
            new Bicycles { Name = "Assembly", DateOfIssue = new DateTime(2001,2,1),MaxSpeed = 20,ModelNumber =  2,
                NumberOfGears = 24,Price = 6000, OnTheRun = false, Image = "Images/Assembly3.jpg"},
            new Bicycles { Name = "Giant", DateOfIssue = new DateTime(2003,3,1),MaxSpeed = 50,ModelNumber =  1,
                NumberOfGears = 21,Price = 7600, OnTheRun = true, Image = "Images/Giant.jpg"},
            new Bicycles { Name = "Gravity", DateOfIssue = new DateTime(2003,3,1),MaxSpeed = 65,ModelNumber =  2,
                NumberOfGears = 18,Price = 17500, OnTheRun = true, Image = "Images/Gravity.jpg"},
            new Bicycles { Name = "LarsenTrack", DateOfIssue = new DateTime(2004,4,1),MaxSpeed = 20,ModelNumber =  4,
                NumberOfGears = 15,Price = 45000, OnTheRun = true, Image = "Images/LarsenTrack.jpg"},
            new Bicycles { Name = "Stels", DateOfIssue = new DateTime(2004,4,1),MaxSpeed = 75,ModelNumber =  2,
                NumberOfGears = 21,Price = 1000, OnTheRun = true, Image = "Images/Stels.jpg"},
            new Bicycles { Name = "Trek", DateOfIssue = new DateTime(2005,5,1),MaxSpeed = 50,ModelNumber =  1,
                NumberOfGears = 24,Price = 10000, OnTheRun = true, Image = "Images/Trek.jpg"},
            new Bicycles { Name = "Worthersee", DateOfIssue = new DateTime(2005,5,1),MaxSpeed = 100,ModelNumber =  3,
                NumberOfGears = 27,Price = 3000, OnTheRun = true, Image = "Images/Worthersee.jpg"},
            new Bicycles { Name = "Байкал", DateOfIssue = new DateTime(2005,5,1),MaxSpeed = 99,ModelNumber =  5,
                NumberOfGears = 21,Price = 16000, OnTheRun = true, Image = "Images/Байкал.jpg"},
        };

        readonly SQLiteConnection _database;
        public BicycleDB(string dbPath)
        {
            _database = new SQLiteConnection(dbPath); // подключается и не создается если существует
            _database.CreateTable<Bicycles>(); // не создается если существует

            if (_database.Table<Bicycles>().Count() == 0)
            {
                IntializeData(_startData);
            }
        }

        private void IntializeData(IEnumerable<Bicycles> startData)
        {
            _database.InsertAll(startData);
        }

        public List<Bicycles> GetItems()
        {
            return _database.Table<Bicycles>().ToList();
        }
        public int SaveItem(Bicycles item)
        {
            return _database.Insert(item);
        }
        public int EditItem(Bicycles item)
        {
            return _database.Update(item);
        }
        public int DeleteItem(Bicycles item)
        {
            return _database.Delete(item);
        }
    }
}
