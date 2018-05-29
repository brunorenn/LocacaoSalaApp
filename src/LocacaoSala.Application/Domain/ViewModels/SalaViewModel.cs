using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoSala.Application.Domain.ViewModels
{
    public class SalaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadeAssentos { get; set; }
        public int QuantidadeAssentosDisponiveis { get; set; }
    }
}
