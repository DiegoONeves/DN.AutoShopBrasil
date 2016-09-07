namespace DN.AutoShopBrasil.Application.Validation
{
    public class ValidationAppError
    {
        public string Message { get; set; }
        public ValidationAppError(string message)
        {
            Message = message;
        }
    }
}
