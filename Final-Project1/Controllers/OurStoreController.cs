using Final_Project1.Entities;
using Final_Project1.Repositories;
using Final_Project1.ViewsModel;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project1.Controllers
{
    public class OurStoreController : Controller
    {
        IRepository<Slide> slideRepo;
        public OurStoreController(IRepository<Slide> _slideRepo)
        {
            slideRepo = _slideRepo;

        }
        public IActionResult Index()
        {
            var slides = slideRepo.GetAll().OrderBy(x => x.DisplayIndex);
            var vm = new CarVM
            {
                Slides = slides.ToList()
                
            };
            return View(vm);
        }
    }
}
