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
            Console.WriteLine($"Sala: {entrada.Sala.Numero}");
            Console.WriteLine($"Fecha de la funcion: {entrada.Sala.HorarioInicio.ToShortDateString()}");
            Console.WriteLine($"Horario de la funcion: desde {entrada.Sala.HorarioInicio.ToShortTimeString()}hs hasta {entrada.Sala.HorarioFin.ToShortTimeString()}hs");
            Console.WriteLine($"Asiento: {entrada.Asiento.Letra}-{entrada.Asiento.Numero}, tipo {entrada.Asiento.Tipo}\n");
            Console.WriteLine($"Cliente: {Nombre}");
            Console.WriteLine($"Fecha de compra: {entrada.Fecha}");
            Console.WriteLine($"Precio: {entrada.Precio:C} ");
            Console.WriteLine("-------------------------------------------------\n");
        }   
    }
}
