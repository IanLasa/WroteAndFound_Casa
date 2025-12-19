class Resenya
{
    public string Autor { get; private set; }
    public string Calificacion { get; private set; }

    private static bool Salir = true;
    private static int CalificacionResenya;


    Resenya(string autor, int calificacion)
    {
        this.Autor = autor;
        this.Calificacion = new string('⭐', calificacion);
    }

    /// <summary>
    /// foreach (var libro in libros)
    /// {
    ///     if (libro.Titulo == tituloBuscado)}
    ///     {
    ///     libro.AgregarResenya(nuevaResenya);
    ///     break;
    ///     }
    /// </summary>


    public static void PonerResenyas()
    {
        Console.Clear();
        // Sale si no esta iniciado sesión
        if (Usuario.HayUsuarioActual)
        {
            Console.WriteLine("");
            Console.WriteLine("No estás iniciado como un usario, por favor crea uno o cambia a uno");
            Console.ReadKey();
        }
        else
        {
            while (!Salir)
            {
                Console.Clear();
                if (Comprobaciones.HayLibros())
                {
                    Menus.MenuListaDeLibros("LIBROS", Libreria.ListaDeLibros(), "Escribe el número del libro que quieres poner reseña", 0, Libreria.NumeroDeLibros(), 50);
                    if (Menus.Opcion != 0)
                    {
                        foreach (var Lib in Libreria.ListaDeLibros())
                        {
                            foreach (var Us in Lib.Resenyas)
                            {
                                if (Us.Autor == Usuario.UsuarioActual)
                                {
                                    // En el caso de que ya haya puesto antes una reseña
                                    Console.Clear();
                                    Console.WriteLine(" Este usuario ya le ha puesto una reseña a este libro...");
                                    Console.WriteLine("");
                                    Console.WriteLine("Presiona una tecla para volver a intentarlo...");
                                    Console.ReadKey();
                                    Salir = true;
                                } 
                            }
                        }
                        if (!Salir)
                        {
                            // Pedir y añadir Reseñá
                            Console.Clear();
                            Libreria.VerCaracteristicasLibro(Menus.Opcion - 1, true);
                            Console.WriteLine();
                            CalificacionResenya = Comprobaciones.PedirNumero("Que reseña le quieres poner", 1, 5, false);

                            Console.WriteLine();
                            
                            Libreria.AgregarResenya(Menus.Opcion, new Resenya(Usuario.UsuarioActual, CalificacionResenya));
                            Console.Clear();
                            Console.WriteLine("Se ha añadido la reseña correctamente");
                            Console.WriteLine();
                            Console.WriteLine("Pulsa una tecla para continuar");
                            Salir = true;
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Salir = true;
                    }
                }
                else
                {
                    Salir = true;
                }
            }
            Salir = false;
        }
    }


   // public static int CaracteristicasReseñas()
   // {
//
   //     if (Comprobaciones.HayResenyas(Libreria.ListaDeLibros()))
   //     {
   //         // Contador para que muestre máximo dos, luego deje darle al intro.
   //         int Contador = 0;
   //         foreach (Libro Lib in Libreria.ListaDeLibros())
   //         {
   //             if (Contador % 2 == 0 && Contador != 0)
   //             {
   //                 Console.WriteLine("Pulsa cualquier tecla para ver más reseñas");
   //                 return j;
   //             }
   //         }
   //         for (int j = i; j < Libreria.NumeroDeLibros() - 1; j += 2)
   //         {
   //             if (Contador == 2)
   //             {
   //                 
   //             }
   //             opcionString = $"{Libros[l][j]}: {Libros[l][j + 1]}";
   //             Console.WriteLine($"   {opcionString.PadRight(18)}");
   //             Contador += 1;
   //         }
   //         Console.WriteLine("No hay mas reseñas. Presiona intro ir para atras");
   //         return 6;
//
   //     }
   //     else
   //     {
   //         Console.WriteLine("   No hay Reseñas");
   //         return 6;
   //     }
   // }
}

