using System;

namespace LocacaoSala.Application.Domain.ValueObjects
{
    public class Voucher
    {
        public Voucher(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
