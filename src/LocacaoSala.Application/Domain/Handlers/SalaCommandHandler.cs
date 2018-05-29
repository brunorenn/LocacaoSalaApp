using LocacaoSala.Application.Domain.Commands;
using LocacaoSala.Application.Domain.Entities;
using LocacaoSala.Application.Domain.Repositories;
using LocacaoSala.Application.Domain.ValueObjects;
using LocacaoSala.Application.Domain.ViewModels;
using System;
using System.Collections.Generic;

namespace LocacaoSala.Application.Domain.Handlers
{
    public class SalaCommandHandler
    {
        private ISalaRepository _salaRepository;

        public SalaCommandHandler(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public CommandResult Handle(IncluirSalaCommand command)
        {
            if (string.IsNullOrEmpty(command.Nome))
            {
                return new CommandResult(false, "Nome da sala está em branco");
            }
            if (command.QuantidadeAssentos <= 0)
            {
                return new CommandResult(false, "Quantidade de assentos deve ser maior que 0");
            }

            var assentos = new List<Assento>();

            for (int i = 0; i < command.QuantidadeAssentos; i++)
            {
                assentos.Add(new Assento(i + 1, new Voucher(Guid.NewGuid())));
            }

            var sala = new Sala(Guid.NewGuid(), command.Nome, assentos);

            _salaRepository.Incluir(sala);

            return new CommandResult(true, "Sala incluida com sucesso");
        }

        public CommandResult Handle(EditarSalaCommand command)
        {
            if (command.Id == Guid.Empty)
            {
                return new CommandResult(false, "Informe o Id da sala");
            }
            if (string.IsNullOrEmpty(command.Nome))
            {
                return new CommandResult(false, "Nome da sala está em branco");
            }
            if (command.QuantidadeAssentos <= 0)
            {
                return new CommandResult(false, "Quantidade de assentos deve ser maior que 0");
            }

            if (!_salaRepository.Existe(command.Id))
            {
                return new CommandResult(false, "Sala não encontrada");
            }

            var assentos = new List<Assento>();

            for (int i = 0; i < command.QuantidadeAssentos; i++)
            {
                assentos.Add(new Assento(i + 1, new Voucher(Guid.NewGuid())));
            }

            var salaEditada = new Sala(Guid.NewGuid(), command.Nome, assentos);

            _salaRepository.Atualizar(salaEditada);

            return new CommandResult(true, "Sala editada com sucesso");
        }

        public CommandResult Handle(ExcluirSalaCommand command)
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

            return new CommandResult(true, "Sala excluida com sucesso");
        }

        public IEnumerable<SalaViewModel> Handle()
        {
            return _salaRepository.ObterTodos();
        }

        public SalaViewModel Handle(Guid id)
        {
            return _salaRepository.Obter(id);
        }
    }
}
