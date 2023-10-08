using DTI.Core.Domain.Services.DomainNotifications;
using Microsoft.AspNetCore.Http;

namespace DTI.Core.Infra.In.HttpMinimal
{
    public static class MinimalAPIResponse
    {
        public static IResult CareErrors(Func<IResult> responseData, DomainNotificationService domainNotificationService)
        {
            if (domainNotificationService.HasNotification())
                return TypedResults.BadRequest(domainNotificationService.GetAll());

            return responseData.Invoke();
        }
    }
}
