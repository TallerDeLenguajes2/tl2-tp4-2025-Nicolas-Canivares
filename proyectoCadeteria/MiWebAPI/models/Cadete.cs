using System;
using EspacioPedido;

namespace EspacioCadete
{
    public class Cadete
    {
        private readonly int id;
        private string nombre;
        private string apellido;
        private string direccion;
        private ulong telefono;


        public int Id { get => id; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public ulong Telefono { get => telefono; set => telefono = value; }

        public Cadete(int id, string nombre, string apellido, string direccion, ulong telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.telefono = telefono;
        }
    }
}