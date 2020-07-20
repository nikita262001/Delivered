using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Prakt13SQLite
{
    public class Bicycles : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string _Name;
        int _ModelNumber;
        int _NumberOfGears;
        int _MaxSpeed;
        int _Price;
        DateTime _DateOfIssue;
        bool _OnTheRun;
        string _Image;

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }
        public int ModelNumber
        {
            get => _ModelNumber;
            set
            {
                _ModelNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ModelNumber"));
            }
        }
        public int NumberOfGears
        {
            get => _NumberOfGears;
            set
            {
                _NumberOfGears = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NumberOfGears"));
            }
        }
        public int MaxSpeed
        {
            get => _MaxSpeed;
            set
            {
                _MaxSpeed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxSpeed"));
            }
        }
        public int Price
        {
            get => _Price;
            set
            {
                _Price = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
            }
        }
        public DateTime DateOfIssue
        {
            get => _DateOfIssue;
            set
            {
                _DateOfIssue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateOfIssue"));
            }
        }
        public bool OnTheRun
        {
            get => _OnTheRun;
            set
            {
                _OnTheRun = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OnTheRun"));
            }
        }
        public string Image
        {
            get => _Image;
            set
            {
                _Image = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Image"));
            }
        }
    }
}
