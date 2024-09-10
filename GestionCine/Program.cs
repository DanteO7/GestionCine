using GestionCine.Enums;
using GestionCine.Modelos;

namespace GestionCine
{
    public class Program
    {
        public static void Main()
        {
            Asiento asiento1_1 = new Asiento('A', 1, TipoAsiento.Estandar, false);
            Asiento asiento1_2 = new Asiento('A', 2, TipoAsiento.Estandar, true);
            Asiento asiento1_3 = new Asiento('B', 1, TipoAsiento.Estandar, false);
            Asiento asiento1_4 = new Asiento('B', 2, TipoAsiento.Estandar, false);
            Asiento asiento1_5 = new Asiento('C', 1, TipoAsiento.Superseat, false);
            Asiento asiento1_6 = new Asiento('C', 2, TipoAsiento.Superseat, false);

            Asiento asiento2_1 = new Asiento('A', 1, TipoAsiento.Estandar, true);
            Asiento asiento2_2 = new Asiento('A', 2, TipoAsiento.Estandar, true);
            Asiento asiento2_3 = new Asiento('B', 1, TipoAsiento.Estandar, false);
            Asiento asiento2_4 = new Asiento('B', 2, TipoAsiento.Estandar, false);
            Asiento asiento2_5 = new Asiento('C', 1, TipoAsiento.Superseat, false);
            Asiento asiento2_6 = new Asiento('C', 2, TipoAsiento.Superseat, false);

            List<Asiento> listaAsientosEstandar = new List<Asiento>();
            List<Asiento> listaAsientosSuper1 = new List<Asiento>();
            List<Asiento> listaAsientosSuper2 = new List<Asiento>();

            listaAsientosEstandar.AddRange(new List<Asiento> { asiento1_1, asiento1_2, asiento1_3, asiento1_4 });
            listaAsientosSuper1.AddRange(new List<Asiento> { asiento1_5, asiento1_6 });
            listaAsientosSuper2.AddRange(new List<Asiento> { asiento2_5, asiento2_6 });

            Sala salita1 = new Sala(1,listaAsientosEstandar);
            salita1.AgregarAsiento(listaAsientosSuper1);

            Sala salita2 = new Sala(2, asiento2_1);
            salita2.AgregarAsiento(asiento2_2); salita2.AgregarAsiento(asiento2_3); salita2.AgregarAsiento(asiento2_4);
            salita2.AgregarAsiento(listaAsientosSuper2);

            Pelicula pelicula1 = new Pelicula("Star Wars V: El Imperio Contraataca", "Ciencia Ficcion", 127, Formato._2D_Subtitulada);
            Pelicula pelicula2 = new Pelicula("Interestelar", "Ciencia Ficcion", 169, Formato.IMAX_Doblada);

            salita1.DefinirDetallesPelicula(pelicula1);
            salita1.DefinirDetallesPelicula(DateTime.Today.AddDays(1).AddHours(23).AddMinutes(30), DateTime.Today.AddDays(2).AddHours(1).AddMinutes(45));
            salita2.DefinirDetallesPelicula(pelicula2, DateTime.Today.AddDays(1).AddHours(15).AddMinutes(15), DateTime.Today.AddDays(1).AddHours(17).AddMinutes(30));
            //salita1.EmpezarFuncion();
            //salita1.FinalizarFuncion();

            Cine cine = new Cine("Cine Feliz", salita1);
            cine.AgregarSala(salita2);
            cine.ActualizarCartelera();

            string nombreCliente;
            while (true)
            {
                Console.Write($"Bienvenido a {cine.Nombre}\nPor favor Ingrese su Nombre: ");
                nombreCliente = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(nombreCliente))
                {
                    Console.WriteLine("Su Nombre no puede ser nulo\n");
                }
                else
                {
                    break;
                }
            }
            Cliente cliente = new Cliente(nombreCliente);
            
                              // IMPORTANTE LEER:  ya se que esto se DEBE HACER con FUNCIONES pero no pude hacerlo, disculpen el horroroso codigo que van a ver a continuacion //

            Console.WriteLine($"Hola {cliente.Nombre}. Seleccione la accion que desea realizar");
            Console.WriteLine("1 - Ver Cartelera del Cine");
            Console.WriteLine("2 - Ver Precios de asientos");
            Console.WriteLine("3 - Sacar Entrada para una pelicula");
            Console.WriteLine("4 - Salir del Programa\n");
            int accionUsuario;
            int.TryParse(Console.ReadLine(), out accionUsuario);

            bool banderaWhile = true, banderaSalir = true, banderaSacarEntrada = true, banderaAsiento = true, banderaConfirmarCompra = true;
            while (banderaWhile)
            {
                switch (accionUsuario)
                {
                    case 1:
                        cine.MostrarCartelera();
                        break;
                    case 2:
                        cine.MostrarPreciosAsientos();
                        break;
                    case 3:
                        Console.WriteLine("¿Para que pelicula quiere sacar entrada?: ");
                        Console.WriteLine($"1 - {pelicula1.Nombre}");
                        Console.WriteLine($"2 - {pelicula2.Nombre}");
                        Console.WriteLine($"3 - Volver\n");
                        int peliculaUsuario;
                        int.TryParse(Console.ReadLine(), out peliculaUsuario);
                        banderaSacarEntrada = true;
                        while (banderaSacarEntrada)
                        {
                            switch (peliculaUsuario)
                            {
                                case 1:
                                    Console.WriteLine($"Elija un asiento para ver {pelicula1.Nombre}");
                                    salita1.MostrarAsientos();
                                    int asientoUsuario;
                                    int.TryParse(Console.ReadLine(), out asientoUsuario);
                                    banderaAsiento = true;
                                    while (banderaAsiento)
                                    {
                                        switch (asientoUsuario)
                                        {
                                            case 1:
                                                if (asiento1_1.Ocupado)
                                                {
                                                    Console.WriteLine("Este asiento esta ocupado, por favor seleccione otro\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula1.Nombre}, asiento {asiento1_1.Letra}-{asiento1_1.Numero}, Tipo: {asiento1_1.Tipo}?");
                                                    Console.WriteLine("1 - Si");
                                                    Console.WriteLine("2 - No\n");
                                                    int confirmacionUsuario;
                                                    int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                    banderaConfirmarCompra = true;
                                                    while (banderaConfirmarCompra)
                                                    {
                                                        switch(confirmacionUsuario)
                                                        {
                                                            case 1:
                                                                Entrada entradita = new Entrada(cine, pelicula1, asiento1_1, DateTime.Now);
                                                                entradita.CalcularPrecio(asiento1_1.Tipo);
                                                                cliente.SacarEntrada(entradita);
                                                                banderaWhile = false;
                                                                banderaSalir = false;
                                                                banderaSacarEntrada = false;
                                                                banderaAsiento = false;
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            case 2:
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Ingrese una accion válida por favor\n");
                                                                break;
                                                        }
                                                        if (banderaConfirmarCompra)
                                                        {
                                                            Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula1.Nombre}, asiento {asiento1_1.Letra}-{asiento1_1.Numero}, Tipo: {asiento1_1.Tipo}?");
                                                            Console.WriteLine("1 - Si");
                                                            Console.WriteLine("2 - No\n");
                                                            int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                        }
                                                    }
                                                }
                                                break;
                                            case 2:
                                                if (asiento1_2.Ocupado)
                                                {
                                                    Console.WriteLine("Este asiento esta ocupado, por favor seleccione otro\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula1.Nombre}, asiento {asiento1_2.Letra}-{asiento1_2.Numero}, Tipo: {asiento1_2.Tipo}?");
                                                    Console.WriteLine("1 - Si");
                                                    Console.WriteLine("2 - No\n");
                                                    int confirmacionUsuario;
                                                    int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                    banderaConfirmarCompra = true;
                                                    while (banderaConfirmarCompra)
                                                    {
                                                        switch (confirmacionUsuario)
                                                        {
                                                            case 1:
                                                                Entrada entradita = new Entrada(cine, pelicula1, asiento1_2, DateTime.Now);
                                                                entradita.CalcularPrecio(asiento1_2.Tipo);
                                                                cliente.SacarEntrada(entradita); 
                                                                banderaWhile = false;
                                                                banderaSalir = false;
                                                                banderaSacarEntrada = false;
                                                                banderaAsiento = false;
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            case 2:
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Ingrese una accion válida por favor\n");
                                                                break;
                                                        }
                                                        if (banderaConfirmarCompra)
                                                        {
                                                            Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula1.Nombre}, asiento {asiento1_2.Letra}-{asiento1_2.Numero}, Tipo: {asiento1_2.Tipo}?");
                                                            Console.WriteLine("1 - Si");
                                                            Console.WriteLine("2 - No\n");
                                                            int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                        }
                                                    }
                                                }
                                                break;
                                            case 3:
                                                if (asiento1_3.Ocupado)
                                                {
                                                    Console.WriteLine("Este asiento esta ocupado, por favor seleccione otro\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula1.Nombre}, asiento {asiento1_3.Letra}-{asiento1_3.Numero}, Tipo: {asiento1_3.Tipo}?");
                                                    Console.WriteLine("1 - Si");
                                                    Console.WriteLine("2 - No\n");
                                                    int confirmacionUsuario;
                                                    int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                    banderaConfirmarCompra = true;
                                                    while (banderaConfirmarCompra)
                                                    {
                                                        switch (confirmacionUsuario)
                                                        {
                                                            case 1:
                                                                Entrada entradita = new Entrada(cine, pelicula1, asiento1_3, DateTime.Now);
                                                                entradita.CalcularPrecio(asiento1_3.Tipo);
                                                                cliente.SacarEntrada(entradita); 
                                                                banderaWhile = false;
                                                                banderaSalir = false;
                                                                banderaSacarEntrada = false;
                                                                banderaAsiento = false;
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            case 2:
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Ingrese una accion válida por favor\n");
                                                                break;
                                                        }
                                                        if (banderaConfirmarCompra)
                                                        {
                                                            Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula1.Nombre}, asiento {asiento1_3.Letra}-{asiento1_3.Numero}, Tipo: {asiento1_3.Tipo}?");
                                                            Console.WriteLine("1 - Si");
                                                            Console.WriteLine("2 - No\n");
                                                            int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                        }
                                                    }
                                                }
                                                break;
                                            case 4:
                                                if (asiento1_4.Ocupado)
                                                {
                                                    Console.WriteLine("Este asiento esta ocupado, por favor seleccione otro\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula1.Nombre}, asiento {asiento1_4.Letra}-{asiento1_4.Numero}, Tipo: {asiento1_4.Tipo}?");
                                                    Console.WriteLine("1 - Si");
                                                    Console.WriteLine("2 - No\n");
                                                    int confirmacionUsuario;
                                                    int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                    banderaConfirmarCompra = true;
                                                    while (banderaConfirmarCompra)
                                                    {
                                                        switch (confirmacionUsuario)
                                                        {
                                                            case 1:
                                                                Entrada entradita = new Entrada(cine, pelicula1, asiento1_4, DateTime.Now);
                                                                entradita.CalcularPrecio(asiento1_4.Tipo);
                                                                cliente.SacarEntrada(entradita); 
                                                                banderaWhile = false;
                                                                banderaSalir = false;
                                                                banderaSacarEntrada = false;
                                                                banderaAsiento = false;
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            case 2:
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Ingrese una accion válida por favor\n");
                                                                break;
                                                        }
                                                        if (banderaConfirmarCompra)
                                                        {
                                                            Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula1.Nombre}, asiento {asiento1_4.Letra}-{asiento1_4.Numero}, Tipo: {asiento1_4.Tipo}?");
                                                            Console.WriteLine("1 - Si");
                                                            Console.WriteLine("2 - No\n");
                                                            int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                        }
                                                    }
                                                }
                                                break;
                                            case 5:
                                                if (asiento1_5.Ocupado)
                                                {
                                                    Console.WriteLine("Este asiento esta ocupado, por favor seleccione otro\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula1.Nombre}, asiento {asiento1_5.Letra}-{asiento1_5.Numero}, Tipo: {asiento1_5.Tipo}?");
                                                    Console.WriteLine("1 - Si");
                                                    Console.WriteLine("2 - No\n");
                                                    int confirmacionUsuario;
                                                    int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                    banderaConfirmarCompra = true;
                                                    while (banderaConfirmarCompra)
                                                    {
                                                        switch (confirmacionUsuario)
                                                        {
                                                            case 1:
                                                                Entrada entradita = new Entrada(cine, pelicula1, asiento1_5, DateTime.Now);
                                                                entradita.CalcularPrecio(asiento1_5.Tipo);
                                                                cliente.SacarEntrada(entradita);
                                                                banderaWhile = false;
                                                                banderaSalir = false;
                                                                banderaSacarEntrada = false;
                                                                banderaAsiento = false;
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            case 2:
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Ingrese una accion válida por favor\n");
                                                                break;
                                                        }
                                                        if (banderaConfirmarCompra)
                                                        {
                                                            Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula1.Nombre}, asiento {asiento1_5.Letra}-{asiento1_5.Numero}, Tipo: {asiento1_5.Tipo}?");
                                                            Console.WriteLine("1 - Si");
                                                            Console.WriteLine("2 - No\n");
                                                            int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                        }
                                                    }
                                                }
                                                break;
                                            case 6:
                                                if (asiento1_6.Ocupado)
                                                {
                                                    Console.WriteLine("Este asiento esta ocupado, por favor seleccione otro\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula1.Nombre}, asiento {asiento1_6.Letra}-{asiento1_6.Numero}, Tipo: {asiento1_6.Tipo}?");
                                                    Console.WriteLine("1 - Si");
                                                    Console.WriteLine("2 - No\n");
                                                    int confirmacionUsuario;
                                                    int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                    banderaConfirmarCompra = true;
                                                    while (banderaConfirmarCompra)
                                                    {
                                                        switch (confirmacionUsuario)
                                                        {
                                                            case 1:
                                                                Entrada entradita = new Entrada(cine, pelicula1, asiento1_6, DateTime.Now);
                                                                entradita.CalcularPrecio(asiento1_6.Tipo);
                                                                cliente.SacarEntrada(entradita);
                                                                banderaWhile = false;
                                                                banderaSalir = false;
                                                                banderaSacarEntrada = false;
                                                                banderaAsiento = false;
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            case 2:
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Ingrese una accion válida por favor\n");
                                                                break;
                                                        }
                                                        if (banderaConfirmarCompra)
                                                        {
                                                            Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula1.Nombre}, asiento {asiento1_6.Letra}-{asiento1_6.Numero}, Tipo: {asiento1_6.Tipo}?");
                                                            Console.WriteLine("1 - Si");
                                                            Console.WriteLine("2 - No\n");
                                                            int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                        }
                                                    }
                                                }
                                                break;
                                            case 7:
                                                banderaAsiento = false;
                                                break;
                                            default:
                                                Console.WriteLine("Ingrese una accion válida por favor\n");
                                                break;
                                        }
                                        if (banderaAsiento)
                                        {
                                            Console.WriteLine($"Elija un asiento para ver {pelicula1.Nombre}");
                                            salita1.MostrarAsientos();
                                            int.TryParse(Console.ReadLine(), out asientoUsuario);
                                        }
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine($"Elija un asiento para ver {pelicula2.Nombre}");
                                    salita2.MostrarAsientos();
                                    int.TryParse(Console.ReadLine(), out asientoUsuario);
                                    banderaAsiento = true;
                                    while (banderaAsiento)
                                    {
                                        switch (asientoUsuario)
                                        {
                                            case 1:
                                                if (asiento2_1.Ocupado)
                                                {
                                                    Console.WriteLine("Este asiento esta ocupado, por favor seleccione otro\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula2.Nombre}, asiento {asiento2_1.Letra}-{asiento2_1.Numero}, Tipo: {asiento2_1.Tipo}?");
                                                    Console.WriteLine("1 - Si");
                                                    Console.WriteLine("2 - No\n");
                                                    int confirmacionUsuario;
                                                    int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                    banderaConfirmarCompra = true;
                                                    while (banderaConfirmarCompra)
                                                    {
                                                        switch (confirmacionUsuario)
                                                        {
                                                            case 1:
                                                                Entrada entradita = new Entrada(cine, pelicula2, asiento2_1, DateTime.Now);
                                                                entradita.CalcularPrecio(asiento2_1.Tipo);
                                                                cliente.SacarEntrada(entradita);
                                                                banderaWhile = false;
                                                                banderaSalir = false;
                                                                banderaSacarEntrada = false;
                                                                banderaAsiento = false;
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            case 2:
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Ingrese una accion válida por favor\n");
                                                                break;
                                                        }
                                                        if (banderaConfirmarCompra)
                                                        {
                                                            Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula2.Nombre}, asiento {asiento2_1.Letra}-{asiento2_1.Numero}, Tipo: {asiento2_1.Tipo}?");
                                                            Console.WriteLine("1 - Si");
                                                            Console.WriteLine("2 - No\n");
                                                            int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                        }
                                                    }
                                                }
                                                break;
                                            case 2:
                                                if (asiento2_2.Ocupado)
                                                {
                                                    Console.WriteLine("Este asiento esta ocupado, por favor seleccione otro\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula2.Nombre}, asiento {asiento2_2.Letra}-{asiento2_2.Numero}, Tipo: {asiento2_2.Tipo}?");
                                                    Console.WriteLine("1 - Si");
                                                    Console.WriteLine("2 - No\n");
                                                    int confirmacionUsuario;
                                                    int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                    banderaConfirmarCompra = true;
                                                    while (banderaConfirmarCompra)
                                                    {
                                                        switch (confirmacionUsuario)
                                                        {
                                                            case 1:
                                                                Entrada entradita = new Entrada(cine, pelicula2, asiento2_2, DateTime.Now);
                                                                entradita.CalcularPrecio(asiento2_2.Tipo);
                                                                cliente.SacarEntrada(entradita); 
                                                                banderaWhile = false;
                                                                banderaSalir = false;
                                                                banderaSacarEntrada = false;
                                                                banderaAsiento = false;
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            case 2:
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Ingrese una accion válida por favor\n");
                                                                break;
                                                        }
                                                        if (banderaConfirmarCompra)
                                                        {
                                                            Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula2.Nombre}, asiento {asiento2_2.Letra}-{asiento2_2.Numero}, Tipo: {asiento2_2.Tipo}?");
                                                            Console.WriteLine("1 - Si");
                                                            Console.WriteLine("2 - No\n");
                                                            int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                        }
                                                    }
                                                }
                                                break;
                                            case 3:
                                                if (asiento2_3.Ocupado)
                                                {
                                                    Console.WriteLine("Este asiento esta ocupado, por favor seleccione otro\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula2.Nombre}, asiento {asiento2_3.Letra}-{asiento2_3.Numero}, Tipo: {asiento2_3.Tipo}?");
                                                    Console.WriteLine("1 - Si");
                                                    Console.WriteLine("2 - No\n");
                                                    int confirmacionUsuario;
                                                    int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                    banderaConfirmarCompra = true;
                                                    while (banderaConfirmarCompra)
                                                    {
                                                        switch (confirmacionUsuario)
                                                        {
                                                            case 1:
                                                                Entrada entradita = new Entrada(cine, pelicula2, asiento2_3, DateTime.Now);
                                                                entradita.CalcularPrecio(asiento2_3.Tipo);
                                                                cliente.SacarEntrada(entradita); 
                                                                banderaWhile = false;
                                                                banderaSalir = false;
                                                                banderaSacarEntrada = false;
                                                                banderaAsiento = false;
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            case 2:
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Ingrese una accion válida por favor\n");
                                                                break;
                                                        }
                                                        if (banderaConfirmarCompra)
                                                        {
                                                            Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula2.Nombre}, asiento {asiento2_3.Letra}-{asiento2_3.Numero}, Tipo: {asiento2_3.Tipo}?");
                                                            Console.WriteLine("1 - Si");
                                                            Console.WriteLine("2 - No\n");
                                                            int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                        }
                                                    }
                                                }
                                                break;
                                            case 4:
                                                if (asiento2_4.Ocupado)
                                                {
                                                    Console.WriteLine("Este asiento esta ocupado, por favor seleccione otro\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula2.Nombre}, asiento {asiento2_4.Letra}-{asiento2_4.Numero}, Tipo: {asiento2_4.Tipo}?");
                                                    Console.WriteLine("1 - Si");
                                                    Console.WriteLine("2 - No\n");
                                                    int confirmacionUsuario;
                                                    int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                    banderaConfirmarCompra = true;
                                                    while (banderaConfirmarCompra)
                                                    {
                                                        switch (confirmacionUsuario)
                                                        {
                                                            case 1:
                                                                Entrada entradita = new Entrada(cine, pelicula2, asiento2_4, DateTime.Now);
                                                                entradita.CalcularPrecio(asiento2_4.Tipo);
                                                                cliente.SacarEntrada(entradita); 
                                                                banderaWhile = false;
                                                                banderaSalir = false;
                                                                banderaSacarEntrada = false;
                                                                banderaAsiento = false;
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            case 2:
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Ingrese una accion válida por favor\n");
                                                                break;
                                                        }
                                                        if (banderaConfirmarCompra)
                                                        {
                                                            Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula2.Nombre}, asiento {asiento2_4.Letra}-{asiento2_4.Numero}, Tipo: {asiento2_4.Tipo}?");
                                                            Console.WriteLine("1 - Si");
                                                            Console.WriteLine("2 - No\n");
                                                            int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                        }
                                                    }
                                                }
                                                break;
                                            case 5:
                                                if (asiento2_5.Ocupado)
                                                {
                                                    Console.WriteLine("Este asiento esta ocupado, por favor seleccione otro\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula2.Nombre}, asiento {asiento2_5.Letra}-{asiento2_5.Numero}, Tipo: {asiento2_5.Tipo}?");
                                                    Console.WriteLine("1 - Si");
                                                    Console.WriteLine("2 - No\n");
                                                    int confirmacionUsuario;
                                                    int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                    banderaConfirmarCompra = true;
                                                    while (banderaConfirmarCompra)
                                                    {
                                                        switch (confirmacionUsuario)
                                                        {
                                                            case 1:
                                                                Entrada entradita = new Entrada(cine, pelicula2, asiento2_5, DateTime.Now);
                                                                entradita.CalcularPrecio(asiento2_5.Tipo);
                                                                cliente.SacarEntrada(entradita); 
                                                                banderaWhile = false;
                                                                banderaSalir = false;
                                                                banderaSacarEntrada = false;
                                                                banderaAsiento = false;
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            case 2:
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Ingrese una accion válida por favor\n");
                                                                break;
                                                        }
                                                        if (banderaConfirmarCompra)
                                                        {
                                                            Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula2.Nombre}, asiento {asiento2_5.Letra}-{asiento2_5.Numero}, Tipo: {asiento2_5.Tipo}?");
                                                            Console.WriteLine("1 - Si");
                                                            Console.WriteLine("2 - No\n");
                                                            int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                        }
                                                    }
                                                }
                                                break;
                                            case 6:
                                                if (asiento2_6.Ocupado)
                                                {
                                                    Console.WriteLine("Este asiento esta ocupado, por favor seleccione otro\n");
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula2.Nombre}, asiento {asiento2_6.Letra}-{asiento2_6.Numero}, Tipo: {asiento2_6.Tipo}?");
                                                    Console.WriteLine("1 - Si");
                                                    Console.WriteLine("2 - No\n");
                                                    int confirmacionUsuario;
                                                    int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                    banderaConfirmarCompra = true;
                                                    while (banderaConfirmarCompra)
                                                    {
                                                        switch (confirmacionUsuario)
                                                        {
                                                            case 1:
                                                                Entrada entradita = new Entrada(cine, pelicula2, asiento2_6, DateTime.Now);
                                                                entradita.CalcularPrecio(asiento2_6.Tipo);
                                                                cliente.SacarEntrada(entradita); 
                                                                banderaWhile = false;
                                                                banderaSalir = false;
                                                                banderaSacarEntrada = false;
                                                                banderaAsiento = false;
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            case 2:
                                                                banderaConfirmarCompra = false;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Ingrese una accion válida por favor\n");
                                                                break;
                                                        }
                                                        if (banderaConfirmarCompra)
                                                        {
                                                            Console.WriteLine($"¿Confirma la compra de la entrada a la pelicula {pelicula2.Nombre}, asiento {asiento2_6.Letra}-{asiento2_6.Numero}, Tipo: {asiento2_6.Tipo}?");
                                                            Console.WriteLine("1 - Si");
                                                            Console.WriteLine("2 - No\n");
                                                            int.TryParse(Console.ReadLine(), out confirmacionUsuario);
                                                        }
                                                    }
                                                }
                                                break;
                                            case 7:
                                                banderaAsiento = false;
                                                break;
                                            default:
                                                Console.WriteLine("Ingrese una accion válida por favor\n");
                                                break;
                                        }
                                        if (banderaAsiento)
                                        {
                                            Console.WriteLine($"Elija un asiento para ver {pelicula2.Nombre}");
                                            salita1.MostrarAsientos();
                                            int.TryParse(Console.ReadLine(), out asientoUsuario);
                                        }
                                    }
                                    break;
                                case 3:
                                    banderaSacarEntrada = false;
                                    break;
                                default:
                                    Console.WriteLine("Ingrese una accion válida por favor\n");
                                    break;
                            }
                            if (banderaSacarEntrada)
                            {
                                Console.WriteLine("¿Para que pelicula quiere sacar entrada?: ");
                                Console.WriteLine($"1 - {pelicula1.Nombre}");
                                Console.WriteLine($"2 - {pelicula2.Nombre}");
                                Console.WriteLine($"3 - Volver\n");
                                int.TryParse(Console.ReadLine(), out peliculaUsuario);
                            }
                        }
                        break;
                    case 4:
                        banderaSalir = false;
                        banderaWhile = false;
                        break;
                    default:
                        Console.WriteLine("Ingrese una accion válida por favor\n");
                        break;
                }
                if (banderaSalir)
                {
                    Console.WriteLine($"Hola {cliente.Nombre}. Seleccione la accion que desea realizar");
                    Console.WriteLine("1 - Ver Cartelera del Cine");
                    Console.WriteLine("2 - Ver Precios de asientos");
                    Console.WriteLine("3 - Sacar Entrada para una pelicula");
                    Console.WriteLine("4 - Salir del Programa\n");
                    int.TryParse(Console.ReadLine(), out accionUsuario);
                }
                else
                {
                    Console.WriteLine("Saliendo del Programa...");
                }
                             // IMPORTANTE LEER:  ya se que esto se DEBE HACER con FUNCIONES pero no pude hacerlo, disculpen el horroroso codigo que vieron //
            }
        }
    }
}