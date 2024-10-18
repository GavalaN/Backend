using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TestLogin_Server.DataBaseManager;
using TestLogin_Server.Models;

namespace TestLogin_Server.Controllers
{
    public class FelhasznaloController : BaseDataBaseManager, ISQL
    {
        public string Delete(int id)
        {
            return "delete";
        }

        public string Insert(Rekord rekord)
        {
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "INSERT INTO `felhasznalok`(`LoginNev`, `HASH`, `SALT`, `Nev`, `Jog`, `Aktiv`, `Email`, `ProfilKep`) VALUES (@LoginNev,@HASH,@SALT,@Nev,@Jog,@Aktiv,@Email,@ProfilKep)"
                
            };
            cmd.Parameters.AddWithValue("@LoginNev", ((Felhasznalo)rekord).LoginNev);
            cmd.Parameters.AddWithValue("@HASH", ((Felhasznalo)rekord).HASH);
            cmd.Parameters.AddWithValue("@SALT", ((Felhasznalo)rekord).SALT);
            cmd.Parameters.AddWithValue("@Nev", ((Felhasznalo)rekord).Nev);
            cmd.Parameters.AddWithValue("@Jog", ((Felhasznalo)rekord).Jog);
            cmd.Parameters.AddWithValue("@Aktiv", ((Felhasznalo)rekord).Aktiv);
            cmd.Parameters.AddWithValue("@Email", ((Felhasznalo)rekord).Email);
            cmd.Parameters.AddWithValue("@ProfilKep", ((Felhasznalo)rekord).ProfilKep);
            try
            {
                MySqlConnection conn = BaseDataBaseManager.connection;
                cmd.Connection = conn;
                conn.Open();
                int ujsorokszama = cmd.ExecuteNonQuery();
                if (ujsorokszama == 0)
                {
                    return "Nem sikerült a felhasználó felvétele!";
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                return ($"{ex.Message}");
            }
            finally
            {
                connection.Close();
            }
            return "Sikeres Beszúrás";
        }

        public List<Rekord> Select()
        {
            List<Rekord> list = new List<Rekord>();
            MySqlCommand cmd = new MySqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "SELECT * FROM felhasznalok"
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
                    Felhasznalo ujfelhasznalo = new Felhasznalo()
                    {
                        Id = reader.GetInt32("Id"),
                        LoginNev = reader.GetString("LoginNev"),
                        HASH = reader.GetString("HASH"),
                        SALT = reader.GetString("SALT"),
                        Nev = reader.GetString("Nev"),
                        Jog = reader.GetInt32("Jog"),
                        Aktiv = reader.GetBoolean("Aktiv"),
                        Email = reader.GetString("Email"),
                        ProfilKep = reader.GetString("ProfilKep")
                    };
                    list.Add(ujfelhasznalo);
                }
            }
            catch (Exception ex)
            {
                Felhasznalo ujFelhasznalo = new Felhasznalo()
                {
                    Id = -1,
                    HASH = ex.Message
                };
                list.Add(ujFelhasznalo);
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