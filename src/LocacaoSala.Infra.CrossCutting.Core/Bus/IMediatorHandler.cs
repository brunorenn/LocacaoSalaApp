using LocacaoSala.Infra.CrossCutting.Core.Commands;
using System.Threading.Tasks;

namespace LocacaoSala.Application.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<CommandResult> Handle<T>(T command) where T : Command;
    }
}
