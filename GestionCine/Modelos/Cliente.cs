using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionCine.Modelos
{
    public class Cliente
    {
        private string _nombre;
        public string Nombre => _nombre;

        public Cliente(string nombre)
        {
            _nombre = nombre;
        }
        public void SacarEntrada(Entrada entrada)
        {
            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("Detalles de la Entrada:\n");
            Console.WriteLine($"Cine: {entrada.Cine.Nombre}");
            entrada.Pelicula.MostrarDetalles();
            foreach(var sala in entrada.Cine.Salas)
            {
                if(sala.Pelicula == entrada.Pelicula)
                {
                    Console.WriteLine($"Sala: {sala.Numero}");
                    Console.WriteLine($"Fecha de la funcion: {sala.HorarioInicio.ToShortDateString()}");
                    Console.WriteLine($"Horario de la funcion: desde {sala.HorarioInicio.ToShortTimeString()}hs hasta {sala.HorarioFin.ToShortTimeString()}hs");
                }
            }
            Console.WriteLine($"Asiento: {entrada.Asiento.Letra}-{entrada.Asiento.Numero}, tipo {entrada.Asiento.Tipo}\n");
            Console.WriteLine($"Cliente: {Nombre}");
            Console.WriteLine($"Fecha de compra: {entrada.Fecha}");
            Console.WriteLine($"Precio: {entrada.CalcularPrecio(entrada.Asiento.Tipo):C} ");
            Console.WriteLine("-------------------------------------------------\n");
        }   
    }
}
