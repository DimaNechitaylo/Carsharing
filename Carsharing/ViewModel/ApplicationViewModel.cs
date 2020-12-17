using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Carsharing.DTO;
using Carsharing.Model;
using System.Windows;

namespace Carsharing.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Car selectedCar;
        public ObservableCollection<Car> Cars { get; set; }
        private Parking SelectedParking;
        public ObservableCollection<Parking> Parkings { get; set; }
        public Parking selectedParking
        {
            get { return selectedParking; }
            set
            {
                selectedParking = value;
                OnPropertyChanged("SelectedParking");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Car car = new Car();
                      Cars.Insert(0, car);
                      SelectedCar = car;
                  }));
            }
        }


        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Car car = obj as Car;
                      if (car != null)
                      {
                          Cars.Remove(car);
                      }
                  },
                 (obj) => Cars.Count > 0));
            }
        }

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }

        public ApplicationViewModel()
        {
            Cars = new ObservableCollection<Car>
            {
                new Car("Tayouta", Car.CarsCalsses.Comfort),
                new Car("Marsedes", Car.CarsCalsses.Business),
                new Car("Reno", Car.CarsCalsses.Econom),
                new Car("Mazda", Car.CarsCalsses.Comfort),
                new Car("Shkoda", Car.CarsCalsses.Comfort)
            };
            Parkings = new ObservableCollection<Parking>
            {
                new Parking { Location = "вул. Хрещатик 12"},
                new Parking { Location = "вул. vwsdv 2"},
                new Parking { Location = "вул. abdsdnbc 87"}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}