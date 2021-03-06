﻿using LocacaoSala.Application.Domain.Enums;
using LocacaoSala.Application.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocacaoSala.Application.Domain.Entities
{
    public class Sala : BaseEntity
    {
        public Sala(Guid id, string nome, IEnumerable<Assento> assentos) : base(id, nome)
        {
            _assentos = new List<Assento>();
            _participantes = new List<Pessoa>();

            assentos.ToList().ForEach(IncluirAssento);
        }

        public Palestrante Palestrante { get; private set; }
        private List<Pessoa> _participantes { get; set; }
        private List<Assento> _assentos;

        public IReadOnlyList<Assento> Assentos { get { return _assentos.AsReadOnly(); } }
        public IReadOnlyList<Pessoa> Participantes { get { return _participantes.AsReadOnly(); } }


        public void DefinirPalestrante(Palestrante palestrante)
        {
            Palestrante = palestrante;
        }

        public void ReservarAssento(Pessoa pessoa)
        {
            if (!_assentos.Any(x =>
                x.Voucher.Id == pessoa.VoucherParticipante.Id))
                throw new Exception($"Assento já reservado para o voucher {pessoa.VoucherParticipante.Id}");

            if (pessoa.TipoPessoa == TipoPessoaEnum.Palestrante)
                throw new Exception("Nao é possível alocar assento para palestrante");

            if (_participantes.Any(x => x.Equals(pessoa)))
                throw new Exception("Partipante já está vinculado a sala");

            if (_participantes.Any(x => x.Voucher == pessoa.Voucher))
                throw new Exception("Existem dois participantes com o mesmo voucher");

            _participantes.Add(pessoa);
        }

        public int QuantidadeAssentosDisponiveis()
        {
            return _assentos.Count - _participantes.Count;
        }

        public void DisponibilizarAssento(Pessoa pessoa)
        {
            if (pessoa.TipoPessoa != TipoPessoaEnum.CancelouVoucher)
                throw new Exception("Voucher não foi cancelado");

            if (_participantes.Any(x => x.Equals(pessoa)))
                _participantes.Remove(pessoa);
        }

        public void IncluirAssento(Assento assento)
        {
            if (_assentos.Any(x => x.Equals(assento)))
                throw new Exception("Assento já vinculado a sala");

            _assentos.Add(assento);
        }
    }
}
