using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoSala.Application.Domain.Entities
{
    public class Voluntario : Pessoa
    {
        public Voluntario(Guid id, string nome) : base(id, nome)
        {
            TipoPessoa = Enums.TipoPessoaEnum.Voluntario;
        }
    }
}
