using _1_BussinesLogicLayer.Bier;
using _1_BussinesLogicLayer.Gebruiker;
using _2_InterfaceLibrary.Beoordeling;
using _2_InterfaceLibrary.Bier;
using _2_InterfaceLibrary.Gebruiker;

namespace SpeciaalbierIndex_ASP.Models
{
    public class ReviewViewModel
    {
        public int ReviewID { get; set; }
        public double Waarde { get; set; }
        public string TextReview { get; set; }
        public string Titel { get; set; }
        public DateTime DrinkDatum { get; set; }
        public int SchenkManier { get; set; }
        public UserDTO UserDTO { get; set; }
        public BeerDTO BeerDTO { get; set; }
        public int BierID { get; set; }

        public ReviewViewModel (int reviewId, double waarde, string textReview, string titel, DateTime drinkDatum, int schenkManier, UserDTO userDTO, BeerDTO beerDTO, int bierID)
        {
            ReviewID = reviewId;
            Waarde = waarde;
            TextReview = textReview;
            Titel = titel;
            DrinkDatum = drinkDatum;
            SchenkManier = schenkManier;
            UserDTO = userDTO;
            BeerDTO = beerDTO;
            BierID = bierID;
        }

        public ReviewViewModel()
        {

        }
    }
}
