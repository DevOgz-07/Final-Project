using Final_Project1.Areas.admin.ViewsModel;
using Final_Project1.Entities;
using Final_Project1.Repositories;
using Final_Project1.ViewsModel;
using Karl.BL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Final_Project1.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class CarDetailController : Controller
    {
        IRepository<CarBrand> CarBrandRepo;
        IRepository<CarDetail> carDetailRepo;
        IRepository<CarImage> carImageRepo;
        private readonly IFileService fileService;
        private readonly IWebHostEnvironment env;

        public CarDetailController(IRepository<CarBrand> _CarBrandRepo,
        IRepository<CarDetail> _carDetailRepo,
        IRepository<CarImage> _carImageRepo,
        IFileService _fileService,
        IWebHostEnvironment _env)
        {
            CarBrandRepo = _CarBrandRepo;
            carDetailRepo = _carDetailRepo;
            carImageRepo = _carImageRepo;
            fileService = _fileService;
            env = _env;

        }

        public IActionResult Index()
        {
            var model = carDetailRepo.GetAll()
                        .Include(x => x.CarBrand)  
                        .Include(x => x.Images)
                        .ToList();
            foreach (var item in model)
            {
                item.CarBrand.ParentBrand = CarBrandRepo.GetBy(x => x.Id == item.CarBrand.ParentId);
            }

            return View(model);

        }






        public IActionResult New()
        {
            var model = new DetailVM
            {
                CarBrands = CarBrandRepo.GetAll().Where(x => x.ParentId == null).ToList(),
                ChildBrands = new List<CarBrand>(),
                CarDetail = new CarDetail()
            };
            return View(model);
        }






        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> New(DetailVM model)
        {
            if (ModelState.IsValid)
            {
                
                carDetailRepo.Add(model.CarDetail);
               

                if (model.Pictures != null && model.Pictures.Any())
                {
                    var urls = await fileService.UploadMultipleAsync(model.Pictures, env.WebRootPath, $"products/{model.CarBrands}");

                    foreach (var path in urls)
                    {
                        CarImage carImage = new CarImage
                        {
                            CarDetailId = model.CarDetail.Id,
                            ImagePath = path
                        };

                        carImageRepo.Add(carImage);
                        
                    }
                }

                return RedirectToAction("Index");
            }

     




            var model2 = new DetailVM
            {
                CarBrands = CarBrandRepo.GetAll().Where(x => x.ParentId == null).ToList(),
                ChildBrands = new List<CarBrand>(),
                CarDetail = new CarDetail()
            };
            return View(model2);





        }

        [Route("/car/getmodel")]
        public IActionResult getModel(int markaId)
        {
            return Json(CarBrandRepo.GetAll(x => x.ParentId == markaId).OrderBy(x => x.Name));
        }
    }
}
