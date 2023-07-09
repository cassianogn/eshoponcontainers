namespace Cassiano.EShopOnContainers.Core.Infrastructure.In.Http.Services
{
    public class HttpAuthParameters
    {
        private HttpAuthParameters(string? currentClaimType, bool requiredAuth)
        {
            CurrentClaimType = currentClaimType;
            RequiredAuth = requiredAuth;
        }

        public string? CurrentClaimType { get; private set; }
        public bool RequiredAuth { get; private set; }

        public static HttpAuthParameters GetRequiredAuth(string currentClaimType) => new(currentClaimType, true);
        public static HttpAuthParameters GetAnonymousAuth() => new(null, false);

    }
}
