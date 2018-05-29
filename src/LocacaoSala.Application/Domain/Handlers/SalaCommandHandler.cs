using LocacaoSala.Application.Domain.Commands;
using LocacaoSala.Application.Domain.Entities;
using LocacaoSala.Application.Domain.ValueObjects;
using LocacaoSala.Application.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoSala.Application.Domain.Handlers
{
    public static class SalaCommandHandler
    {
        private static List<Sala> _repositorioSala = new List<Sala>();

        public static CommandResult Handle(IncluirSalaCommand command)
        {
            if (string.IsNullOrEmpty(command.Nome))
            {
                return new CommandResult(false, "Nome da sala está em branco");
            }
            if(command.QuantidadeAssentos <= 0)
            {
                return new CommandResult(false, "Quantidade de assentos deve ser maior que 0");
            }

            var vouchers = new List<Voucher>();

            for (int i = 0; i < command.QuantidadeAssentos; i++)
            {
                vouchers.Add(new Voucher(Guid.NewGuid()));
            }

            var sala = new Sala(Guid.NewGuid());
            sala.Nome = command.Nome;
            sala.Assentos = new Assento(command.QuantidadeAssentos, 0);
            sala.Vouchers = vouchers;

            _repositorioSala.Add(sala);

            return new CommandResult(true, "Sala incluida com sucesso");
        }

        public static CommandResult Handle(EditarSalaCommand command)
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

            var sala = _repositorioSala.SingleOrDefault(salaDb => salaDb.Id == command.Id);

            if (sala == null)
            {
                return new CommandResult(false, "Sala não encontrada");
            }

            if (!_repositorioSala.Remove(sala))
            {
                return new CommandResult(false, "Não foi possível remover a sala");
            }
            
            var vouchers = new List<Voucher>();
            for (int i = 0; i < command.QuantidadeAssentos; i++)
            {
                vouchers.Add(new Voucher(Guid.NewGuid()));
            }


            var salaEditada = new Sala(sala.Id);
            salaEditada.Nome = command.Nome;
            salaEditada.Assentos = new Assento(command.QuantidadeAssentos, 0);
            salaEditada.Vouchers = vouchers;

            _repositorioSala.Add(salaEditada);

            return new CommandResult(true, "Sala editada com sucesso");

        }

        public static CommandResult Handle(ExcluirSalaCommand command)
        {
            if (command.Id == Guid.Empty)
            {
                return new CommandResult(false, "Informe o Id da sala");
            }

            var sala = _repositorioSala.SingleOrDefault(salaDb => salaDb.Id == command.Id);

            if (sala == null)
            {
                return new CommandResult(false, "Sala não encontrada");
            }

            if (!_repositorioSala.Remove(sala))
            {
                return new CommandResult(false, "Não foi possível remover a sala");
            }

            return new CommandResult(true, "Sala excluida com sucesso");
        }

        public static List<SalaViewModel> Handle()
        {
            return _repositorioSala.Select(salaDb => new SalaViewModel
            {
                Id = salaDb.Id,
                Nome = salaDb.Nome,
                QuantidadeAssentos = salaDb.Assentos.Total,
                QuantidadeAssentosDisponiveis = salaDb.Assentos.Disponivel
            }).ToList();
        }

        public static SalaViewModel Handle(Guid id)
        {
            return _repositorioSala.Where(x => x.Id == id).Select(salaDb => new SalaViewModel
            {
                Id = salaDb.Id,
                Nome = salaDb.Nome,
                QuantidadeAssentos = salaDb.Assentos.Total,
                QuantidadeAssentosDisponiveis = salaDb.Assentos.Disponivel
            }).FirstOrDefault();
        }
    }
}
