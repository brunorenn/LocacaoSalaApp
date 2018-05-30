using FluentValidation;
using LocacaoSala.Application.Domain.Commands;

namespace LocacaoSala.Application.Domain.Validations
{
    public abstract class SalaValidation<T> : AbstractValidator<T> where T : SalaBaseCommand
    {
        protected void ValidarNome()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Informe o nome");
        }

        protected void ValidarAssentos()
        {
            RuleFor(x => x.QuantidadeAssentos)
            .GreaterThan(0)
            .WithMessage("Quantidade de assentos deve ser maior que 0");
        }
    }
}
