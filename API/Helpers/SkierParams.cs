using System.ComponentModel.DataAnnotations;

namespace API.Helpers
{
    public class SkierParams
    {
        [Required]
        public int Age { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public string Discipline { get; set; }
    }
}
