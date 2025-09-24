using Final_Project1.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Final_Project1.ViewsModel
{
    public class CarVM
    {
        [ValidateNever]
        public IEnumerable<Slide> Slides { get; set; }
        [ValidateNever]
        public IEnumerable<CarBrand> Brands { get; set; }

        [ValidateNever]
        public ICollection<CarBrand> ChildBrands { get; set; }

        [ValidateNever]
        public IEnumerable<CarImage> Pictures { get; set; }

        public CarDetail Detail { get; set; }



    }
}
