using LocacaoSala.Application.Domain.Commands;
using LocacaoSala.Application.Domain.Entities;
using LocacaoSala.Application.Domain.Repositories;
using LocacaoSala.Application.Domain.ValueObjects;
using LocacaoSala.Application.Domain.ViewModels;
using LocacaoSala.Infra.CrossCutting.Core.Commands;
using MediatR;
using System;
using System.Collections.Generic;
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

        public IEnumerable<SalaViewModel> Handle()
        {
            return _salaRepository.ObterTodos();
        }

        public SalaViewModel Handle(Guid id)
        {
            return _salaRepository.Obter(id);
        }

        public async Task<CommandResult> Handle(ExcluirSalaCommand command, CancellationToken cancellationToken)
        {
            if (command.Id == Guid.Empty)
            {
                return new CommandResult(false, "Informe o Id da sala");
            }

            if (!_salaRepository.Existe(command.Id))
            {
                return new CommandResult(false, "Sala não encontrada");
            }

            _salaRepository.Excluir(command.Id);

            return await Task.FromResult(new CommandResult(true, "Sala excluida com sucesso"));
        }

        public async Task<CommandResult> Handle(EditarSalaCommand command, CancellationToken cancellationToken)
        {
            if (!_salaRepository.Existe(command.Id))
            {
                return new CommandResult(false, "Sala não encontrada");
            }

            var assentos = new List<Assento>();

            for (int i = 0; i < command.QuantidadeAssentos; i++)
            {
                assentos.Add(new Assento(i + 1, new Voucher(Guid.NewGuid())));
            }

            var salaEditada = new Sala(command.Id, command.Nome, assentos);

            _salaRepository.Atualizar(salaEditada);

            return await Task.FromResult(new CommandResult(true, "Sala editada com sucesso"));
        }

        public async Task<CommandResult> Handle(IncluirSalaCommand command, CancellationToken cancellationToken)
        {
            var assentos = new List<Assento>();

            for (int i = 0; i < command.QuantidadeAssentos; i++)
            {
                assentos.Add(new Assento(i + 1, new Voucher(Guid.NewGuid())));
            }

            var sala = new Sala(Guid.NewGuid(), command.Nome, assentos);

            _salaRepository.Incluir(sala);

            return await Task.FromResult(new CommandResult(true, "Sala incluida com sucesso"));
        }
    }
}
