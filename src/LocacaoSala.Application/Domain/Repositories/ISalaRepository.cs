using LocacaoSala.Application.Domain.Entities;
using System;

namespace LocacaoSala.Application.Domain.Repositories
{
    public interface ISalaRepository: ISalaReadOnlyRepository
    {
        void Incluir(Sala sala);
        void Atualizar(Sala sala);
        void Excluir(Guid id);
        bool Existe(Guid id);
    }
}
