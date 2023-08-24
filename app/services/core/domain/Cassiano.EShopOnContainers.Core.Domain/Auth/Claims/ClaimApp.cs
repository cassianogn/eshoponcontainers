namespace Cassiano.EShopOnContainers.Core.Domain.Auth.Claims
{
    public class ClaimApp
    {

        public ClaimApp(string claimTipo, string claimValor)
        {
            ClaimTipo = claimTipo;
            ClaimValor = claimValor;
        }
        public string ClaimTipo { get; private set; }
        public string ClaimValor { get; private set; }

        public string Nome { get { return $"{ClaimTipo}.{ClaimValor}"; } }
        public string Resumo { get { return $"{ClaimTipo.Split('.')[1]}.{ClaimValor.Split('.')[1]}"; } }
    }
}
