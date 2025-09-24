using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project1.Entities
{
    public class CarBrand
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="varchar(25)"),
         StringLength(25),
         Display(Name ="Marka Adı"),
         Required(ErrorMessage ="Marka Adı Boş Bırakılamaz.")
        ]
        public string Name { get; set; }

        [Column(TypeName = "varchar(150)"),
        StringLength(150),
        Display(Name = "Araç Resim Dosyası")
       ]
        public string? PictureUrl { get; set; }

        [Display(Name ="Araç Marka Adı")]
        public int? ParentId { get; set; }

        [ValidateNever]
        public CarBrand ParentBrand { get; set; }

        [ValidateNever]
        public ICollection<CarBrand> ChildBrand { get; set; }

        [ValidateNever]
        public ICollection<CarDetail> CarDetails { get; set; }
        //Deneme
    }
}
