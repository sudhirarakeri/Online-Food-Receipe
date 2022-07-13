using System.ComponentModel.DataAnnotations;

namespace OnlineFoodReceipe.Models
{
    public class Menu
    {
        public int RId { get; set; }
        [Required]
        public string RName { get; set; }
        public string Photo { get; set; }
        public string Youtube { get; set; }
        public string Ingredient { get; set; }
        public string HTM { get; set; }
        [Required]
        public string VNB { get; set; }
        public int RoleId { get; set; }
        [Required]
        public string State { get; set; }
        public int UserId { get; set; }
    }
}
