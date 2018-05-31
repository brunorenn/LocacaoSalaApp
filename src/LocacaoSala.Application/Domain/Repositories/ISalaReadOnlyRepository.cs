using LocacaoSala.Application.Domain.Entities;
using LocacaoSala.Application.Domain.Queries;
using LocacaoSala.Application.Domain.ViewModels;
using System;
using System.Collections.Generic;

namespace LocacaoSala.Application.Domain.Repositories
{
    public interface ISalaReadOnlyRepository
    {
        Sala ObterPorId(Guid id);
        SalaViewModel Obter(Guid id);
        IEnumerable<SalaViewModel> ObterTodos(SalaListQuery filter);
    }
}
