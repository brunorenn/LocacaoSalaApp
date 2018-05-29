using LocacaoSala.Application.Domain.ValueObjects;
using System;

namespace LocacaoSala.Application.Domain.Entities
{
    public class Voluntario : Pessoa
    {
        public Voluntario(Guid id, string nome, Voucher voucher) : base(id, nome, new VoucherParticipante(voucher.Id, 0, DateTime.Now))
        {
            if (VoucherParticipante.Valor != 0)
                throw new InvalidOperationException("Valor do voucher do voluntário diferente de 0");

            Tipo = Enums.TipoPessoaEnum.Voluntario;
        }
    }
}
