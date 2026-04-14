/*
10. Continuando con el ejemplo anterior, realizar las siguientes modificaciones:
● Agregar en Persona el método presentarse() que devuelva nombre y apellido de la persona.
● Crear una instancia de cada una de las clases y asignarle valores.
● Mostrar por pantalla los valores.
● Sobreescribir el método presentarse() en la clase Guardia de modo tal que devuelva el siguiente mensaje “Hola, mi nombre es <nombre y apellido> y soy el guardia.” Donde <nombre y apellido> debe ser reemplazado por el nombre y apellido del guardia. 4
● Mostrar por pantalla el resultado de invocar el método presentarse() y advertir que la implementación en la clase Guardia tiene precedencia sobre la de su padre.
*/

using System.Security.Cryptography.X509Certificates;

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
  public Visitante(string nombre, string apellido) : base(nombre, apellido)
  {

  }
}

public class Guardia : Persona
{
  public Guardia(string nombre, string apellido) : base(nombre, apellido)
  {
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
    Persona personaUno = new Persona("Croma", "Gainza");
    Console.WriteLine(personaUno.Presentarse());

    Visitante visitanteUno = new Visitante("Pepe", "Gainza");
    Console.WriteLine(visitanteUno.Presentarse());

    Guardia guardiaUno = new Guardia("Juan", "Gainza");
    Console.WriteLine(guardiaUno.Presentarse());
  }
}