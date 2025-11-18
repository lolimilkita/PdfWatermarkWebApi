using System.ComponentModel.DataAnnotations;

namespace PdfWatermarkWebApi.Models
{
    public class AuthRequest
    {
    }

    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
