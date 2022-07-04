namespace InnoTech_Blazor_Training.Shared.Validation
{
    public class StudentValidation : BaseSettingsValidation<Student>
    {
        public StudentValidation()
        {
            const int mobileMaxLenght = 50;
            RuleFor(e => e.GPA).GreaterThanOrEqualTo(2)
                .WithMessage($"{typeof(Student).Name} Age Should be GreaterThan Or Equal To 2");

            RuleFor(e => e.Mobile).NotEmpty()
                .WithMessage($"{typeof(Student).Name} Mobile is required");

            RuleFor(e => e.Mobile).MaximumLength(mobileMaxLenght)
                .WithMessage($"{typeof(Student).Name} Mobile Maximum Length is {mobileMaxLenght}");
        }
    }
}
