using LocacaoSala.Application.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoSala.Application.Domain.Entities
{
    public class Sala : BaseEntity
    {
        public Sala(Guid id) : base(id)
        {
        }

        public Assento Assentos { get; set; }
        public List<Pessoa> Pessoas { get; set; }
        public List<Voucher> Vouchers { get; set; }
    }
}
