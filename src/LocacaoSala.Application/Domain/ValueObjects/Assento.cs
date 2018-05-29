using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoSala.Application.Domain.ValueObjects
{
    public class Assento
    {
        public Assento(int total, int reservado)
        {
            Total = total;
            Reservado = reservado;
        }

        public int Total { get; set; }
        public int Reservado { get; set; }

        public int Disponivel { get { return Total - Reservado; } }

    }
}
