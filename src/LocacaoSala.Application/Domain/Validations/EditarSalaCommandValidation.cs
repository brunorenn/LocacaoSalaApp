using FluentValidation;
using LocacaoSala.Application.Domain.Commands;
using System;

namespace LocacaoSala.Application.Domain.Validations
{
    public class EditarSalaCommandValidation: SalaValidation<EditarSalaCommand>
    {
        public EditarSalaCommandValidation()
        {
            ValidarId();
            ValidarNome();
            ValidarAssentos();
        }

        private void ValidarId()
        {
            RuleFor(x => x.Id)
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Informe o Id");
        }
    }
}
