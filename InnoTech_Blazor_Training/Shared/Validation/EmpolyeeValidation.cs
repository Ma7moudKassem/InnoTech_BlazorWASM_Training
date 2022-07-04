namespace InnoTech_Blazor_Training.Shared.Validation
{
    public class EmpolyeeValidation : BaseSettingsValidation<Empolyee>
    {
        public EmpolyeeValidation()
        {
            const int mobileMaxLenght = 50;
            RuleFor(e => e.Age).GreaterThanOrEqualTo(15)
                .WithMessage($"{typeof(Empolyee).Name} Age Should be GreaterThan Or Equal To 2");

            RuleFor(e => e.Mobile).NotEmpty()
                .WithMessage($"{typeof(Empolyee).Name} Mobile is required");

            RuleFor(e => e.Mobile).MaximumLength(mobileMaxLenght)
                .WithMessage($"{typeof(Empolyee).Name} Mobile Maximum Length is 50");
        }
    }
}
