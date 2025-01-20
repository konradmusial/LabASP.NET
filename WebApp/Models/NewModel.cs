using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Genre { get; set; }

        public decimal Price { get; set; }
    }
}