using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Voucher
    {
        string codigo;
        int idCliente;
      //  DateTime DateTime;
        int idArticulo;


        public string Codigo { get => codigo; set => codigo = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        //public DateTime DateTime1 { get => DateTime; set => DateTime = value; }
        public int IdArticulo { get => idArticulo; set => idArticulo = value; }

    }
}
