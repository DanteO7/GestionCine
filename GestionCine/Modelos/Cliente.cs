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


//public void MostrarDetallesMembresia()
//{
//    Console.WriteLine("Detalles de la Membresia:");
//    Console.WriteLine($"Nombre: {Nombre}");
//    Console.WriteLine($"Membresia: {Membresia}");
//    Console.WriteLine($"Acceso a Piscina: {(AccesoPiscina ? "Si" : "No")}");
//    Console.WriteLine($"Acceso a Spa: {(AccesoSpa ? "Si" : "No")}");
//    Console.WriteLine($"Clases Grupales: {(ClasesGrupales ? "Si" : "No")}");
//    Console.WriteLine($"Costo Base Membresia: {CostoBaseMembresia:C}\n");

//    Console.WriteLine("- Clases Adicionales:\n");
//    foreach (var clase in ClasesAdicionales)
//    {
//        Console.WriteLine($" ° Nombre Clase: {clase.NombreClase}");
//        Console.WriteLine($" ° Costo Clase: {clase.CostoClase:C}");
//        Console.WriteLine($" ° Descuento aplicado: {DescuentoEnClases * 100}%\n");
//    }
//    Console.WriteLine($"Costo Total Clases adicionales: {CostoTotalClases:C}\n");

//    Console.WriteLine($"Costo Total Membresia + Clases: {CostoTotal:C}");
//    Console.WriteLine("-------------------------------------------\n");
//}
