using FluentValidation;
using LocacaoSala.Application.Domain.Commands;
using System;

namespace LocacaoSala.Application.Domain.Validations
{
    public class ExcluirSalaCommandValidation : AbstractValidator<ExcluirSalaCommand>
    {
        public ExcluirSalaCommandValidation()
        {
            ValidarId();
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
