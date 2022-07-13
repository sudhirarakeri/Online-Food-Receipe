using Microsoft.AspNetCore.Http;

namespace OnlineFoodReceipe.Models
{
    public class Img
    {
        public string RName { get; set; }
        public IFormFile Photo { get; set; }
        public string Youtube { get; set; }
        public string Ingredient { get; set; }
        public string HTM { get; set; }
    }
}
