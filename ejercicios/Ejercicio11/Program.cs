/*
11. Continuando con el ejemplo anterior, realizar las siguientes modificaciones:
● Agregar en Visitante el atributo privado dni (numérico) con sus setters y getters correspondientes.
● Agregar en Guardia el método público controlarDocumento() que reciba como parámetro el dni de la persona y devuelva el mensaje “Adelante persona con dni <dni>” donde <dni> es el valor recibido por parámetro.
● Crear una instancia de cada una de las clases y asignarle valores.
● Mostrar por pantalla los valores.
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
  private int dni;

  public Visitante(string nombre, string apellido, int dni) : base(nombre, apellido)
  {
    this.dni = dni;
  }

  public void SetDni(int dni)
  {
    this.dni = dni;
  }
  public int GetDni()
  {
    return dni;
  }
}

public class Guardia : Persona
{

  public Guardia(string nombre, string apellido) : base(nombre, apellido)
  {
  }
  public string ControlarDocumento(int dni)
  {
    return $"Adelante persona con dni: {dni}";
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

    Console.WriteLine(guardia.ControlarDocumento(visitante.GetDni()));
  }
}
