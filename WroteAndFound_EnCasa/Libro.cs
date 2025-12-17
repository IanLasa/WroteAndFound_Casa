class Libro{

    public string Titulo {get; private set;}
    public string Autor {get; private set;}
    public int Anyo {get; private set;}
    public string Genero {get; private set;}
    public bool Disponible {get; private set;}

    public List<Resenya> Reseñas = new List<Resenya>();


    public Libro(string titulo, string autor = "Desconocido", int anyo = 0, string genero = "Desconocido")
    {
        this.Titulo = titulo;
        this.Autor = autor;
        this.Anyo = anyo;
        this.Genero = genero;
        this.Disponible = true;
        Reseñas = new List<Resenya>();
    }

}
