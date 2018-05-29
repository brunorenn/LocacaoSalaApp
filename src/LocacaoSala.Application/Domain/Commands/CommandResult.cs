namespace LocacaoSala.Application.Domain.Commands
{
    public class CommandResult
    {
        public CommandResult(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; }
    }
}
