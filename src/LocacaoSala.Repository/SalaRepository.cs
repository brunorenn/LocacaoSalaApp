using LocacaoSala.Application.Domain.Repositories;
using System;
using LocacaoSala.Application.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using LocacaoSala.Application.Domain.ViewModels;
using LocacaoSala.Application.Domain.Queries;

namespace LocacaoSala.Repository
{
    public class SalaRepository : ISalaRepository
    {
        private static List<Sala> _salas = new List<Sala>();

        public void Atualizar(Sala sala)
        {
            Excluir(sala.Id);
            Incluir(sala);
        }

        public void Excluir(Guid id)
        {
            var sala = ObterPorId(id);
            _salas.Remove(sala);
        }

        public void Incluir(Sala sala)
        {
            _salas.Add(sala);
        }

        public Sala ObterPorId(Guid id)
        {
            return _salas.SingleOrDefault(salaDb => salaDb.Id == id);
        }

        public bool Existe(Guid id)
        {
            return _salas.Any(salaDb => salaDb.Id == id);
        }

        public SalaViewModel Obter(Guid id)
        {
            return _salas.Where(x => x.Id == id).Select(salaDb => new SalaViewModel
            {
                Id = salaDb.Id,
                Nome = salaDb.Nome,
                QuantidadeAssentos = salaDb.Assentos.Count,
                QuantidadeAssentosDisponiveis = salaDb.QuantidadeAssentosDisponiveis()
            }).FirstOrDefault();
        }

        public IEnumerable<SalaViewModel> ObterTodos(SalaListQuery filter)
        {
            return _salas.Select(salaDb => new SalaViewModel
            {
                Id = salaDb.Id,
                Nome = salaDb.Nome,
                QuantidadeAssentos = salaDb.Assentos.Count,
                QuantidadeAssentosDisponiveis = salaDb.QuantidadeAssentosDisponiveis()
            })
             .Take(filter.Take)
             .Skip(filter.Skip);
        }
    }
}
