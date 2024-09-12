using GestionCine.Enums;

namespace GestionCine.Modelos
{
    public class Pelicula
    {
        private string _nombre;
        private string _genero;
        private int _duracionMin;
        private Formato? _formato;
        // uso Formato? porque en Sala.cs le doy a pelicula un valor por defecto y con Formato? puedo darle un formato nulo hasta que sea definido
        public string Nombre => _nombre;
        public string Genero => _genero;
        public int DuracionMin => _duracionMin;
        public Formato? Formato => _formato;
        public Pelicula(string nombre, string genero, int duracionMin, Formato? formato)
        {
            _nombre = nombre;
            _genero = genero;
            _duracionMin = duracionMin;
            _formato = formato;
        }
        public void MostrarDetalles()
        {
            Console.WriteLine($"Nombre: {Nombre}\nGenero: {Genero}\nDuracion en Minutos: {DuracionMin}\nFormato: {Formato}\n");
        }
    }
}
