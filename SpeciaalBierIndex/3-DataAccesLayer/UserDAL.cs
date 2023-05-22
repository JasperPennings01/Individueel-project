using _2_InterfaceLibrary.Gebruiker;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DataAccesLayer
{
    public class UserDAL : IUser
    {
        public void Create(UserDTO dto)
        {
            string query = "INSERT INTO gebruikers " +
                                       "(rol, naam, email, wachtwoord, postcode, huisnummer, geboortedatum) " +
                                       "VALUES(@Rol, @Naam, @Email, @Wachtwoord, @Postcode, @Huisnummer, @Geboortedatum)";
            SqlCommand cmd = new SqlCommand(query, DatabaseConnect.conn);
            cmd.Parameters.AddWithValue("@Rol", 0);
            cmd.Parameters.AddWithValue("@Naam", dto.Naam);
            cmd.Parameters.AddWithValue("@Email", dto.Email);
            cmd.Parameters.AddWithValue("@Wachtwoord", dto.Wachtwoord);
            cmd.Parameters.AddWithValue("@Postcode", dto.Postcode);
            cmd.Parameters.AddWithValue("@Huisnummer", dto.Huisnummer);
            cmd.Parameters.AddWithValue("@Geboortedatum", dto.Geboortedatum);

            DatabaseConnect.Open();
            cmd.ExecuteNonQuery();
            DatabaseConnect.Close();
        }

        public void Delete(int id)
        {
            string query = "DELETE * FROM gebruikers WHERE gebruikers_id = @Id";
            SqlCommand cmd = new SqlCommand(query, DatabaseConnect.conn);
            cmd.Parameters.AddWithValue("@Id", id);

            DatabaseConnect.Open();
            cmd.ExecuteNonQuery();
            DatabaseConnect.Close();
        }

        public List<UserDTO> GetAll()
        {
            try
            {
                string query = "SELECT * FROM gebruikers";
                SqlDataReader reader;
                SqlCommand cmd = new SqlCommand(query, DatabaseConnect.conn);

                DatabaseConnect.Open();
                reader = cmd.ExecuteReader();
                List<UserDTO> Users = new List<UserDTO>();
                while (reader.Read())
                {
                    Users.Add(new(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetDateTime(7)));
                }
                DatabaseConnect.Close();
                return Users;
            }
            catch
            {
                return null;
            }
        }

        public UserDTO GetById(int id)
        {
            UserDTO dto = new UserDTO();

            string query = "SELECT * FROM gebruikers WHERE gebruikers_id = @Id";
            SqlCommand cmd = new SqlCommand(query, DatabaseConnect.conn);
            cmd.Parameters.AddWithValue("@Id", id);

            DatabaseConnect.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dto.ID = (int)reader["gebruikers_id"];
                dto.Rol = (int)reader["rol"];
                dto.Naam = reader["naam"].ToString();
                dto.Wachtwoord = reader["wachtwoord"].ToString();
                dto.Postcode = reader["postcode"].ToString();
                dto.Huisnummer = reader["huisnummer"].ToString();
                dto.Email = reader["email"].ToString();
                dto.Geboortedatum = Convert.ToDateTime(reader["geboortedatum"]);
            }
            DatabaseConnect.Close();
            return dto;
        }

        public void Update(UserDTO dto)
        {
            if(dto.ID != null)
            {
                string query = "UPDATE gebruikers SET " +
                               "(rol = @Rol, " +
                               "naam = @Naam, " +
                               "wachtwoord = @Wachtwoord, " +
                               "postcode = @Postcode, " +
                               "huisnummer = @Huisnummer," +
                               "email = @Email," +
                               "geboortedatum = @Geboortedatum " +
                               "WHERE gebruikers_id = @Id)";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnect.conn);
                cmd.Parameters.AddWithValue("@Rol", dto.Rol);
                cmd.Parameters.AddWithValue("@Naam", dto.Naam);
                cmd.Parameters.AddWithValue("@Wachtwoord", dto.Wachtwoord);
                cmd.Parameters.AddWithValue("@Postcode", dto.Postcode);
                cmd.Parameters.AddWithValue("@Huisnummer", dto.Huisnummer);
                cmd.Parameters.AddWithValue("@Email", dto.Email);
                cmd.Parameters.AddWithValue("@Geboortedatum", dto.Geboortedatum);
                cmd.Parameters.AddWithValue("@Id", dto.ID);

                DatabaseConnect.Open();
                cmd.ExecuteNonQuery();
                DatabaseConnect.Close();
            }
        }
    }
}
