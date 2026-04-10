/*
5. Crear una clase Cine que tenga los atributos privados película y horario.
● Crear métodos públicos para la asignación y recuperación de valores.
● Crear una instancia y asignarle valores.
● Mostrar por pantalla los valores.
● Crear una segunda instancia y asignarle valores.
● Mostrar por pantalla los valores.
● Cambiar los valores de la primera instancia.
● Mostrar en pantalla los valores de ambas instancias; concluir que la instrucción new crea objetos distintos.

*/
public class Cine
{
  private string pelicula;
  private int horario;

  public void setPelicula(string pelicula)
  {
    this.pelicula = pelicula;
  }

  public string getPelicula()
  {
    return pelicula;
  }

  public void setHorario(int horario)
  {
    this.horario = horario;
  }

  public int getHorario()
  {
    return horario;
  }

  public string obtenerCartelera()
  {
    return $"{getPelicula()} - {getHorario()} hs";
  }
}

public class Program
{
  public static void Main()
  {
    Cine cine1 = new Cine();

    cine1.setHorario(12);
    cine1.setPelicula("Los 12 monos");

    Console.WriteLine(cine1.obtenerCartelera());

    Cine cine2 = new Cine();
    cine2.setHorario(15);
    cine2.setPelicula("Odisea en el espacio");

    Console.WriteLine(cine2.obtenerCartelera());

    cine1.setHorario(16);
    Console.WriteLine(cine1.obtenerCartelera());


  }
}