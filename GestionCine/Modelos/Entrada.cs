using GestionCine.Enums;

namespace GestionCine.Modelos
{
    public class Entrada
    {
        private Cine _cine;
        private Pelicula _pelicula;
        private Asiento _asiento;
        private double _precio;
        private DateTime _fecha;

        public Cine Cine => _cine;
        public Pelicula Pelicula => _pelicula;
        public Asiento Asiento => _asiento;
        public double Precio
        {
            get
            {
                double precioBase = 10;
                if(Asiento.Tipo == TipoAsiento.Superseat)
                {
                    precioBase += 4;
                }
                return precioBase;
            }
        }
        public DateTime Fecha => _fecha;

        public Entrada(Cine cine, Pelicula pelicula, Asiento asiento, DateTime fecha)
        {
            _cine = cine;
            _pelicula = pelicula;
            _fecha = fecha;
            _asiento = asiento;
        }
    }
}
