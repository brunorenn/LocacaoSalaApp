using LocacaoSala.Application.Domain.Enums;
using LocacaoSala.Application.Domain.ValueObjects;
using LocacaoSala.Infra.CrossCutting.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocacaoSala.Application.Domain.Entities
{
    public class Palestrante : Pessoa
    {
        public Palestrante(Guid id, string nome, Voucher voucher) : this(id, nome, new VoucherParticipante(voucher.Id, 0, DateTime.Now), new List<string>())
        {
        }

        public Palestrante(Guid id, string nome, VoucherParticipante voucherParticipante, List<string> qualificacoes) : base(id, nome, voucherParticipante)
        {
            Tipo = TipoPessoaEnum.Palestrante;
            _qualificacoes = new List<string>();

            if (VoucherParticipante.Valor != 0)
                throw new InvalidOperationException("Valor do voucher do palestrante diferente de 0");

            qualificacoes.ForEach(IncluirQualificacao);
        }

        private List<string> _qualificacoes;
        public IReadOnlyList<string> Qualificacoes { get { return _qualificacoes.AsReadOnly(); } }

        public void IncluirQualificacao(string qualificacao)
        {
            if (!QualificacaoVinculada(qualificacao))
                _qualificacoes.Add(qualificacao);
        }

        public bool QualificacaoVinculada(string qualificacao)
        {
            return _qualificacoes.Any(x => StringHelper.Equals(x, qualificacao));
        }
    }
}
