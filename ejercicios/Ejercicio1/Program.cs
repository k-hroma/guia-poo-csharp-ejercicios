
/*1. Crear una clase Persona que tenga los atributos públicos nombre y apellido.
● Crear una instancia y asignarle valores.
● Mostrar por pantalla los valores asignados.
*/

using System;

public class Persona
{
  public string nombre;
  public string apellido;

  public string MostrarNombreApellido()
  {
    return nombre + " " + apellido;
  }
}

class Program
{
  static void Main()
  {
    // Crear instancia
    Persona persona1 = new Persona();

    // Asignar valores
    persona1.nombre = "Croma";
    persona1.apellido = "Gainza";

    // Mostrar por pantalla
    Console.WriteLine(persona1.MostrarNombreApellido());
  }
}
