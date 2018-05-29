using System;

namespace LocacaoSala.Application.Domain.Commands
{
    public class EditarSalaCommand: BaseSalaCommand
    {
        public Guid Id { get; set; }
    }
}
