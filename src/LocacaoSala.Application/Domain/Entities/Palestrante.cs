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
        public Palestrante(Guid id, string nome, Voucher voucher) : base(id, nome, TipoPessoaEnum.Palestrante, new VoucherParticipante(voucher.Id, 0, DateTime.Now))
        {
            _qualificacoes = new List<string>();
        }

        private List<string> _qualificacoes { get; set; }
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