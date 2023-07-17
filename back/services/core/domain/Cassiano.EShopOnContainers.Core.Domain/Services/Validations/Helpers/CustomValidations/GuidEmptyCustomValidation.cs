using FluentValidation;

namespace Cassiano.EShopOnContainers.Core.Domain.Services.Validations.Helpers.CustomValidations
{
    internal class GuidEmptyCustomValidation : AbstractValidator<Guid?>
    {
        public GuidEmptyCustomValidation(string propriedade, ValidationErrorMessageService validationErrorMessageService)
        {

            var guidVazio = Guid.Empty;
            RuleFor(guid => guid).Must(guid => !(guid == guidVazio || guid == null))
                .WithMessage(validationErrorMessageService.Required(propriedade));
        }
    }
}
