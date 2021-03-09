using System.ComponentModel.DataAnnotations;

namespace _03_Tutorial.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "密码")]
        public string Password { get; set; }
    }
}
