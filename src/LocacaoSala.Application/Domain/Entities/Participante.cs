using LocacaoSala.Application.Domain.Enums;
using LocacaoSala.Application.Domain.ValueObjects;
using System;

namespace LocacaoSala.Application.Domain.Entities
{
    public class Participante : Pessoa
    {
        public Participante(Guid id, string nome, VoucherParticipante voucher)
            : base(id, nome, TipoPessoaEnum.Participante, voucher)
        {
            if (VoucherParticipante.Valor < 0)
                throw new InvalidOperationException("Valor do voucher do participante está menor que 0");
        }
    }
}