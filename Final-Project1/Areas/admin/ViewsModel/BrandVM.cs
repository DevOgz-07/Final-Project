using Final_Project1.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using NuGet.Protocol;

namespace Final_Project1.Areas.admin.ViewsModel
{
    public class BrandVM
    {
            public CarBrand CarBrand{ get; set; }

           
            [ValidateNever]
            public IEnumerable<CarBrand> Brands { get; set; }

            [ValidateNever]
            public IEnumerable<IFormFile> Pictures { get; set; }
        
      
            

        

    }
}
