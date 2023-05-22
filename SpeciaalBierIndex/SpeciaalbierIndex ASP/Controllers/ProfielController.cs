using _1_BussinesLogicLayer.Beoordeling;
using _1_BussinesLogicLayer.Gebruiker;
using _2_InterfaceLibrary.Beoordeling;
using _3_DataAccesLayer;
using Microsoft.AspNetCore.Mvc;
using SpeciaalbierIndex_ASP.Models;

namespace SpeciaalbierIndex_ASP.Controllers
{
    public class ProfielController : Controller
    {
        public IActionResult Index()
        {
            UserContainer userContainer = new UserContainer(new UserDAL());
            User user = userContainer.GetById(3);

            ReviewDAL reviewDal = new ReviewDAL();
            List<ReviewDTO> reviews = reviewDal.GetAllByUser(3);

            ProfielViewModel profielViewModel = new ProfielViewModel(
                user.ID,
                user.Naam,
                user.Email,
                user.Geboortedatum,
                reviews);

            return View(profielViewModel);
        }

        [HttpPost]
        public IActionResult Index(ReviewViewModel reviewViewModel)
        {
            Review review = new Review
            {
                ID = 1,
                Waarde = reviewViewModel.Waarde,
                TextReview = reviewViewModel.TextReview,
                Titel = reviewViewModel.Titel,
                DrinkDatum = reviewViewModel.DrinkDatum,
                SchenkManier = reviewViewModel.SchenkManier,
            };

            ReviewContainer reviewContainer = new ReviewContainer(new ReviewDAL());
            reviewContainer.Update(review);

            return RedirectToAction("Index");
        }
    }
}
