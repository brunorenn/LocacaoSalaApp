using LocacaoSala.Application.Core.Bus;
using LocacaoSala.Infra.CrossCutting.Core.Commands;
using MediatR;
using System.Threading.Tasks;

namespace LocacaoSala.Infra.CrossCutting.Core.Bus
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CommandResult> Handle<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }

        public async Task<TResult> Query<TInput, TResult>(TInput parameter)
            where TInput : IRequest<TResult>
            where TResult : class
        {
            return await _mediator.Send(parameter);
        }
    }
}
