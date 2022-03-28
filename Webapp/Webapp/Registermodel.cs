using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Webapp;

public class Registermodel
{
   [Required]
   [DataType(DataType.EmailAddress)]
   public string Email { get; set; }
   
   [Required]
   public string UserName { get; set; }
   
   [Required]
   [DataType(DataType.Password)]
   public string password { get; set; }
   
   [DataType(DataType.Password)]
   [Compare(nameof(password), ErrorMessage = "confirmation is not equal to password")]
   public string confirmpassword { get; set; }
}