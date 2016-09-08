using DN.AutoShopBrasil.Application.DTO;
using DN.AutoShopBrasil.Domain.Entities;
using DN.AutoShopBrasil.Domain.ValueObjects;

namespace DN.AutoShopBrasil.Application.Interfaces
{
    public interface IAnuncianteAppService
    {
        ValidationResult CadastrarAnunciante(AnuncianteNovoDTO anuncianteNovo);
        Anunciante Autenticar(string email, string senha);
    }
}
