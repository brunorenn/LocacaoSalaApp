using MediatR;
using System;

namespace LocacaoSala.Infra.CrossCutting.Core.Commands
{
    public abstract class Command : IRequest<CommandResult>
    {
        public Guid Uid { get; set; }
    }
}
