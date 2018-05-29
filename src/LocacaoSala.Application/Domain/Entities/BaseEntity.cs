using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoSala.Application.Domain.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity(Guid id) : this(id, "")
        {
        }

        public BaseEntity(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
            Ativo = true;
        }

        public Guid Id { get; private set; }
        public string Nome { get; set; }
        public bool Ativo { get; private set; }

        public void Ativar()
        {
            Ativo = true;
        }

        public virtual void Inativar()
        {
            Ativo = false;
        }
    }
}
