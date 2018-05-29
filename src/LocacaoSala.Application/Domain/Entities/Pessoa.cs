using LocacaoSala.Application.Domain.Enums;
using LocacaoSala.Application.Domain.ValueObjects;
using System;

namespace LocacaoSala.Application.Domain.Entities
{
    public abstract class Pessoa : BaseEntity
    {
        public Pessoa(Guid id) : base(id)
        {
        }

        public Pessoa(Guid id, string nome, VoucherParticipante voucherParticipante) : base(id, nome)
        {
            if (Id == Guid.Empty)
                throw new Exception("Id da pessoa está vazio");

            if (string.IsNullOrEmpty(nome))
                throw new Exception("Nome está em branco");

            VoucherParticipante = voucherParticipante;
        }

        public TipoPessoaEnum Tipo { get; protected set; }
        public VoucherParticipante VoucherParticipante { get; private set; }

        public override void Inativar()
        {
            base.Inativar();
            Tipo = TipoPessoaEnum.CancelouVoucher;
        }

        public override bool Equals(object obj)
        {
            var pessoa = obj as Pessoa;
            return !ReferenceEquals(pessoa, null) && pessoa.Id == Id;
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

    }
}
