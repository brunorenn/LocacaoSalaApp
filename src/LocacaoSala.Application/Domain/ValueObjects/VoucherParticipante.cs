using System;

namespace LocacaoSala.Application.Domain.ValueObjects
{
    public class VoucherParticipante : Voucher
    {
        public VoucherParticipante(Guid id, decimal valor, DateTime dataCompra) : base(id)
        {
            Valor = valor;
            DataCompra = dataCompra;
        }

        public Decimal Valor { get; private set; }
        public DateTime DataCompra { get; private set; }

        public override bool Equals(object obj)
        {
            var valueObject = obj as VoucherParticipante;
            return !ReferenceEquals(valueObject, null) && EqualsCore(valueObject);
        }

        public bool EqualsCore(VoucherParticipante voucherParticipante)
        {
            return voucherParticipante.Id == Id && voucherParticipante.DataCompra == DataCompra && voucherParticipante.Valor == Valor;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
