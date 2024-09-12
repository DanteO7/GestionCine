namespace GestionCine.Modelos
{
    public class Sala
    {
        private int _numero;
        private List<Asiento> _asientos = new List<Asiento>();
        private Pelicula _pelicula;
        private DateTime _horarioInicio;
        private DateTime _horarioFin;

        public int Numero => _numero;
        public List<Asiento> Asientos => _asientos;
        public Pelicula Pelicula => _pelicula;
        public DateTime HorarioInicio => _horarioInicio;
        public DateTime HorarioFin => _horarioFin;

        public Sala(int numero, List<Asiento> asientos)
        {
            _numero = numero;
            AgregarAsiento(asientos);
            _pelicula = new Pelicula("No hay Pelicula asignada", "Desconocido", 0, null);
            _horarioInicio = DateTime.MinValue;
            _horarioFin = DateTime.MinValue;
        }

        public Sala(int numero, Asiento asiento)
        {
            _numero = numero;
            AgregarAsiento(asiento);
            _pelicula = new Pelicula("No hay Pelicula asignada", "Desconocido", 0, null);
            _horarioInicio = DateTime.MinValue;
            _horarioFin = DateTime.MinValue;
        }

        public void AgregarAsiento(Asiento asiento)
        {
            foreach (var _asiento in _asientos)
            {
                if (_asiento.Letra == asiento.Letra && _asiento.Numero == asiento.Numero)
                {
                    throw new ArgumentException("Ya existe un asiento con ese codigo en esta sala");
                }
            }
            _asientos.Add(asiento);
        }

        public void AgregarAsiento(List<Asiento> asientos)
        {
            //verifico que la lista que le paso no esté vacía
            if (asientos.Count <= 0)
            {
                throw new ArgumentException("La lista de asientos no puede estar vacía");
            }
            // verifico que en la lista que le paso no haya repetidos
            List<string> codigosAsientos = new List<string>();
            foreach (var asiento in asientos)
            {
                string codigoAsiento = asiento.Letra.ToString() + asiento.Numero.ToString();
                if (codigosAsientos.Contains(codigoAsiento))
                {
                    throw new ArgumentException("La lista de asientos contiene asientos repetidos");
                }
                codigosAsientos.Add(codigoAsiento);
            }
            // verifico que en la lista que le paso no exista un codigo ya existente en la lista base
            foreach (var asiento in asientos)
            {
                foreach(var _asiento in _asientos)
                {
                    if (_asiento.Letra == asiento.Letra && _asiento.Numero == asiento.Numero)
                    {
                        throw new ArgumentException("Ya existe un asiento con ese codigo en esta sala");
                    }
                }
            }
            _asientos.AddRange(asientos);
        }

        public void MostrarAsientos()
        {
            int contador = 0;
            foreach(var asiento in _asientos)
            {
                Console.WriteLine($"{++contador} - {asiento.Letra}-{asiento.Numero}, Tipo: {asiento.Tipo}, Estado: {(asiento.Ocupado ? "Ocupado" : "Desocupado")}");
            }
            Console.WriteLine($"{++contador} - Volver\n");
        }

        // creo el metodo DefinirPelicula, donde puedo pasar la pelicula, los horarios o ambas porque cuando quiero sacar una entrada necesito saber en que sala va a estar la pelicula que saqué
        // la entrada, y antes la pelicula solo se instanciaba con el método ReproducirPelicula donde la pelicula ya se reproducia
        public void DefinirDetallesPelicula(Pelicula pelicula)
        {
            _pelicula = pelicula;
            //Console.WriteLine($"La pelicula: {Pelicula.Nombre} formato {Pelicula.Formato} será reproducina en la sala {Numero}\n");
        }

        public void DefinirDetallesPelicula(DateTime horaInicio, DateTime horaFin)
        {
            // hice los horarios con DateTime por si hay una pelicula que empiece de noche y termine al dia siguiente, poder hacer la validacion correctamente
            if(horaInicio > horaFin)
            {
                throw new ArgumentException("El horario del inicio no puede ser mayor al horario del final");
            }
            _horarioInicio = horaInicio;
            _horarioFin = horaFin;
            //Console.WriteLine($"La pelicula {Pelicula.Nombre} será reproducida en la sala {Numero} el dia {HorarioInicio.ToShortDateString()} desde las {HorarioInicio.TimeOfDay} horas, hasta las {HorarioFin.TimeOfDay} horas\n");
        }

        public void DefinirDetallesPelicula(Pelicula pelicula, DateTime horaInicio, DateTime horaFin)
        {
            _pelicula = pelicula;
            _horarioInicio = horaInicio;
            _horarioFin = horaFin;
            //Console.WriteLine($"La pelicula {Pelicula.Nombre} será reproducida en la sala {Numero} el dia {HorarioInicio.ToShortDateString()} desde las {HorarioInicio.TimeOfDay} horas, hasta las {HorarioFin.TimeOfDay} horas\n");
        }

        public void EmpezarFuncion()
        {
            if(_pelicula.DuracionMin == 0 || HorarioInicio == DateTime.MinValue)
            {
                throw new ArgumentException("No se puede empezar la función si no se han asignado una película y un horario.");
            }
            Console.WriteLine($"Empezando la funcion de las {HorarioInicio}hs hasta las {HorarioFin}hs de la pelicula {Pelicula.Nombre} formato {Pelicula.Formato}\n");
        }

        public void FinalizarFuncion()
        {
            if (_pelicula.DuracionMin == 0 || HorarioInicio == DateTime.MinValue)
            {
                throw new ArgumentException("No se puede finalizar la función si no se han asignado una película y un horario.");
            }
            Console.WriteLine($"Terminando la funcion de las {HorarioInicio}hs hasta las {HorarioFin}hs de la pelicula {Pelicula.Nombre} formato {Pelicula.Formato}\n");
            _pelicula = new Pelicula("No hay Pelicula asignada", "Desconocido", 0, null);
            _horarioInicio = DateTime.MinValue;
            _horarioFin = DateTime.MinValue;
        }
    }
}
