using LocacaoSala.Application.Domain.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace LocacaoSala.Application.Domain.Queries
{
    public class SalaListQuery : IRequest<IEnumerable<SalaViewModel>>
    {
        public int Take { get { return 10; } }
        public int Skip { get; set; }
    }
}
