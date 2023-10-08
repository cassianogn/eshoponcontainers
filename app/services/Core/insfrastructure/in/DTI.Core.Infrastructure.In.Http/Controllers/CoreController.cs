using DTI.Core.Domain.Auth;
using DTI.Core.Domain.Services.DomainNotifications;
using DTI.Core.Infra.In.Http.Services;
using Microsoft.AspNetCore.Mvc;

namespace DTI.Core.Infra.In.Http.Controllers
{
    public abstract class CoreController : ControllerBase
    {
        protected readonly DomainNotificationService DomainNotificationService;
        protected readonly HttpAuthService HttpAuthService;

        protected CoreController(DomainNotificationService domainNotificationService, UserHttpRequest usuarioHttpRequest)
        {
            DomainNotificationService = domainNotificationService;
            HttpAuthService = new HttpAuthService(GetAuthParameters(), usuarioHttpRequest);
        }

        protected abstract HttpAuthParameters GetAuthParameters();

        protected bool HasAuthorizationToRead() => HttpAuthService.HasAuthorizationToRead();
        protected bool HasAuthorizationToAdd() => HttpAuthService.HasAuthorizationToAdd();
        protected bool HasAuthorizationToUpdate() => HttpAuthService.HasAuthorizationToUpdate();
        protected bool HasAuthorizationToDelete() => HttpAuthService.HasAuthorizationToDelete();

        protected bool IsValidOperation() => !DomainNotificationService.HasNotification();
        protected IActionResult ResponseCareErrors(Func<IActionResult> responseData)
        {
            if (!IsValidOperation())
                return BadRequest(DomainNotificationService.GetAll());

            return responseData.Invoke();
        }


    }
}
