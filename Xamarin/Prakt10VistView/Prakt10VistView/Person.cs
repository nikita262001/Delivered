 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Prakt10VistView
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string name;
        int age;
        string surname;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Surname"));
            }
        }
        public int Age
        {
            get => age;
            set
            {
                age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Age"));
            }
        }
    }
}
