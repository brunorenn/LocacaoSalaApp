using LocacaoSala.Application.Domain.Entities;
using LocacaoSala.Application.Domain.ViewModels;
using System;
using System.Collections.Generic;

namespace LocacaoSala.Application.Domain.Repositories
{
    public interface ISalaRepository
    {
        Sala ObterPorId(Guid id);
        void Incluir(Sala sala);
        void Atualizar(Sala sala);
        void Excluir(Guid id);
        bool Existe(Guid id);
        SalaViewModel Obter(Guid id);
        IEnumerable<SalaViewModel> ObterTodos();
    }
}
