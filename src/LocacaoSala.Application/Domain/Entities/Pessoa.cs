using LocacaoSala.Application.Domain.Enums;
using LocacaoSala.Application.Domain.ValueObjects;
using System;

namespace LocacaoSala.Application.Domain.Entities
{
    public abstract class Pessoa : BaseEntity
    {
        public Pessoa(Guid id, string nome, TipoPessoaEnum tipoPessoaEnum, VoucherParticipante voucherParticipante) : base(id, nome)
        {
            if (Id == Guid.Empty)
                throw new Exception("Id da pessoa está vazio");

            if (string.IsNullOrEmpty(Nome))
                throw new Exception("Nome da pessoa está vazio");

            TipoPessoa = tipoPessoaEnum;
            VoucherParticipante = voucherParticipante;
        }

        public VoucherParticipante VoucherParticipante { get; private set; }
        public TipoPessoaEnum TipoPessoa { get; private set; }
        public Voucher Voucher { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public override void Inativar()
        {
            base.Inativar();
            TipoPessoa = TipoPessoaEnum.CancelouVoucher;
        }
    }
}
