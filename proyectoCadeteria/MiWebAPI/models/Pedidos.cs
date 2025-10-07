using System;
using EspacioCadete;
using EspacioCliente;

namespace EspacioPedido
{

    public enum EnumEstado
    {
        EnProceso = 1,
        EnCamino = 2,
        Entregado = 3,
        Cancelado = 4
    }
    public class Pedido
    {
        private int nro;
        private string obs;
        private Cliente cliente;
        private EnumEstado estado;
        private Cadete cadete;


        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public EnumEstado Estado { get => estado; set => estado = value; }
        public Cadete Cadete { get => cadete; set => cadete = value; }

        public Pedido()
        {

        }

        public Pedido(int nro, string obs, EnumEstado estado, string nombre, string direccion, ulong telefono, string datosReferenciaDireccion)
        {
            this.nro = nro;
            this.obs = obs;
            this.cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
            this.estado = estado;
            this.Cadete = null;
        }
    }
}