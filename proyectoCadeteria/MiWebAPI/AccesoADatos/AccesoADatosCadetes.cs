using System.Text.Json;
using EspacioCadete;
using EspacioCadeteria;

public class AccesoADatosCadetes
{
    private readonly string _ruta;
    public AccesoADatosCadetes()
    {
        _ruta = "data/cadetes.json";
    }
    public List<Cadete> LeerArchivo()
    {
        string CadenaCadetes;
        using (var archivoOpnen = new FileStream(_ruta, FileMode.Open))
        {
            using (var aux = new StreamReader(archivoOpnen))
            {
                CadenaCadetes=aux.ReadToEnd();
                archivoOpnen.Close();
            }
        }
        var ListaCadetes= JsonSerializer.Deserialize<List<Cadete>>(CadenaCadetes);
        return ListaCadetes;
    }
    public void GuardarArchivo(List<Cadete> ListaCadetes)
    {
        string ListaCadetesString= JsonSerializer.Serialize(ListaCadetes);
        File.Delete(_ruta);
        FileStream archivo= new FileStream (_ruta, FileMode.OpenOrCreate);
        using (StreamWriter streamWriter= new StreamWriter(archivo))
        {
            streamWriter.WriteLine("{0}", ListaCadetesString);
            streamWriter.Close();
        }
    }
}