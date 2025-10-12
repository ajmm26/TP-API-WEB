using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Cliente
    {

        private int id;
        private string nombre;
        private string apellido;
        private string email;
        private string documento;
        private string direccion;
        private string ciudad;
        private int cp;

        public int Id { get =>  id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public string Apellido { get => apellido; set => apellido = value; }

        public string Email { get => email; set => email = value; }

        public string Documento { get => documento; set => documento = value; }

        public string Direccion { get => direccion; set => direccion = value; }

        public string Ciudad { get => ciudad; set => ciudad = value; }

        public int Cp { get => cp; set => cp = value; }
    }
}
