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
    class AutorizacionViewModel : INotifyPropertyChanged
    {
        UserModel model = new UserModel();
        private User selectedUser;
        private string username { get; set; }
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        private string password { get; set; }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("selectedUser");
            }
        }
        private RelayCommand logIn;
        public RelayCommand LogIn
        {
            get
            {
                return logIn ??
                  (logIn = new RelayCommand(obj =>
                  {
                      User newUser = new User(username, password);
                      bool rezolution = model.tryLogin(newUser);
                      goToMainMenu(rezolution, newUser);
                  }));
            }
        }

        private RelayCommand register;
        public RelayCommand Register
        {
            get
            {
                return register ??
                  (register = new RelayCommand(obj =>
                  {
                      User newUser = new User(username, password);
                      bool rezolution = !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password) && model.tryRegister(newUser);
                      goToMainMenu(rezolution, newUser);
                  }));
            }
        }
        private void goToMainMenu(bool resolution, User user)
        {
            if (resolution)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show(model.ErrorMessage, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                AutorizacionWindow autorizacionWindow = new AutorizacionWindow();
                autorizacionWindow.Show();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
