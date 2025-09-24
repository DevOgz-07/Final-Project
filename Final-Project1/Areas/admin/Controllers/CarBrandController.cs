using Final_Project1.Areas.admin.ViewsModel;
using Final_Project1.Entities;
using Final_Project1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project1.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class CarBrandController : Controller
    {
        
        
            IRepository<CarBrand> CarBrandRepo;
            public CarBrandController(IRepository<CarBrand> _CarBrandRepo)
            {
                CarBrandRepo = _CarBrandRepo;
            }
            public IActionResult Index()
            {
                var model = CarBrandRepo.GetAll().Include(x => x.ParentBrand).Include(x => x.ChildBrand);

                 return View(model);
            }
        [HttpGet]
            public IActionResult New()
            {
                BrandVM vm = new BrandVM()
                {
                    Brands =CarBrandRepo.GetAll(x => x.ParentId == null).OrderBy(x => x.Name),
                    CarBrand=new CarBrand()
                };
                return View(vm);
            }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> New(BrandVM marka)
        {
            ModelState.Remove("CarBrand.PictureUrl");

            if (ModelState.IsValid)
            {
                if (marka.CarBrand.ParentId != null) 
                {
                    if (marka.Pictures != null && marka.Pictures.Any())
                    {
                        string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "carbrand");
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        var picture = marka.Pictures.First();
                        string fileName = Path.GetFileName(picture.FileName);
                        string fullPath = Path.Combine(uploadsFolder, fileName);

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await picture.CopyToAsync(stream);
                        }

                        marka.CarBrand.PictureUrl = "/img/carbrand/" + fileName;
                    }
                    else
                    {
                        
                        marka.CarBrand.PictureUrl = null; 
                    }
                }
                else
                {
                    
                    marka.CarBrand.PictureUrl = null;
                }

                CarBrandRepo.Add(marka.CarBrand);
                return RedirectToAction("Index");
            }
            
            return View(marka);
        }





        public IActionResult Edit(int id)
            {
            CarBrand brand = CarBrandRepo.GetBy(x=> x.Id == id);

            BrandVM vm = new BrandVM()
            {
                Brands = CarBrandRepo.GetAll(x => x.ParentId == null).OrderBy(x => x.Name),
                CarBrand = brand
            };
            return View(vm);

            }


            [HttpPost, ValidateAntiForgeryToken]
            public IActionResult Edit(BrandVM vm)
            {
                if (ModelState.IsValid)
                {
                    CarBrandRepo.Update(vm.CarBrand);
                    return RedirectToAction("Index");
                }


                return View(vm);
            }


            public IActionResult Delete(int id)
            {
                CarBrand Brand = CarBrandRepo.GetBy(x => x.Id == id);
                if (Brand != null)
                {
                    CarBrandRepo.Delete(Brand);
                }
                return RedirectToAction("Index");
            }
       






    }

}

