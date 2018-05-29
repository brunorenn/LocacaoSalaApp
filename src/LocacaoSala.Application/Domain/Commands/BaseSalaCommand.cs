using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoSala.Application.Domain.Commands
{
    public abstract class BaseSalaCommand
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadeAssentos { get; set; }
    }
}
