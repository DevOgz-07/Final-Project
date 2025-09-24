using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project1.Entities
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="varchar(20)"),
         StringLength(25),
         Display(Name = "Kullanıcı Adı"),
         Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılamaz")
        ]
        public string UserName { get; set; }


        [Column(TypeName = "varchar(100)"),
         StringLength(100),
         Display(Name = "Şifre"),
         Required(ErrorMessage = "Şifre Boş Bırakılamaz")
        ]
        public string Password { get; set; }

        [Column(TypeName = "varchar(25)"),
         StringLength(25),
         Display(Name = "Admin Adı Soyadı"),
         Required(ErrorMessage = "Ad Soyad Boş Bırakılamaz")
        ]
        public string FullName { get; set; }

        [Display(Name = "Rol")]
        public int? RoleName { get; set; }




    }
}
