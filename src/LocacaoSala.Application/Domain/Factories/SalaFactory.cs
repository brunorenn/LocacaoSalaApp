using LocacaoSala.Application.Domain.Commands;
using LocacaoSala.Application.Domain.Entities;
using LocacaoSala.Application.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace LocacaoSala.Application.Domain.Factories
{
    public static class SalaFactory
    {
        public static Sala Create(Guid id, SalaBaseCommand command)
        {
            var assentos = new List<Assento>();

            for (int i = 0; i < command.QuantidadeAssentos; i++)
                assentos.Add(new Assento(i + 1, new Voucher(Guid.NewGuid())));

            return new Sala(id, command.Nome, assentos);
        }
    }
}
