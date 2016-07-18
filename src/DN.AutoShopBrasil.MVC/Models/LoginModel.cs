using System.ComponentModel.DataAnnotations;

namespace DN.AutoShopBrasil.MVC.Models
{
    public class LoginModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        public string Email { get; set; }
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Display(Name = "Manter logado")]
        public bool ManterLogado { get; set; }
    }
}