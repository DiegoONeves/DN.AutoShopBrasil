using DN.AutoShopBrasil.Domain.ValueObjects;

namespace DN.AutoShopBrasil.Domain.Validation.Abstract
{
    public interface ISelfValidator
    {
        ValidationResult ResultadoValidacao { get; }
        bool IsValid();
    }
}
