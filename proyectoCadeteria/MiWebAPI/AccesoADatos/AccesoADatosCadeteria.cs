using System.Text.Json;
using EspacioCadete;
using EspacioCadeteria;

public class AccesoADatosCadeteria
{
    private readonly string _ruta;
    public AccesoADatosCadeteria()
    {
        _ruta = "data/cadeteria.json";
    }
    public Cadeteria LeerArchivo()
    {
        string CadenaCadeteria;
        using (var archivoOpnen = new FileStream(_ruta, FileMode.Open))
        {
            using (var aux = new StreamReader(archivoOpnen))
            {
                CadenaCadeteria=aux.ReadToEnd();
                archivoOpnen.Close();
            }
        }
        var ListaCadeteria= JsonSerializer.Deserialize<Cadeteria>(CadenaCadeteria);
        return ListaCadeteria;
    }
    public void GuardarArchivo(Cadeteria ListaCadeteria)
    {
        string ListaCadeteriaString= JsonSerializer.Serialize(ListaCadeteria);
        File.Delete(_ruta);
        FileStream archivo= new FileStream (_ruta, FileMode.OpenOrCreate);
        using (StreamWriter streamWriter= new StreamWriter(archivo))
        {
            streamWriter.WriteLine("{0}", ListaCadeteriaString);
            streamWriter.Close();
        }
    }
}