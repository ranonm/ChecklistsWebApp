using System.ComponentModel.DataAnnotations;

namespace Checklists.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}