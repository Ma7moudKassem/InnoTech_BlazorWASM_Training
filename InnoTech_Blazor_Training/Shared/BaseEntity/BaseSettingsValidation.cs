namespace InnoTech_Blazor_Training.Shared
{
    public class BaseSettingsValidation<TEntity> : AbstractValidator<TEntity> where TEntity : BaseSettingsEntity
    {
        public BaseSettingsValidation()
        {
            int nameMaxLenght = 20;
            RuleFor(e => e.Name).NotEmpty()
                .WithMessage($"{typeof(TEntity).Name} Name is not empty");

            RuleFor(e => e.Name).MaximumLength(nameMaxLenght)
                .WithMessage($"{typeof(TEntity).Name} Name max lenght = {nameMaxLenght} is not empty");
        }
    }
}
