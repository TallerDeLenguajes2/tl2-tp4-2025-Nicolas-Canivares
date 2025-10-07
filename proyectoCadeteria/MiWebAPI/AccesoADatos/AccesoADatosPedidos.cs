using System.Text.Json;

using EspacioCadeteria;
using EspacioPedido;

public class AccesoADatosPedidos
{
    private readonly string _ruta;
    public AccesoADatosPedidos()
    {
        _ruta = "data/pedidos.json";
    }
    public List<Pedido> LeerArchivo()
    {
        string CadenaPedidos;
        using (var archivoOpnen = new FileStream(_ruta, FileMode.Open))
        {
            using (var aux = new StreamReader(archivoOpnen))
            {
                CadenaPedidos = aux.ReadToEnd();
                archivoOpnen.Close();
            }
        }
        var ListaPedidos = JsonSerializer.Deserialize<List<Pedido>>(CadenaPedidos);
        return ListaPedidos;
    }
    public void GuardarArchivo(List<Pedido> ListaPedidos)
    {
        string ListaPedidosString = JsonSerializer.Serialize(ListaPedidos);
        File.Delete(_ruta);
        FileStream archivo = new FileStream(_ruta, FileMode.OpenOrCreate);
        using (StreamWriter streamWriter = new StreamWriter(archivo))
        {
            streamWriter.WriteLine("{0}", ListaPedidosString);
            streamWriter.Close();
        }
    }

    /* internal void GuardarArchivo(List<Pedido> listadoPedidos)
    {
        throw new NotImplementedException();
    } */
}