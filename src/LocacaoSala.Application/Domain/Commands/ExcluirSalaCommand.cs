using LocacaoSala.Infra.CrossCutting.Core.Commands;
using System;

namespace LocacaoSala.Application.Domain.Commands
{
    public class ExcluirSalaCommand: Command
    {
        public Guid Id { get; set; }
    }
}
