using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project1.Entities
{
    public class CarDetail
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "int"),
         Display(Name = "Araç Kilometresi"),
         Required(ErrorMessage ="Araç Kilometresi Boş Bırakılamaz")
        ]
        public int CarKilometer { get; set; }

        [Column(TypeName = "int"),
         Range(1990, 2030, ErrorMessage = "Geçerli bir model yılı giriniz."),
         Display(Name = "Araç Model Yılı"),
         Required(ErrorMessage = "Araç Model Yılı Boş Bırakılamaz")
        ]
        public int CarYear { get; set; }

        [Column(TypeName ="varchar(20)"),
         StringLength(25),
         Display(Name ="Araç Rengi"),
         Required(ErrorMessage = "Araç Rengi Boş Bırakılamaz")
        ]
        public string CarColor { get; set; }

        [Display(Name = "Araç Fiyat Bilgisi"), 
         Column(TypeName = "decimal(18,2)")
        ]
        public decimal DailyPrice { get; set; }

        [Column(TypeName = "varchar(500)"),
         StringLength(500),
         Display(Name = "Araç İle İlgili Bilgiler."),
         Required(ErrorMessage = "Araç açıklaması Boş Bırakılamaz")
         ]
        public string Description { get; set; }

        [Display(Name ="Görüntülenme Sırası")]
        public int DisplayIndex { get; set; }

        [Display(Name = "Araç Marka Adı")]
        public int? CarBrandId { get; set; }


        [ValidateNever]
        public CarBrand CarBrand { get; set; }

        [ValidateNever]
        public ICollection<CarImage> Images { get; set; }

        [ValidateNever]
        public Rezervation? Rezervation { get; set; }
    }
}
