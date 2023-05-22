using _1_BussinesLogicLayer.Bier;
using _1_BussinesLogicLayer.Gebruiker;
using _2_InterfaceLibrary.Beoordeling;
using _2_InterfaceLibrary.Bier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_BussinesLogicLayer.Beoordeling
{
    public class Review
    {
        public int ID { get; set; }
        public double Waarde { get; set; }
        public string TextReview { get; set; }
        public string Titel { get; set; }
        public DateTime DrinkDatum { get; set; }
        public int SchenkManier { get; set; }
        public int Status { get; set; }
        public User User { get; set; }
        public Beer Beer { get; set; }
        public int BierID { get; set; }

        public Review()
        {

        }
        public Review(int iD, double waarde, string textReview, string titel, DateTime drinkDatum, int schenkManier, Beer beer, int bieriD)
        {
            ID = iD;
            Waarde = waarde;
            TextReview = textReview;
            Titel = titel;
            DrinkDatum = drinkDatum;
            SchenkManier = schenkManier;
            Beer = beer;
            BierID = bieriD;
        }

        public Review(ReviewDTO reviewDTO)
        {
            this.ID = reviewDTO.ID;
            this.Waarde = reviewDTO.Waarde;
            this.TextReview = reviewDTO.TextReview;
            this.Titel = reviewDTO.Titel;
            this.DrinkDatum = reviewDTO.DrinkDatum;
            this.SchenkManier = reviewDTO.SchenkManier;
            BeerDTO dto = Beer.GetBeerDTO();
            dto = reviewDTO.BeerDTO;
            this.BierID = reviewDTO.BierID;
        }

        public ReviewDTO GetDTO()
        {
            BeerDTO dto = Beer.GetBeerDTO();
            return new ReviewDTO(ID, Waarde, TextReview, Titel, DrinkDatum, SchenkManier, dto, BierID);
        }
    }
}
