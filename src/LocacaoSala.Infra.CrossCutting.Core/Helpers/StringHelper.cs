namespace LocacaoSala.Infra.CrossCutting.Core.Helpers
{
    public static class StringHelper
    {
        public static bool Equals(string valorA, string valorB)
        {
            return string.Equals(valorA, valorB, System.StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
