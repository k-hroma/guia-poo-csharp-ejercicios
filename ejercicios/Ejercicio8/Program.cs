/*
8. Crear una clase Persona que tenga los atributos privados nombre y apellido, con sus setters y getters.
● Crear una clase llamada Visitante con los mismos atributos.
● Crear una clase Guardia con los mismos atributos.
● Crear una instancia de cada una de las clases y asignarle valores.
● Mostrar por pantalla los valores.
*/

public class Persona
{
  private string nombre;
  private string apellido;

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

public class Visitante
{
  private string nombre;
  private string apellido;

  public Visitante(string nombre, string apellido)
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

public class Guardia
{
  private string nombre;
  private string apellido;

  public Guardia(string nombre, string apellido)
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