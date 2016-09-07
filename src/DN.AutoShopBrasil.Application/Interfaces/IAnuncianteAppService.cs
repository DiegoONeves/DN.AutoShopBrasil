using DN.AutoShopBrasil.Application.DTO;
using DN.AutoShopBrasil.Application.Validation;

namespace DN.AutoShopBrasil.Application.Interfaces
{
    public interface IAnuncianteAppService
    {
        ValidationAppResult CadastrarAnunciante(AnuncianteNovoDTO anuncianteNovo);
    }
}
