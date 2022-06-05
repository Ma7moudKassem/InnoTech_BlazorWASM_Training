namespace InnoTech_Blazor_Training.Shared.Validation
{
    public class StudentValidation : AbstractValidator<Student>
    {
        public StudentValidation()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage($"{nameof(Student)} Name is required");
            RuleFor(e => e.GPA).GreaterThanOrEqualTo(2).WithMessage($"{nameof(Student)} Age Should be GreaterThan Or Equal To 2");
            RuleFor(e => e.Mobile).NotEmpty().WithMessage($"{nameof(Student)} Mobile is required");
            RuleFor(e => e.Mobile).MaximumLength(50).WithMessage($"{nameof(Student)} Mobile Maximum Length is 50");
        }
    }
}
