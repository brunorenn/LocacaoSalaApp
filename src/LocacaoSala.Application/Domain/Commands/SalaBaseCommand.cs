using LocacaoSala.Infra.CrossCutting.Core.Commands;

namespace LocacaoSala.Application.Domain.Commands
{
    public abstract class SalaBaseCommand: Command
    {
        public string Nome { get; set; }
        public int QuantidadeAssentos { get; set; }
    }
}
