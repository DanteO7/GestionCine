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
        public double Precio => _precio;
        public DateTime Fecha => _fecha;

        public Entrada(Cine cine, Pelicula pelicula, Asiento asiento, DateTime fecha)
        {
            _cine = cine;
            _pelicula = pelicula;
            _fecha = fecha;
            _asiento = asiento;
        }

        public double CalcularPrecio(TipoAsiento tipoAsiento)
        {
            double precioBase = 10;

            switch (tipoAsiento)
            {
                case TipoAsiento.Estandar:
                    _precio = precioBase;
                    return _precio;

                case TipoAsiento.Superseat:
                    _precio = precioBase + 4;
                    return _precio;
                default:
                    throw new ArgumentException("El asiento no tiene tipo");
            }
        }
    }
}
