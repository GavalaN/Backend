using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestLogin_Server.DataBaseManager;
using TestLogin_Server.Models;

namespace TestLogin_Server.Controllers
{
    public class JogosultsagController : BaseDataBaseManager, ISQL
    {
        public string Delete(int id)
        {
            return "delete";
        }

        public string Insert(Rekord rekord)
        {
            return "insert";
        }

        public List<Rekord> Select()
        {
            List<Rekord> list = new List<Rekord>();
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "SELECT * FROM jogosultsagok"
            };
            try
            {
                MySqlConnection conn = BaseDataBaseManager.connection;
                conn.Open();
                cmd.Connection = conn;
                //Eddig az SQL parancs futtatásának előkészítése történt
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Jogosultsag ujJogosultsag = new Jogosultsag()
                    {
                        Id = reader.GetInt32("Id"),
                        Szint = reader.GetInt32("Szint"),
                        Nev = reader.GetString("Nev"),
                        Leiras = reader.GetString("Leiras")
                    };
                    list.Add(ujJogosultsag);
                }
            }
            catch (Exception ex)
            {
                Jogosultsag ujJogosultsag = new Jogosultsag()
                {
                    Id = -1
                };
                list.Add(ujJogosultsag);
            }
            finally
            {
                connection.Close();
            }
            return list;
        }

        public string Update(Rekord rekord)
        {
            return "update";
        }
    }
}