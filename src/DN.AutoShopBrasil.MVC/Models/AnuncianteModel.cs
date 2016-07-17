using System.ComponentModel.DataAnnotations;

namespace DN.AutoShopBrasil.MVC.Models
{
    public class AnuncianteModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O {0} é inválido")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Password)]
        [MaxLength(20, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(6, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        public string Senha { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression(@"^\({1}\d{2}\) {1}\d{4,5}\-{1}\d{4}$", ErrorMessage = "Campo {0} inválido")]
        public string Telefone { get; set; }
    }
}