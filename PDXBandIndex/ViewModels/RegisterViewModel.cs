using System.ComponentModel.DataAnnotations;

namespace PDXBandIndex.ViewModels
{
  public class RegisterViewModel
  {
    [Required]
    [EmailAddress]
    [Display(nameof = "Email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(nameof = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Comare("Password", ErrorMessage = "Your passwords do not match. Rock ON!")]
    public string ConfirmPassword { get; set; }
    


  }
}