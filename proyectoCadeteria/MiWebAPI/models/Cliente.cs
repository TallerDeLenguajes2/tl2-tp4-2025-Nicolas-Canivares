using System;

namespace EspacioCliente
{
    public class Cliente
    {
        private string nombre;
        private string direccion;
        private ulong telefono;
        private string datosReferenciaDireccion;


        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }       
        public ulong Telefono { get => telefono; set => telefono = value; }
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

        
        public Cliente(string nombre, string direccion, ulong telefono, string datosReferenciaDireccion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.datosReferenciaDireccion = datosReferenciaDireccion;
        }

    }

}
