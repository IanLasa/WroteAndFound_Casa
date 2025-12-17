class Libreria
{

    private string Nombre { get; set; }
    private string Creador { get; set; }
    private DateOnly CreadoEl { get; set; }
    private TimeOnly;
    static List<Libro> Libros = new List<Libro>();


    static bool Salir = false;
    static int Opcion;


    public Libreria(string nombre, string creador, DateOnly creadoEn)
    {
        this.Nombre = nombre;
        this.Creador = creador;
        this.CreadoEl = creadoEn;
    }

    public List<Libro> ListarLosLibros()
    {
        return Libros;
    }

    public void AgregarLibro(Libro Libro)
    {
        Libros.Add(Libro);
    }





    public static void verLibros()
    {
        Console.Clear();
        if (Comprobaciones.HayLibros())
        {
            do
            {
                Menus.MenuListaDeLibros("LIBROS", Libros, "Escribe el número del libro que quieres ver más", 0, Libros.Count, 50);
                if (Opcion > 0 && Opcion <= Libros.Count)
                {
                    verCaracteristicasLibro(Opcion - 1, false);

                }
                else
                {
                    Salir = true;
                }

            } while (!Salir);
        }
        Salir = false;
    }

    // Ver características del libro que se pida
    public static void verCaracteristicasLibro(int l, bool special)
    {
        int i = 5;
        while (!Salir)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"   Libro {l + 1}:");
            Console.WriteLine($"   Título: {Libros[l].Titulo}");
            Console.WriteLine($"   Autor:  {Libros[l].Autor}");
            Console.WriteLine($"   Año:    {Libros[l].Anyo}");
            Console.WriteLine($"   Género: {Libros[l].Genero}");
            Console.WriteLine("");
            Console.WriteLine($"   Estado:", Comprobaciones.EstaDisponible(Libros, i));
            i = Resenya.CaracteristicasReseñas(l, i);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("");
            if (i != 6 && !special)
            {
                // Simplemente tiene que poner "Si" para salir volver
                string OpcionString = Comprobaciones.PedirString("Escribe \"Si\" para volver atras", 50);
                if (OpcionString == "Si")
                {
                    Salir = true;
                }
            }
            else if (i == 6 && !special)
            {
                Console.WriteLine("Presiona una tecla para volver...");
                Console.ReadKey();
                Salir = true;
            }
            else
            {
                Salir = true;
            }
        }
        Salir = false;
    }




    // Función añadir libro
    public static void anhadirLibro()
    {
        Console.Clear();
        if (hayUsuarioActual == false)
        {
            Console.WriteLine("");
            Console.WriteLine("No estás iniciado como un usario, por favor crea uno o cambia a uno");
            Console.ReadKey();
        }
        else
        {
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("   ¡Vamos a añadir un nuevo libro!");
                Console.WriteLine("");
                Console.WriteLine($"📘 Libro {Libros.Count + 1}:");

                // Crea una nueva lista , dentro de la lista de Libros
                Libros.Add(new List<string>() { pedirString("Título", 40) });
                Libros[Libros.Count - 1].Add(pedirString("Autor", 30));
                Libros[Libros.Count - 1].Add(pedirString("Año", 8));
                Libros[Libros.Count - 1].Add(pedirString("Genero", 30));
                Libros[Libros.Count - 1].Add("Disponible");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("¡Libro añadido!");
                Console.WriteLine("");
                pedirString("Escribe \"salir\", si no quieres seguir añadiendo", 10);
                if (opcionString == "salir")
                {
                    salir = true;
                }
            }
            salir = false;
        }
    }

    public static void eliminarLibro()
    {
        Console.Clear();
        if (hayUsuarioActual == false)
        {
            Console.WriteLine("");
            Console.WriteLine("No estás iniciado como un usario, por favor crea uno o cambia a uno");
            Console.ReadKey();
        }
        else
        {
            while (!salir)
            {
                Console.Clear();
                if (hayLibros())
                {
                    menuListaDeListas("LIBROS", Libros, 0, "Escribe el número del libro que quieres eliminar", 0, Libros.Count, 50);
                    if (opcion != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("");
                        Console.Write("Escribe \"si\" para confirmar o cualquier otra cosa para cancelar: ");
                        string confirmar = Console.ReadLine();
                        Console.WriteLine("");
                        if (confirmar == "si")
                        {
                            Console.WriteLine("!Libro borrado del catálogo!");
                            // Lo de abajo, es para que se borre el libros y no aparezca como prestado en un usuario.
                            for (int i = 0; i < Usuarios.Count; i++)
                            {
                                for (int j = 2; j < Usuarios[i].Count; j++)
                                {
                                    if (Usuarios[i][j] == Libros[opcion - 1][0])
                                    {
                                        Usuarios[i].RemoveAt(j);
                                    }
                                }
                            }
                            Libros.RemoveAt(opcion - 1);
                        }
                        else
                        {
                            Console.WriteLine("Has cancelado borrar un libro");
                        }

                        Console.WriteLine("");
                        Console.Write("Escribe \"si\", si quieres borrar otro");
                        string borrarOtro = Console.ReadLine();
                        if (borrarOtro != "si")
                        {
                            salir = true;
                        }
                    }
                    else
                    {
                        salir = true;
                    }
                }
            }
            salir = false;
        }
    }

    // Menu Buscar Libro por lo que sea
    public static void buscarLibro()
    {
        do
        {
            Console.Clear();
            menu = new string[] { "Buscar por Título", "Buscar por Autor", "Buscar por año", "Buscar por Genero", "Buscar por Reseñas" };
            menuBonito("BUSCAR POR", menu, "Escribe el número de lo que quieres hacer", 0, 5, 37);
            switch (opcion)
            {
                case 1:
                    buscarLibroPor(opcion, "Título");
                    Console.ReadKey();
                    break;
                case 2:
                    buscarLibroPor(opcion, "Autor");
                    Console.ReadKey();
                    break;
                case 3:
                    buscarLibroPor(opcion, "Año");
                    Console.ReadKey();
                    break;
                case 4:
                    buscarLibroPor(opcion, "Genero");
                    Console.ReadKey();
                    break;
                case 5:
                    buscarLibroPor(opcion, "Reseñas");
                    Console.ReadKey();
                    break;
                case 0:
                    salir = true;
                    break;
            }
        } while (!salir);
        salir = false;
    }

    // Función buscar en cada caso
    static void buscarLibroPor(int campo, string tipo)
    {
        Console.Clear();

        // Contador de resultados
        int hayResultados = 0;

        // Cuantas estrellas tiene una reseña
        int estrellas = -1;

        // Si no hay reseñas, sale
        if (tipo == "Reseñas" && !hayReseñas())
        {
            Console.WriteLine("No hay reseñas en ningún libro.");
            Console.WriteLine("");
            Console.WriteLine("Presiona una tecla para volver atrás");
            return;
        }

        // Si son reseñas pide int, sino un string.
        if (tipo == "Reseñas")
        {
            estrellas = pedirNumero($"Escribe la {tipo} del libro", 1, 5, false);
        }
        else
        {
            pedirString($"Escribe el {tipo} del libro", 30);
        }

        Console.WriteLine("");
        Console.WriteLine("");

        // Como se muestra si es título, Reseña, y las demas juntas.
        for (int i = 0; i < Libros.Count; i++)
        {
            if (tipo == "Título" && opcionString == Libros[i][campo - 1])
            {
                Console.WriteLine($"  {i + 1}. {Libros[i][campo]}");
                Console.WriteLine("");
                hayResultados += 1;
            }
            else if (tipo != "Reseñas" && tipo != "Título" && opcionString == Libros[i][campo - 1])
            {
                Console.WriteLine($"  {i + 1}. {Libros[i][0]}");
                Console.WriteLine($"       {Libros[i][campo - 1]}");
                Console.WriteLine("");
                hayResultados += 1;

            }
            else if (tipo == "Reseñas")
            {
                for (int j = 5; j < Libros[i].Count; j++)
                {
                    if (estrellas == Libros[i][j].Length)
                    {
                        Console.WriteLine($"  {i + 1}. {Libros[i][0]}");
                        Console.WriteLine($"       {Libros[i][j]}");
                        Console.WriteLine("");
                        hayResultados += 1;
                    }
                }
            }
        }
        // Si hay resultados, te dice quantos.
        if (hayResultados != 0)
        {   // Uno para Reseñas y el otro para los demás
            if (tipo == "Reseñas")
            {
                Console.WriteLine($"Hay {hayResultados} resultados para {estrellas} estrellas.");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine($"Hay {hayResultados} resultados para {opcionString}.");
                Console.WriteLine("");
            }

        }
        else
        {
            Console.WriteLine("No hay resultados...");
            Console.WriteLine("");
            Console.WriteLine("Presiona una tecla para volver atrás");
        }
    }




}
