using DTI.Core.Domain.Auth.Claims;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DTI.Core.Domain.Auth
{
    public abstract  class UserHttpRequest
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IReadOnlyCollection<ClaimApp> _claimsApp;
        protected UserHttpRequest(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _claimsApp = GetApplicationClaims().ToList();
        }
        /// <summary>
        /// get policies from application. In your application, generate a static class if method to return a list of ClaimApp with combinations of all claims in your application.
        /// ex: 
        /// public static class ClaimsApp
        /// {
        ///     public static IEnumerable<ClaimApp> GetAll()
        ///     {
        ///         return new List<ClaimApp>()
        ///         {
        ///             new ClaimApp(ClaimAppType.PRODUCT, ClaimAppValue.ADD),
        ///             new ClaimApp(ClaimAppType.PRODUCT, ClaimAppValue.READ),
        ///             new ClaimApp(ClaimAppType.PRODUCT, ClaimAppValue.UPDATE),
        ///             new ClaimApp(ClaimAppType.PRODUCT, ClaimAppValue.DELETE),
        ///             
        ///             new ClaimApp(ClaimAppType.CATEGORY, ClaimAppValue.ADD),
        ///             new ClaimApp(ClaimAppType.CATEGORY, ClaimAppValue.READ),
        ///             new ClaimApp(ClaimAppType.CATEGORY, ClaimAppValue.UPDATE),
        ///             new ClaimApp(ClaimAppType.CATEGORY, ClaimAppValue.DELETE)
        ///         };
        ///     }
        /// }
        /// </summary>
        /// <returns>use the example and return ClaimsApp.GetAll()</returns>
        protected abstract IEnumerable<ClaimApp> GetApplicationClaims();
        public bool IsAuth() => _accessor != null && _accessor.HttpContext.User.Identity!.IsAuthenticated;
        public IEnumerable<Claim> ClaimsInHttpRequest() => _accessor.HttpContext.User.Claims;
        public Guid Id() => !IsAuth() ? Guid.Empty : new Guid(ClaimsInHttpRequest().First(claim => claim.Type.Contains("nameidentifier")).Value);
        public bool HasClaim(ClaimApp model) => ClaimsInHttpRequest().Any(claim => $"{claim.Type}.{claim.Value}" == model.Nome);

        public IEnumerable<ClaimApp> ClaimsProvidedFromApp() => _claimsApp;
    }
}
