using _2_InterfaceLibrary.Bier;
using _2_InterfaceLibrary.Gebruiker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_InterfaceLibrary.Beoordeling
{
    public class ReviewDTO
    {
        public int ID { get; set; }
        public double Waarde { get; set; }
        public string TextReview { get; set; }
        public string Titel { get; set; }
        public DateTime DrinkDatum { get; set; }
        public int SchenkManier { get; set; }
        public int Status { get; set; }
        public UserDTO UserDTO { get; set; }
        public BeerDTO BeerDTO { get; set; }
        public int BierID { get; set; }

        public ReviewDTO()
        {

        }

        public ReviewDTO(int iD, double waarde, string textReview, string titel, DateTime drinkDatum, int schenkManier, BeerDTO beerDTO, int bierID)
        {
            ID = iD;
            Waarde = waarde;
            TextReview = textReview;
            Titel = titel;
            DrinkDatum = drinkDatum;
            SchenkManier = schenkManier;
            BeerDTO = beerDTO;
            BierID = bierID;
        }

        public ReviewDTO(int iD, double waarde, string textReview, string titel, DateTime drinkDatum, int schenkManier, int bierID)
        {
            ID = iD;
            Waarde = waarde;
            TextReview = textReview;
            Titel = titel;
            DrinkDatum = drinkDatum;
            SchenkManier = schenkManier;
            BierID = bierID;
        }
    }
}
