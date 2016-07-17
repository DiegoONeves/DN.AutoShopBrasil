using DN.AutoShopBrasil.Domain.Entities;
using DN.AutoShopBrasil.Domain.ValueObjects;
using System;

namespace DN.AutoShopBrasil.Domain.Contracts.Services
{
    public interface IAnuncianteService: IDisposable
    {
        ValidationResult CadastrarNovoAnunciante(Anunciante anunciante);
        ValidationResult AlterarAnunciante(Anunciante anunciante);
    }
}
