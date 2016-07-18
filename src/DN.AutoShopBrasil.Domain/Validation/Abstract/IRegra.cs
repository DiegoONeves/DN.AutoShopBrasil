namespace DN.AutoShopBrasil.Domain.Validation.Abstract
{
    public interface IRegra<in TEntity>
    {
        string MensagemErro { get; }
        bool Validar(TEntity entity);
    }
}
