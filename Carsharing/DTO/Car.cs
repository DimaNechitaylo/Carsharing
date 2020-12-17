using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Carsharing.DTO
{
    public class Car : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public CarsCalsses CarsClass { get; }
        public Car() { }
        public Car(string Name, CarsCalsses CarsClass)
        {
            this.Name = Name;
            this.CarsClass = CarsClass;
        }
        public enum CarsCalsses
        {
            Econom,
            Comfort,
            Business
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}