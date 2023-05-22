using _1_BussinesLogicLayer.Beoordeling;
using _2_InterfaceLibrary.Beoordeling;
using _3_DataAccesLayer;
using Microsoft.AspNetCore.Mvc;

namespace SpeciaalbierIndex_ASP.Controllers
{
    public class ReviewController : Controller
    {
        [HttpGet]
        public IActionResult Update(int id)
        {
            ReviewContainer reviewContainer = new ReviewContainer(new ReviewDAL());
            Review review = new Review();
            review = reviewContainer.GetById(id);
           
            return View();
        }
    }
}
