using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoSala.Application.Domain.Entities
{
    public class Participante : Pessoa
    {
        public Participante(Guid id, string nome, decimal valorVoucher, DateTime dataCompra) : base(id, nome)
        {
            ValorVoucher = valorVoucher;
            DataCompra = dataCompra;
            TipoPessoa = Enums.TipoPessoaEnum.Participante;
        }

        public decimal ValorVoucher { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
