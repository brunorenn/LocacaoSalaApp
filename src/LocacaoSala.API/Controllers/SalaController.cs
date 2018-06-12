using LocacaoSala.Application.Core.Bus;
using LocacaoSala.Application.Domain.Commands;
using LocacaoSala.Application.Domain.Queries;
using LocacaoSala.Application.Domain.ViewModels;
using LocacaoSala.Infra.CrossCutting.Core.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace LocacaoSala.API.Controllers
{
    [RoutePrefix("v1")]
    public class SalaController : ApiController
    {
        private IMediatorHandler _handler;

        public SalaController(IMediatorHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("sala")]
        public async Task<CommandResult> Incluir(IncluirSalaCommand command)
        {
            try
            {
                return await _handler.Handle(command);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new CommandResult(false, ex.Message));
            }
        }

        [HttpPut]
        [Route("sala/{id}")]
        public async Task<CommandResult> Editar([FromUri]Guid id, EditarSalaCommand command)
        {
            try
            {
                command.Id = id;
                return await _handler.Handle(command);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new CommandResult(false, ex.Message));
            }
        }

        [HttpDelete]
        [Route("sala/{id}")]
        public async Task<CommandResult> Excluir(Guid id)
        {
            try
            {
                var command = new ExcluirSalaCommand
                {
                    Id = id
                };

                return await _handler.Handle(command);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new CommandResult(false, ex.Message));
            }
        }

        [HttpGet]
        [Route("sala")]
        public async Task<IEnumerable<SalaViewModel>> ObterTodos([FromUri] int skip)
        {
            var query = new SalaListQuery { Skip = skip };
            return await _handler.Query<SalaListQuery, IEnumerable<SalaViewModel>>(query);
        }

        [HttpGet]
        [Route("sala/{id}")]
        public async Task<SalaViewModel> Obter(Guid id)
        {
            var query = new SalaQuery { Id = id};
            return await _handler.Query<SalaQuery, SalaViewModel>(query);
        }
    }
}
