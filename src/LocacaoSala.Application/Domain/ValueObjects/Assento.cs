namespace LocacaoSala.Application.Domain.ValueObjects
{
    public class Assento
    {
        public Assento(int id, Voucher voucherId)
        {
            Id = id;
            VoucherId = voucherId;
        }

        public int Id { get; private set; }
        public Voucher VoucherId { get; private set; }

        public override bool Equals(object obj)
        {
            var assento = obj as Assento;
            return !ReferenceEquals(assento, null) && assento.Id == Id;
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }
    }
}
