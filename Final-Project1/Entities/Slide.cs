using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_Project1.Entities
{
    public class Slide
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)"),
         StringLength(50),
         Display(Name = "Başlık"),
         Required(ErrorMessage = "Başlık Alanı Boş Bırakılamaz")
        ]
        public string Title { get; set; }


        [Column(TypeName = "varchar(100)"),
         StringLength(100),
         Display(Name = "Açıklama")
        ]
        public string Description { get; set; }

        [Column(TypeName = "varchar(150)"),
         StringLength(150),
         Display(Name = "Resim Dosyası")
        ]
        public string PictureUrl { get; set; }

        [Display(Name = "Görüntülüme Sırası")]
        public int DisplayIndex { get; set; }
    }
}
