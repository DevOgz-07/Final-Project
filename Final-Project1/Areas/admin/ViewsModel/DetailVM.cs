using Final_Project1.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Project1.Areas.admin.ViewsModel
{
    public class DetailVM
    {
        public CarDetail CarDetail { get; set; } // veritabanına eklemecek veri

        [ValidateNever]
        public IEnumerable<CarBrand> CarBrands { get; set; } = Enumerable.Empty<CarBrand>(); //İlk dropdown

        [ValidateNever]
        public IEnumerable<CarBrand> ChildBrands { get; set; } = Enumerable.Empty<CarBrand>(); //ikinci dropdown

        [ValidateNever]
        public IEnumerable<CarDetail> Details { get; set; } = new List<CarDetail>();

        [ValidateNever]
        public int? Model { get; set; }

        [ValidateNever]
        public IEnumerable<IFormFile> Pictures { get; set; } 

        [ValidateNever]
        public IEnumerable<CarImage> CarPictures{ get; set; }




    }
}
