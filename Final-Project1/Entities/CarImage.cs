using System.ComponentModel.DataAnnotations;

namespace Final_Project1.Entities
{
    public class CarImage
    {
        [Key]
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public int CarDetailId { get; set; }
        public CarDetail CarDetail { get; set; }
    }
}
