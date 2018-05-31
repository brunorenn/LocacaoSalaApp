using LocacaoSala.Infra.CrossCutting.Core.Commands;
using MediatR;
using System.Threading.Tasks;

namespace LocacaoSala.Application.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<CommandResult> Handle<T>(T command) where T : Command;
        Task<TResult> Query<TInput, TResult>(TInput parameter) where TResult : class
                                                               where TInput : IRequest<TResult>;
    }
}
