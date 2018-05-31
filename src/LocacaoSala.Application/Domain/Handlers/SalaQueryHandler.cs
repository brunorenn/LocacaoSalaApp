using LocacaoSala.Application.Domain.Queries;
using LocacaoSala.Application.Domain.ViewModels;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using LocacaoSala.Application.Domain.Repositories;

namespace LocacaoSala.Application.Domain.Handlers
{
    public class SalaQueryHandler : IRequestHandler<SalaQuery, SalaViewModel>,
                                    IRequestHandler<SalaListQuery, IEnumerable<SalaViewModel>>
    {
        private ISalaRepository _salaRepository;

        public SalaQueryHandler(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public async Task<SalaViewModel> Handle(SalaQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_salaRepository.Obter(request.Id));
        }

        public async Task<IEnumerable<SalaViewModel>> Handle(SalaListQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_salaRepository.ObterTodos(request));
        }
    }
}
