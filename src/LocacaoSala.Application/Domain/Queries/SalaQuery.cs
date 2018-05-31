using LocacaoSala.Application.Domain.ViewModels;
using LocacaoSala.Infra.CrossCutting.Core.Queries;
using System;

namespace LocacaoSala.Application.Domain.Queries
{
    public class SalaQuery : Query<SalaViewModel>
    {
        public Guid Id { get; set; }
    }
}
