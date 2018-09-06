using System.ComponentModel.DataAnnotations;

namespace Naitzel.Intranet.Infra.Security.AdminLte.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Sobre Nome")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirma senha")]
        public string ConfirmPassword { get; set; }
    }
}