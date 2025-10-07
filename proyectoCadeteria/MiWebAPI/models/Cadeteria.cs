using System;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using EspacioCadete;
using EspacioPedido;

namespace EspacioCadeteria
{
    public class Cadeteria
    {
        private string nombre;
        private string direccion;
        private ulong telefono;
        private string titular;
        private List<Cadete> listadoCadetes;
        private List<Pedido> listadoPedidos;


        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public ulong Telefono { get => telefono; set => telefono = value; }
        public string Titular { get => titular; set => titular = value; }

        public Cadeteria(string nombre, string direccion, ulong telefono, string titular)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.titular = titular;
            listadoCadetes = new List<Cadete>();
            listadoPedidos = new List<Pedido>();
        }

        public static Cadeteria CargarCadeteriaCSV(string archivo)
        {
            var linea = File.ReadAllLines(archivo).First();
            var datos = linea.Split(",");
            Cadeteria cadeteriaCSV = new Cadeteria(datos[0], datos[1], ulong.Parse(datos[2]), datos[3]);
            return cadeteriaCSV;
        }

        public void CargarCadetesCSV(string archivo)
        {
            foreach (var linea in File.ReadAllLines(archivo))
            {
                var datos = linea.Split(",");
                DarDeAltaCadete(int.Parse(datos[0]), datos[1], datos[2], datos[3], ulong.Parse(datos[4]));
            }
        }
        public void DarDeAltaCadete(int id, string nombre, string apellido, string direccion, ulong telefono)
        {
            Cadete nuevoCadete = new Cadete(id, nombre, apellido, direccion, telefono);
            listadoCadetes.Add(nuevoCadete);
        }


        public List<Cadete> DarDeBajaCadete(int id)
        {
            if (listadoCadetes.Any())
            {
                listadoCadetes.Remove(listadoCadetes.Find(c => c.Id == id));
            }
            return listadoCadetes;

        }

        public List<Cadete> MostrarListaDeCadetes()
        {
            // Console.WriteLine("Mostrando listado de cadetes");
            // foreach (var cadete in listadoCadetes)
            // {
            //     Console.WriteLine($"ID: {cadete.Id}");
            //     Console.WriteLine($"Nombre: {cadete.Nombre} {cadete.Apellido}");
            //     Console.WriteLine($"Teléfono: {cadete.Telefono}");
            //     Console.WriteLine($"Dirección: {cadete.Direccion}");
            // }
            return listadoCadetes;
        }

        public bool ExistePedido(int idPedido)
        {
            if (listadoPedidos.Any(p => p.Nro == idPedido))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExisteCadete(int idCadete)
        {
            if (listadoCadetes.Any(c => c.Id == idCadete))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Pedido> DarDeAltaPedido(Pedido pedido)
        {
            listadoPedidos.Add(pedido);
            return listadoPedidos;
        }

        public List<Pedido> DarDeBajaPedido(int nroDePedido)
        {
            if (listadoPedidos.Any())
            {
                listadoPedidos.RemoveAll(p => p.Nro == nroDePedido);
            }

            return listadoPedidos;
        }

        public bool AsignarCadeteAPedido(int idPedido, int idCadete)
        {
            if (ExistePedido(idPedido) && ExisteCadete(idCadete))
            {
                Pedido pedido = listadoPedidos.First(p => p.Nro == idPedido);
                Cadete cadete = listadoCadetes.First(c => c.Id == idCadete);
                pedido.Cadete = cadete;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ReasignarCadeteAPedido(int idPedido, int idCadete)
        {
            if (ExistePedido(idPedido) && ExisteCadete(idCadete))
            {
                Pedido pedido = listadoPedidos.First(p => p.Nro == idPedido);
                Cadete cadete = listadoCadetes.First(c => c.Id == idCadete);
                pedido.Cadete = cadete;
                return true;
            }
            else
            {
                return false;
            }
        }

        public float JornalACobrar(int idCadete)
        {
            if (listadoCadetes.Any(c => c.Id == idCadete))
            {
                return 500 * listadoPedidos.Count(p => p.Cadete.Id == idCadete);
            }
            else
            {
                return 0;
            }
        }

    }
}