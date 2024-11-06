namespace BuberBreakfast.Exceptions.Breakfast
{
    public class BreakfastValidationException: Exception
    {
        public List<string> ValidationErrors { get; set; } = null!;
        public BreakfastValidationException(List<string> errors)
            : base()
        {
            ValidationErrors = errors;
        }
    }
}
