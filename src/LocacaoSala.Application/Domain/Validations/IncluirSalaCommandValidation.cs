using LocacaoSala.Application.Domain.Commands;

namespace LocacaoSala.Application.Domain.Validations
{
    public class IncluirSalaCommandValidation : SalaValidation<IncluirSalaCommand>
    {
        public IncluirSalaCommandValidation()
        {
            ValidarNome();
            ValidarAssentos();
        }
    }
}
