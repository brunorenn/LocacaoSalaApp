using LocacaoSala.Application.Domain.Enums;
using LocacaoSala.Application.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoSala.Application.Domain.Entities
{
    public abstract class Pessoa : BaseEntity
    {
        public Pessoa(Guid id) : base(id)
        {
        }

        public Pessoa(Guid id, string nome): base(id, nome)
        {

        }

        public TipoPessoaEnum TipoPessoa { get; set; }
        public Voucher Voucher { get; set; }

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
