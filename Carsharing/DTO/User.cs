using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Carsharing.DTO
{
    class User
    {
        public string username;

        public string password;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        override
        public String ToString()
        {
            return username + " " + password;
        }
    }
}
