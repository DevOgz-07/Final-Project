using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project1.Entities
{
    public class Rezervation
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="varchar(50)"),
         StringLength(50),
         Required(ErrorMessage ="İsim ve Soyİsim Kısmını Doldurunuz.")
        ]
        public string FullName { get; set; }

        [Column(TypeName = "varchar(50)"),
         StringLength(50),
         Required(ErrorMessage = "Mail Adres Kısmı Boş Bırakılamaz.")
        ]
        public string Mailaddress { get; set; }

        [Column(TypeName = "varchar(11)")]
        [StringLength(11, ErrorMessage = "Telefon numarası en fazla 11 karakter olabilir.")]
        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [Display(Name = "Telefon Numarası")]
        public int phoneNumber { get; set; }

        [Display(Name = "Randevu Oluşturma Tarihi")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Randevunun Bitiş Tarihi")]
        public DateTime EndDate { get; set; }

        public ICollection<CarDetail> CarDetails { get; set; }

       


    }
}
