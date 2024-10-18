using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TestLogin_Server.DataBaseManager
{
    public class BaseDataBaseManager
    {
        protected BaseDataBaseManager() 
        {
            
        }
        public static MySqlConnection connection
        {
            get
            {
                MySqlConnection connection = new MySqlConnection()
                {
                    ConnectionString = "SERVER=localhost;DATABASE=testlogin;UID=root;PASSWORD=;SSL MODE=none"
                };
                return connection;
            }
        }
    }
}