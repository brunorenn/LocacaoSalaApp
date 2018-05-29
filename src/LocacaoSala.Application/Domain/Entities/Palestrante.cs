using LocacaoSala.Application.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoSala.Application.Domain.Entities
{
    public class Palestrante : Pessoa
    {
        public Palestrante(Guid id, string nome) : base(id, nome)
        {
            TipoPessoa = TipoPessoaEnum.Palestrante;
        }

        public List<string> Qualificacoes { get; set; }
    }
}
