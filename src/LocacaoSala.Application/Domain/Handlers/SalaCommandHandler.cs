using LocacaoSala.Application.Domain.Commands;
using LocacaoSala.Application.Domain.Factories;
using LocacaoSala.Application.Domain.Repositories;
using LocacaoSala.Infra.CrossCutting.Core.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LocacaoSala.Application.Domain.Handlers
{
    public class SalaCommandHandler: IRequestHandler<IncluirSalaCommand, CommandResult>,
                                     IRequestHandler<EditarSalaCommand, CommandResult>,
                                     IRequestHandler<ExcluirSalaCommand, CommandResult>
                                      
    {
        private ISalaRepository _salaRepository;

        public SalaCommandHandler(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public async Task<CommandResult> Handle(ExcluirSalaCommand command, CancellationToken cancellationToken)
        {
            if (command.Id == Guid.Empty)
                return new CommandResult(false, "Informe o Id da sala");

            if (!_salaRepository.Existe(command.Id))
                return new CommandResult(false, "Sala não encontrada");

            _salaRepository.Excluir(command.Id);

            return await Task.FromResult(new CommandResult(true, "Sala excluida com sucesso"));
        }

        public async Task<CommandResult> Handle(EditarSalaCommand command, CancellationToken cancellationToken)
        {
            if (!_salaRepository.Existe(command.Id))
                return new CommandResult(false, "Sala não encontrada");

            var sala = SalaFactory.Create(command.Id, command);

            _salaRepository.Atualizar(sala);

            return await Task.FromResult(new CommandResult(true, "Sala editada com sucesso"));
        }

        public async Task<CommandResult> Handle(IncluirSalaCommand command, CancellationToken cancellationToken)
        {
            var sala = SalaFactory.Create(Guid.NewGuid(), command);

            _salaRepository.Incluir(sala);

            return await Task.FromResult(new CommandResult(true, "Sala incluida com sucesso"));
        }
    }
}
