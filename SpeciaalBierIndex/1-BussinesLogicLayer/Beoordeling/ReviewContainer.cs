using _2_InterfaceLibrary.Beoordeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_BussinesLogicLayer.Beoordeling
{
    public class ReviewContainer
    {
        public IReview Interface { get; set; }

        public ReviewContainer(IReview context)
        {
            Interface = context;
        }

        public void Create(Review review)
        {
            ReviewDTO dto = review.GetDTO();
            Interface.Create(dto);
        }

        public void Update(Review review)
        {
            ReviewDTO dto = new ReviewDTO
            {
                ID = review.ID,
                Titel = review.Titel,
                Waarde = review.Waarde,
                TextReview = review.TextReview,
                DrinkDatum = review.DrinkDatum,
                SchenkManier = review.SchenkManier,
            };
            Interface.Update(dto);
        }

        public void Delete(int id)
        {
            Interface.Delete(id);
        }

        public List<Review> GetAll()
        {
            List<Review> Reviews = new List<Review>();
            Interface.GetAll().ForEach(reviewDTO => Reviews.Add(new Review(reviewDTO)));
            return Reviews;
        }

        public Review GetById(int id)
        {
            return new Review(Interface.GetById(id));
        }
    }
}
