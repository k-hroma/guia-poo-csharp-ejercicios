/*
12. Continuando con el ejemplo anterior, realizar las siguientes modificaciones:
● Modificar la clase Guardia para que el método público controlarDocumento() devuelva el mensaje “Adelante <nombre completo del visitante> con dni <dni>” reemplazando respectivamente con el nombre completo del visitante y su dni.
● Crear una instancia de cada una de las clases y asignarle valores.
● Mostrar por pantalla los valores.
● Analizar si es posible pasar un único parámetro al método controlarDocumento() y estudiar las ventas y desventajas que tendría asociado.
*/

public class Persona
{
  protected string nombre;
  protected string apellido;

  public Persona(string nombre, string apellido)
  {
    this.nombre = nombre;
    this.apellido = apellido;
  }

  public void SetNombre(string nombre)
  {
    this.nombre = nombre;
  }

  public string GetNombre()
  {
    return nombre;
  }

  public void SetApellido(string apellido)
  {
    this.apellido = apellido;
  }

  public string GetApellido()
  {
    return apellido;
  }

  public virtual string Presentarse()
  {
    return $"Hola, mi nombre es {nombre} {apellido}";
  }
}
public class Visitante : Persona
{
  //propfull
  private int dni;
  public int Dni
  {
    get { return dni; }
    set { dni = value; }
  }

  public Visitante(string nombre, string apellido, int dni) : base(nombre, apellido)
  {
    Dni = dni;
  }

}

public class Guardia : Persona
{

  public Guardia(string nombre, string apellido) : base(nombre, apellido)
  {
  }
  public string ControlarDocumento(Visitante visitante)
  {
    return $"Adelante {visitante.GetNombre()} {visitante.GetApellido()} con dni: {visitante.Dni}";
  }
  public override string Presentarse()
  {
    return $"Hola, mi nombre es {nombre} {apellido} y soy el guardia.";
  }
}

public class Program
{
  public static void Main()
  {
    Persona persona = new Persona("Croma", "Gainza");
    Visitante visitante = new Visitante("Pepe", "Perez", 32990435);
    Guardia guardia = new Guardia("Juan", "Lopez");

    Console.WriteLine(persona.Presentarse());
    Console.WriteLine(visitante.Presentarse());
    Console.WriteLine(guardia.Presentarse());

    Console.WriteLine(guardia.ControlarDocumento(visitante));
  }
}

