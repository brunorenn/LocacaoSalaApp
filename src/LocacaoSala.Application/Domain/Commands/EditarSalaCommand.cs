using System;

namespace LocacaoSala.Application.Domain.Commands
{
    public class EditarSalaCommand: SalaBaseCommand
    {
        public Guid Id { get; set; }
    }
}
