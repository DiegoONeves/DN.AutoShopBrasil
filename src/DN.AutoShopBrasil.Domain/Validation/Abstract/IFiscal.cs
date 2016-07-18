using DN.AutoShopBrasil.Domain.ValueObjects;

namespace DN.AutoShopBrasil.Domain.Validation.Abstract
{
    public interface IFiscal<in TEntity>
    {
        ValidationResult Validar(TEntity entity);
    }
}
