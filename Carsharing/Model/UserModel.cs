using Carsharing.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsharing.Model
{
    class UserModel
    {
        public string ErrorMessage;
        public UserModel()
        {

        }
        public bool tryRegister(User user)
        {
            if (userExists(user))
            {
                ErrorMessage = "User already exists"; 
                return false;
            }
            createUser(user);
            return true;
        }
        public bool tryLogin(User user)
        {
            if (usernameMatchesPassword(user))
            {
                return true;
            }
            ErrorMessage = "Wrong login or password\n Try again";
            return false;
        }
        private Boolean userExists(User user)
        {
            using (MySqlConnection connection = ConnectionDB.getConnection())
            {
                string query = "SELECT EXISTS(SELECT id FROM `Users` WHERE username=@username)";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar);
                usernameParam.Value = user.username;
                command.Parameters.Add(usernameParam);
                command.Connection.Open();
                try
                {
                    return command.ExecuteScalar().ToString().Equals("1");
                }
                catch (FormatException e)
                {
                    return false;
                }
            }
        }

        public Boolean usernameMatchesPassword(User user)
        {
            using (MySqlConnection connection = ConnectionDB.getConnection())
            {
                string query = "SELECT EXISTS(SELECT id FROM `Users` WHERE username=@username AND password=@password)";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar);
                usernameParam.Value = user.username;
                command.Parameters.Add(usernameParam);

                MySqlParameter passwordParam = new MySqlParameter("@password", MySqlDbType.VarChar);
                passwordParam.Value = user.password;
                command.Parameters.Add(passwordParam);
                command.Connection.Open();
                try
                {
                    return command.ExecuteScalar().ToString().Equals("1");
                }
                catch (FormatException e)
                {
                    return false;
                }
            }
        }

        private void createUser(User user)
        {
            using (MySqlConnection connection = ConnectionDB.getConnection())
            {
                string queryString = "INSERT INTO `Users`(username, password) VALUES(@username, @password)";
                MySqlCommand command = new MySqlCommand(queryString, connection);

                MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar);
                usernameParam.Value = user.username;
                command.Parameters.Add(usernameParam);

                MySqlParameter passwordParam = new MySqlParameter("@password", MySqlDbType.VarChar);
                passwordParam.Value = user.password;
                command.Parameters.Add(passwordParam);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
