using System.ComponentModel.DataAnnotations;

namespace Naitzel.Intranet.Infra.Security.AdminLte.ViewModel
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name = "Usuário/Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembre de mim?")]
        public bool RememberMe { get; set; }
    }
}