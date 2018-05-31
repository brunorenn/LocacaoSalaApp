using MediatR;
using System;

namespace LocacaoSala.Infra.CrossCutting.Core.Queries
{
    public class Query<T> : IRequest<T> where T : class
    {
        public Guid UId { get; set; }
    }
}
