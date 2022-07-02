namespace InnoTech_Blazor_Training.Shared.Validation
{
    public class EmpolyeeValidation : AbstractValidator<Empolyee>
    {
        public EmpolyeeValidation()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage($"{nameof(Empolyee)} Name is required");
            RuleFor(e => e.Age).GreaterThanOrEqualTo(15).WithMessage($"{nameof(Empolyee)} Age Should be GreaterThan Or Equal To 2");
            RuleFor(e => e.Mobile).NotEmpty().WithMessage($"{nameof(Empolyee)} Mobile is required");
            RuleFor(e => e.Mobile).MaximumLength(50).WithMessage($"{nameof(Empolyee)} Mobile Maximum Length is 50");
        }

       
    }
}
