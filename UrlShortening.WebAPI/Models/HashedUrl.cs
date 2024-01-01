using System.ComponentModel.DataAnnotations;

namespace UrlShortening.WebAPI.Models
{
    public class HashedUrl
    {
        [Key]
        public Guid Id { get; set; }

        public string DecodedUrl { get; set; }

        public string EncodedUrl { get; set; }

        public string Code { get; set; }
    }
}
