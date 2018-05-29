using LocacaoSala.Application.Domain.Commands;
using LocacaoSala.Application.Domain.Handlers;
using LocacaoSala.Application.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LocacaoSala.API.Controllers
{
    [RoutePrefix("v1")]
    public class SalaController : ApiController
    {
        [HttpPost]
        [Route("Sala")]
        public CommandResult Incluir(IncluirSalaCommand command)
        {
            try
            {
                var result = SalaCommandHandler.Handle(command);

                return result;
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message);
            }
        }

        [HttpPut]
        [Route("Sala")]
        public CommandResult Editar(EditarSalaCommand command)
        {
            try
            {
                var result = SalaCommandHandler.Handle(command);

                return result;
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Sala/{id}")]
        public CommandResult Excluir(Guid id)
        {
            try
            {
                var command = new ExcluirSalaCommand
                {
                    Id = id
                };

                var result = SalaCommandHandler.Handle(command);

                return result;
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message);
            }
        }

        [HttpGet]
        [Route("Sala")]
        public List<SalaViewModel> ObterTodos()
        {
            try
            {
                var result = SalaCommandHandler.Handle();

                return result;
            }
            catch
            {
                return null;
            }
        }

        [HttpGet]
        [Route("Sala/{id}")]
        public SalaViewModel Obter(Guid id)
        {
            try
            {
                return SalaCommandHandler.Handle(id);
            }
            catch
            {
                return null;
            }
        }
    }
}
