using Final_Project1.Entities;
using Final_Project1.Repositories;
using Final_Project1.ViewsModel;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project1.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Slide> slideRepo;
        public HomeController(IRepository<Slide> _slideRepo)
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
        public IActionResult Landing()
        {
            return View();
        }
    }
}
