using _2_InterfaceLibrary.Beoordeling;
using _2_InterfaceLibrary.Bier;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_DataAccesLayer
{
    public class ReviewDAL : IReview
    {
        public void Create(ReviewDTO dto)
        {
            string query = "INSERT INTO beoordelingen " +
                                       "(gebruikers_id, titel, waarde, text_review, schenk_manier, drink_datum, bier_id) " +
                                       "VALUES(@Id, @Titel, @Waarde, @Textreview, @Schenkmanier, @Drinkdatum, @BierId)";
            SqlCommand cmd = new SqlCommand(query, DatabaseConnect.conn);
            cmd.Parameters.AddWithValue("@Id", dto.UserDTO.ID);
            cmd.Parameters.AddWithValue("@Titel", dto.Titel);
            cmd.Parameters.AddWithValue("@Waarde", dto.Waarde);
            cmd.Parameters.AddWithValue("@Textreview", dto.TextReview);
            cmd.Parameters.AddWithValue("@Schenkmanier", dto.SchenkManier);
            cmd.Parameters.AddWithValue("@Drinkdatum", dto.DrinkDatum);
            cmd.Parameters.AddWithValue("@BierId", dto.BierID);

            DatabaseConnect.Open();
            cmd.ExecuteNonQuery();
            DatabaseConnect.Close();
        }

        public void Delete(int id)
        {
            string query = "DELETE * FROM beoordelingen where beoordelings_id = @Id;";
            SqlCommand cmd = new SqlCommand(query, DatabaseConnect.conn);
            cmd.Parameters.AddWithValue("@Id", id);

            DatabaseConnect.Open();
            cmd.ExecuteNonQuery();
            DatabaseConnect.Close();
        }

        public List<ReviewDTO> GetAll()
        {
            try
            {
                SqlDataReader reader;
                SqlCommand cmd;
                string sql = "SELECT * FROM beoordelingen";

                cmd = new SqlCommand(sql, DatabaseConnect.conn);

                DatabaseConnect.Open();
                reader = cmd.ExecuteReader();
                List<ReviewDTO> DTO = new();
                while (reader.Read())
                {
                    DTO.Add(new(reader.GetInt32(0), reader.GetDouble(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetInt32(5), reader.GetInt32(6)));
                }
                DatabaseConnect.Close();
                return DTO;

            }
            catch
            {
                return null;
            }
        }

        public ReviewDTO GetById(int id)
        {
            ReviewDTO dto = new ReviewDTO();

            string query = "SELECT * FROM beoordelingen WHERE beoordelings_id = @ID;";

            SqlCommand cmd = new SqlCommand(query, DatabaseConnect.conn);
            cmd.Parameters.AddWithValue("@ID", id);

            DatabaseConnect.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dto.ID = (int)dr["id"];
                dto.Titel = dr["naam"].ToString();
                dto.Waarde = (double)dr["type"];
                dto.TextReview = dr["text_review"].ToString();
                dto.SchenkManier = (int)dr["schenk_manier"];
                dto.BierID = (int)dr["bier_id"];
                dto.DrinkDatum = Convert.ToDateTime(dr["drink_datum"]);
            }
            DatabaseConnect.Close();
            return dto;
        }

        public void Update(ReviewDTO dto)
        {
            if (dto.ID != null)
            {
                string query = "UPDATE beoordelingen SET " +
                               "waarde = @Waarde, " +
                               "titel = @Titel, " +
                               "text_review = @TextReview, " +
                               "drink_datum = @DrinkDatum, " +
                               "schenk_manier = @SchenkManier " +
                               "WHERE beoordelings_id = @Id";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnect.conn);
                cmd.Parameters.AddWithValue("@Waarde", dto.Waarde);
                cmd.Parameters.AddWithValue("@Titel", dto.Titel);
                cmd.Parameters.AddWithValue("@TextReview", dto.TextReview);
                cmd.Parameters.AddWithValue("@DrinkDatum", dto.DrinkDatum);
                cmd.Parameters.AddWithValue("@SchenkManier", dto.SchenkManier);
                cmd.Parameters.AddWithValue("@Id", dto.ID);

                DatabaseConnect.Open();
                cmd.ExecuteNonQuery();
                DatabaseConnect.Close();
            }
        }

        public List<ReviewDTO> GetAllByUser(int userId)
        {
            DatabaseConnect.Open();

            string query = "select * from beoordelingen inner join bieren on beoordelingen.bier_id = bieren.bier_id where gebruikers_id = @GebruikerID;";
            SqlCommand cmd = new SqlCommand(query, DatabaseConnect.conn);
            cmd.Parameters.AddWithValue("@GebruikerID", userId);

            List<ReviewDTO> Reviews = new List<ReviewDTO>();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    ReviewDTO reviewDTO = new ReviewDTO();
                    BeerDTO beerDTO = new BeerDTO();
                    reviewDTO.Titel = Convert.ToString(dr["titel"]);
                    reviewDTO.Waarde = Convert.ToDouble(dr["waarde"]);
                    reviewDTO.TextReview = Convert.ToString(dr["text_review"]);
                    reviewDTO.SchenkManier = Convert.ToInt32(dr["schenk_manier"]);
                    //reviewDTO.DrinkDatum = Convert.ToDateTime(dr["drink_datum"]);

                    beerDTO.ID = Convert.ToInt32(dr["bier_id"]);
                    beerDTO.Name = Convert.ToString(dr["naam"]);
                    beerDTO.BierType = Convert.ToString(dr["bier_type"]);
                    beerDTO.Brouwerij = Convert.ToString(dr["brouwerij"]);

                    reviewDTO.BeerDTO = beerDTO;

                    Reviews.Add(reviewDTO);
                }
                DatabaseConnect.Close();

                return Reviews;
            }
        }
    }
}
