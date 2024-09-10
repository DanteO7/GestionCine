using GestionCine.Enums;

namespace GestionCine.Modelos
{
    public class Cine
    {
        private string _nombre;
        private List<Sala> _salas = new List<Sala>();
        private List<Pelicula> _cartelera = new List<Pelicula>();

        public string Nombre => _nombre;
        public List<Sala> Salas => _salas;
        public List<Pelicula> Cartelera => _cartelera;

        public Cine(string nombre, List<Sala> salas, List<Pelicula> cartelera)
        {
            _nombre = nombre;
            AgregarSala(salas);
        }

        public Cine(string nombre, Sala sala)
        {
            _nombre = nombre;
            AgregarSala(sala);
        }

        public void AgregarSala(Sala sala)
        {
            foreach (var _sala in _salas)
            {
                if (_sala.Numero == sala.Numero)
                {
                    throw new ArgumentException("Ya existe una sala con ese numero");
                }
            }
            _salas.Add(sala);
        }

        public void AgregarSala(List<Sala> salas)
        {
            //verifico que la lista que le paso no esté vacía
            if (salas.Count <= 0)
            {
                throw new ArgumentException("La lista de salas no puede estar vacía");
            }
            // verifico que en la lista que le paso no haya repetidos
            List<int> numerosSalas = new List<int>();
            foreach (var sala in salas)
            {
                int numeroSala = sala.Numero;
                if (numerosSalas.Contains(numeroSala))
                {
                    throw new ArgumentException("La lista de salas contiene salas repetidas");
                }
                numerosSalas.Add(numeroSala);
            }
            // verifico que en la lista que le paso no exista un numero ya existente en la lista base
            foreach (var sala in salas)
            {
                foreach (var _sala in _salas)
                {
                    if (sala.Numero == _sala.Numero)
                    {
                        throw new ArgumentException("Ya existe una sala con ese numero");
                    }
                }
            }
            _salas.AddRange(salas);
        }

        public void ActualizarCartelera()
        {
            foreach(var sala in _salas)
            {
                _cartelera.Add(sala.Pelicula);
            }
        }
        
        public void MostrarCartelera()
        {
            foreach(var pelicula in _cartelera)
            {
                pelicula.MostrarDetalles();
            }
        }

        public void MostrarPreciosAsientos()
        {
            Console.WriteLine("Tipo de asientos y sus precios:");
            foreach (TipoAsiento tipoAsiento in Enum.GetValues(typeof(TipoAsiento)))
            {
                if(tipoAsiento == TipoAsiento.Estandar)
                {
                    Console.WriteLine($"{tipoAsiento}: $10.00");
                }
                else
                {
                    Console.WriteLine($"{tipoAsiento}: $14.00\n");
                }
                
            }
        }
    }
}
