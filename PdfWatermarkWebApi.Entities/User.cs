using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfWatermarkWebApi.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsGoogleLogin { get; set; }
        public bool IsEmailLogin { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class UserAuth
    {
        public Guid UserId { get; set; }
        public string? Password { get; set; }
    }

    public class ApplicationUser
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsGoogleLogin { get; set; }
        public bool IsEmailLogin { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    
}
