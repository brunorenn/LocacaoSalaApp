using LocacaoSala.Application.Core.Bus;
using LocacaoSala.Application.Domain.Commands;
using LocacaoSala.Application.Domain.Handlers;
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
        [Route("Sala")]
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

        //[HttpPut]
        //[Route("Sala")]
        //public CommandResult Editar(EditarSalaCommand command)
        //{
        //    try
        //    {
        //        return _salaCommandHandler.Handle(command);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new CommandResult(false, ex.Message);
        //    }
        //}

        //[HttpDelete]
        //[Route("Sala/{id}")]
        //public CommandResult Excluir(Guid id)
        //{
        //    try
        //    {
        //        var command = new ExcluirSalaCommand
        //        {
        //            Id = id
        //        };

        //        return _salaCommandHandler.Handle(command);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new CommandResult(false, ex.Message);
        //    }
        //}

        //[HttpGet]
        //[Route("Sala")]
        //public IEnumerable<SalaViewModel> ObterTodos()
        //{
        //    try
        //    {
        //        return _salaCommandHandler.Handle();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //[HttpGet]
        //[Route("Sala/{id}")]
        //public SalaViewModel Obter(Guid id)
        //{
        //    try
        //    {
        //        return _salaCommandHandler.Handle(id);
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}
