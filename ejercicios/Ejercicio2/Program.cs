/*
2. Crear una clase Vehiculo que tenga los atributos públicos marca, modelo y un atributo privado patente.
● Crear una instancia y asignarle valores; notar que el atributo privado no está disponible para la asignación de valores.
● Mostrar por pantalla los valores asignados.
*/


using System;

public class Vehiculo
{
  public string marca;
  public string modelo;
  private string patente;

  // Método para asignar la patente (porque es privada)
  public void SetPatente(string patente)
  {
    this.patente = patente;
  }

  // Método para obtener la patente
  public string GetPatente()
  {
    return patente;
  }

  public string MostrarDatos()
  {
    return marca + " " + modelo + " - Patente: " + patente;
  }
}

class Program
{
  static void Main()
  {
    // Crear instancia
    Vehiculo vehiculo1 = new Vehiculo();

    // Asignar valores públicos
    vehiculo1.marca = "Toyota";
    vehiculo1.modelo = "Corolla";

    // vehiculo1.patente = "ABC123"; ❌ ERROR (es privado)

    // Asignar patente mediante método
    vehiculo1.SetPatente("ABC123");

    // Mostrar por pantalla
    Console.WriteLine(vehiculo1.MostrarDatos());
  }
}
