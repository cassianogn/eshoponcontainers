using FluentValidation;

namespace Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers.CustomValidations
{
    internal class GuidEmptyCustomValidation : AbstractValidator<Guid?>
    {
        public GuidEmptyCustomValidation(string propriedade)
        {

            var guidVazio = Guid.Empty;
            RuleFor(guid => guid).Must(guid => !(guid == guidVazio || guid == null))
                .WithMessage(ValidationErrorMessage.Required(propriedade));
        }
    }
}
