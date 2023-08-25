using DTI.Core.Domain.Auth;
using DTI.Core.Domain.Auth.Claims;

namespace DTI.Core.Infrastructure.In.Http.Services
{
    public class HttpAuthService
    {
        private readonly IReadOnlyCollection<ClaimApp> _controllerClaims;

        public HttpAuthService(HttpAuthParameters authParameters , UserHttpRequest userHttpRequest)
        {
            RequiredAuth = authParameters.RequiredAuth;
            if (!RequiredAuth) return;

            CurrentClaimType = authParameters.CurrentClaimType;
            UserHttpRequest = userHttpRequest;
            _controllerClaims = userHttpRequest.ClaimsProvidedFromApp().Where(policyUsuarioApp => policyUsuarioApp.ClaimTipo == CurrentClaimType).ToList();
        }

        public UserHttpRequest? UserHttpRequest { get; private set; }
        public bool RequiredAuth { get; private set; }
        public string? CurrentClaimType { get; private set; }

        private ClaimApp GetControllerClaimByClaimValue(string claimValue)
        {
            var policy = _controllerClaims.FirstOrDefault(claimController => claimController.ClaimValor == claimValue);
            if (policy == null)
                throw new Exception($"the access required a policy that does not exist in the application. Name of claim: {CurrentClaimType}.{claimValue}");
            return policy;
        }

        public bool HasAuthorization(ClaimApp claimApp) => !RequiredAuth || UserHttpRequest!.HasClaim(claimApp);
        public bool HasAuthorization(string claimValue) => !RequiredAuth || UserHttpRequest!.HasClaim(GetControllerClaimByClaimValue(claimValue));
        public bool HasAuthorizationToRead() => HasAuthorization(ClaimAppValue.READ);
        public bool HasAuthorizationToAdd() => HasAuthorization(ClaimAppValue.ADD);
        public bool HasAuthorizationToUpdate() => HasAuthorization(ClaimAppValue.UPDATE);
        public bool HasAuthorizationToDelete() => HasAuthorization(ClaimAppValue.DELETE);


    }
}
