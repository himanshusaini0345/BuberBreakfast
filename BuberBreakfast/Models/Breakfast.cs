using BuberBreakfast.Exceptions.Breakfast;

namespace BuberBreakfast.Models
{
    public class Breakfast
    {
        public Breakfast(Guid id, string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime lastModifiedDateTime, List<string> savory, List<string> sweet)
        {
            var errors = new List<string>();

            if (name.Length < MinNameLength || name.Length > MaxNameLength)
            {
                errors.Add($"Name must be between {MinNameLength} and {MaxNameLength} characters.");
            }

            if (description.Length < MinDescriptionLength || description.Length > MaxDescriptionLength)
            {
                errors.Add($"Description must be between {MinDescriptionLength} and {MaxDescriptionLength} characters.");
            }

            // Add any additional validations here...

            if (errors.Count > 0)
            {
                throw new BreakfastValidationException(errors);
            }

            Id = id;
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            LastModifiedDateTime = lastModifiedDateTime;
            Savory = savory;
            Sweet = sweet;
        }

        public const int MinNameLength = 3;
        public const int MaxNameLength = 50;

        public const int MinDescriptionLength = 50;
        public const int MaxDescriptionLength = 150;
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime StartDateTime { get; }
        public DateTime EndDateTime { get; }
        public DateTime LastModifiedDateTime { get; }
        public List<string> Savory { get; }
        public List<string> Sweet { get; }
    }
}
