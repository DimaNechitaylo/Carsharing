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

namespace Carsharing.ViewModel
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Car selectedCar;
        public ObservableCollection<Car> Cars { get; set; }

        // команда добавления нового объекта
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

        // команда удаления
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
                new Car { Title="iCar 7", Company="Apple", Price=56000 },
                new Car {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
                new Car {Title="Elite x3", Company="HP", Price=56000 },
                new Car {Title="Mi5S", Company="Xiaomi", Price=35000 }
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