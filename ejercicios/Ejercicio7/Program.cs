/*Crear una clase Ninja con las variables privadas arteMarcial, arma, fuerza (entero) y salto (entero).
● Crear setters y getters manualmente.
● Crear una función saltar() que reciba un parámetro multiplicador (entero); imprimir por consola salto x parámetro.
● Crear la función ataque() que imprima por consola el arma que usa el ninja y el arte marcial.
● Crear dos instancias de Ninja, asignar distintos valores para cada uno de los atributos e invocar las funciones saltar() y ataque().
*/

using System.Dynamic;

using System;

public class Ninja
{
  private string arteMarcial;
  private string arma;
  private int fuerza;
  private int salto;

  // Constructor
  public Ninja(string arteMarcial, string arma, int fuerza, int salto)
  {
    this.arteMarcial = arteMarcial;
    this.arma = arma;
    this.fuerza = fuerza;
    this.salto = salto;
  }

  // Getters y Setters
  public void SetArteMarcial(string arteMarcial)
  {
    this.arteMarcial = arteMarcial;
  }

  public string GetArteMarcial()
  {
    return arteMarcial;
  }

  public void SetArma(string arma)
  {
    this.arma = arma;
  }

  public string GetArma()
  {
    return arma;
  }

  public void SetFuerza(int fuerza)
  {
    this.fuerza = fuerza;
  }

  public int GetFuerza()
  {
    return fuerza;
  }

  public void SetSalto(int salto)
  {
    this.salto = salto;
  }

  public int GetSalto()
  {
    return salto;
  }

  // Métodos
  public void Saltar(int multiplicar)
  {
    Console.WriteLine(salto * multiplicar);
  }

  public void Ataque()
  {
    Console.WriteLine($"{arma} - {arteMarcial}");
  }

  public void MostrarFuerza()
  {
    Console.WriteLine($"Fuerza: {fuerza}");
  }
}

public class Program
{
  public static void Main()
  {
    Ninja ninjaUno = new Ninja("Ninjutsu", "katana", 10, 2);
    ninjaUno.Saltar(3);
    ninjaUno.Ataque();
    ninjaUno.MostrarFuerza();

    Ninja ninjaDos = new Ninja("Karate", "espada", 8, 3);
    ninjaDos.Saltar(4);
    ninjaDos.Ataque();
    ninjaDos.MostrarFuerza();
  }
}