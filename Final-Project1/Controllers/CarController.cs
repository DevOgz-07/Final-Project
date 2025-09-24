using Final_Project1.Areas.admin.ViewsModel;
using Final_Project1.Entities;
using Final_Project1.Repositories;
using Final_Project1.ViewsModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Final_Project1.Controllers
{
    public class CarController : Controller
    {
        private readonly IRepository<Slide> slideRepo;
        private readonly IRepository<CarBrand> carBrandRepo;
        private readonly IRepository<CarDetail> carDetailRepo;
        private readonly IRepository<CarImage> carImageRepo;
        private readonly DataContext _context;

        public CarController(
            IRepository<Slide> _slideRepo,
            IRepository<CarBrand> _carBrandRepo,
            DataContext context,
            IRepository<CarDetail> _carDetailRepo,
            IRepository<CarImage> _carImageRepo)
        {
            slideRepo = _slideRepo;
            carBrandRepo = _carBrandRepo;
            _context = context;
            carDetailRepo = _carDetailRepo;
            carImageRepo = _carImageRepo;
        }




        [Route("Markalar/")]
        public IActionResult Index(int? id)
        {
            var model = new CarVM
            {
                Brands = carBrandRepo.GetAll().Where(x => x.ParentId == null).ToList(),
                Slides = slideRepo.GetAll().ToList(),
                ChildBrands = carBrandRepo.GetAll().Where(x => x.ParentId != null).ToList()

            };

            if (id.HasValue)
            {

                model.ChildBrands = carBrandRepo.GetAll()
                                                .Where(x => x.ParentId == id.Value)
                                                .ToList();
            }


            return View(model);
        }

        [Route("Detay/{id}")]
        public IActionResult Detail(int id)
        {
            var carDetail = carDetailRepo.GetAll().FirstOrDefault(c => c.CarBrandId == id);

            if (carDetail == null)
            {
                return Content($"Veritabanında ID = {id} olan kayıt bulunamadı.");
            }


            var model = new CarVM
            {
                Brands = carBrandRepo.GetAll().Where(x => x.ParentId == null).ToList(),
                Slides = slideRepo.GetAll().ToList(),
                ChildBrands = carBrandRepo.GetAll().Where(x => x.ParentId != null).ToList(),
                Pictures = carImageRepo.GetAll().Where(x => x.CarDetailId == carDetail.Id),
                Detail = carDetail,

            };

            return View(model);
        }
    }
}
