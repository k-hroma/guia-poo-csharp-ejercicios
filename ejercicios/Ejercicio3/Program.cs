/*
3. Crear una clase Articulo que tenga los atributos privados marca y modelo.
● Crear métodos públicos para la asignación de valores.
● Crear una instancia y asignarle valores.
● Notar que no es posible mostrar los valores por pantalla y analizar el motivo por lo que esto ocurre.
*/

using System.ComponentModel;

public class Articulo
{
  private string marca;
  private int modelo;

  public string MostrarDatos()
  {
    return $"La marca del articulo es:  {marca} y el modelo es: {modelo} ";
  }

}

class Program
{
  static void Main()
  {
    Articulo articulo1 = new Articulo();
    articulo1.marca = "Philips";
    articulo1.modelo = 123;

    Console.WriteLine(articulo1.MostrarDatos());
  }
}

//No se pudo llevar a cabo la compilación. Corrija los errores de compilación y vuelva a ejecutar el proyecto.
//“Se necesitan métodos públicos para poder asignar valores a atributos privados”
