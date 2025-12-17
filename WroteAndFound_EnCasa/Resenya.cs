class Resenya
{
    private string Autor {get; set;}
    private string Comentario {get; set;}
    private string Calificacion {get; set;}

    private static bool Salir = true;
    private static int OpcionInt;
    private static string OpcionString = "";

    Resenya(string autor, string comentario, int calificacion)
    {
        this.Autor = autor;
        this.Comentario = comentario;
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


    public static void ponerResenhas()
        {
            Console.Clear();
            // Sale si no esta iniciado sesión
            if (!hayUsuarioActual)
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
                    if (hayLibros())
                    {
                        menuListaDeListas("LIBROS", Libros, 0, "Escribe el número del libro que quieres poner reseña", 0, Libros.Count, 50);
                        if (Opcion != 0)
                        {
                            for (int i = 5; i < Libros[Opcion - 1].Count; i += 2)
                            {
                                if (usuarioActual == Libros[Opcion - 1][i])
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
                            if (!Salir)
                            {
                                // Pedir y añadir Reseñá
                                Console.Clear();
                                verCaracteristicasLibro(Opcion - 1, true);
                                Console.WriteLine();
                                opcion2 = pedirNumero("Que reseña le quieres poner", 1, 5, false);
                                Console.WriteLine();
                                Libros[Opcion - 1].Add(usuarioActual);
                                Libros[Opcion - 1].Add(new string('⭐', opcion2));
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


    public static int CaracteristicasReseñas(int l, int i)
        {
                    
            if (hayReseñas())
            {   
                // Contador para que muestre máximo dos, luego deje darle al intro.
                int Contador = 0;
                for (int j = i; j < Libros[l].Count - 1; j += 2)
                {
                    if (Contador == 2)
                    {
                        Console.WriteLine("Pulsa cualquier tecla para ver más reseñas");
                        return j;
                    }
                    opcionString = $"{Libros[l][j] }: {Libros[l][j + 1]}";
                    Console.WriteLine($"   {opcionString.PadRight(18)}");
                    Contador += 1;
                }
                Console.WriteLine("No hay mas reseñas. Presiona intro ir para atras");
                return 6;

            }
            else
            {
                Console.WriteLine("   No hay Reseñas");
                return 6;
            }
        }
}

