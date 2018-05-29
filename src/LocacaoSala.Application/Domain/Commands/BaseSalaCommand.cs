using System;

namespace LocacaoSala.Application.Domain.Commands
{
    public abstract class BaseSalaCommand
    {
        public Guid UId { get; set; }
        public string Nome { get; set; }
        public int QuantidadeAssentos { get; set; }
    }
}
