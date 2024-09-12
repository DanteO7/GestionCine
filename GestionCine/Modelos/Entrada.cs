using GestionCine.Enums;

namespace GestionCine.Modelos
{
    public class Entrada
    {
        private Cine _cine;
        private Sala _sala;
        private Pelicula _pelicula;
        private Asiento _asiento;
        private double _precio;
        private DateTime _fecha;

        public Cine Cine => _cine;
        public Sala Sala => _sala;
        public Pelicula Pelicula => _pelicula;
        public Asiento Asiento => _asiento;
        public DateTime Fecha => _fecha;
        public double Precio
        {
            get
            {
                double precioBase = 10;
                if(_asiento.Tipo == TipoAsiento.Superseat)
                {
                    precioBase += 4;
                }
                _precio = precioBase;
                return _precio;
            }
        }

        public Entrada(Cine cine, Sala sala, Pelicula pelicula, Asiento asiento, DateTime fecha)
        {
            _cine = cine;
            _sala = sala;
            _pelicula = pelicula;
            _fecha = fecha;
            _asiento = asiento;
        }
    }
}
