/*
9. Crear una clase Persona que tenga los atributos privados nombre y apellido, con sus setters y getters.
● Crear una clase llamada Visitante que extienda de Persona.
● Crear una clase Guardia que extienda de Persona.
● Crear una instancia de cada una de las clases y asignarle valores.
● Mostrar por pantalla los valores; estudiar las ventajas del uso de la herencia.
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
}



public class Visitante : Persona
{
  public Visitante(string nombre, string apellido) : base(nombre, apellido)
  {

  }
}

public class Guardia : Persona
{
  public Guardia(string nombre, string apellido) : base(nombre, apellido)
  {
  }
}

public class Program
{
  public static void Main()
  {
    Persona personaUno = new Persona("Croma", "Gainza");
    Console.WriteLine($"{personaUno.GetNombre()} {personaUno.GetApellido()}");

    Visitante visitanteUno = new Visitante("Pepe", "Gainza");
    Console.WriteLine($"{visitanteUno.GetNombre()} {visitanteUno.GetApellido()}");

    Guardia guardiaUno = new Guardia("Juan", "Gainza");
    Console.WriteLine($"{guardiaUno.GetNombre()} {guardiaUno.GetApellido()}");
  }
}