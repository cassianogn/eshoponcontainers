using Cassiano.EShopOnContainers.Core.Domain.Services.DomainNotifications;
using Microsoft.AspNetCore.Http;

namespace Cassiano.EShopOnContainers.Core.Infrastructure.In.HttpMinimal
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
