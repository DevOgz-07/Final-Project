using Final_Project1.Entities;
using Final_Project1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project1.Areas.admin.Controllers
{
        [Area("admin"), Authorize]
        public class SlideController : Controller
        {
            IRepository<Slide> slideRepo;
            public SlideController(IRepository<Slide> _slideRepo)
            {
                slideRepo = _slideRepo;
            }
            public IActionResult Index()
            {
                return View(slideRepo.GetAll().OrderBy(x => x.DisplayIndex));
            }

            public IActionResult New()
            {
                return View();
            }
            [HttpPost, ValidateAntiForgeryToken]
            public async Task<IActionResult> New(Slide slayt, IFormFile picture)
            {
                ModelState.Remove("PictureUrl");
                if (ModelState.IsValid)
                                       
                {
                    if (Request.Form.Files.Any()) 
                    {
                        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slide"))) 
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slide")); 
                        }
                        string dosyaAdi = picture.FileName;

                        using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slide", dosyaAdi), FileMode.Create))
                        {
                            await picture.CopyToAsync(stream);
                        }
                        slayt.PictureUrl = "/img/slide/" + dosyaAdi;
                    }
                    slideRepo.Add(slayt);
                    return RedirectToAction("Index");
                }

                return View();
            }


            public IActionResult Edit(int id)
            {
                Slide slide = slideRepo.GetBy(x => x.Id == id);
                if (slide != null)
                {
                    return View(slide);
                }
                return RedirectToAction("Index");
            }


            [HttpPost, ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(Slide slayt, IFormFile picture)
            {
                ModelState.Remove("PictureUrl");
                if (ModelState.IsValid)
                {
                    if (Request.Form.Files.Any())
                    {
                        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slide")))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slide"));
                        }
                        string dosyaAdi = picture.FileName;

                        using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "slide", dosyaAdi), FileMode.Create))
                        {
                            await picture.CopyToAsync(stream);
                        }
                        slayt.PictureUrl = "/img/slide/" + dosyaAdi;
                    }
                    slideRepo.Update(slayt);
                    return RedirectToAction("Index");
                }

                return View();
            }


            public IActionResult Delete(int id)
            {
                Slide slide = slideRepo.GetBy(x => x.Id == id);
                if (slide != null)
                {
                    slideRepo.Delete(slide);
                }
                return RedirectToAction("Index");
            }
        }
    
}
