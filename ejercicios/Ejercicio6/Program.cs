/*
6. Crear una clase Fruta con variables privadas color, peso, esEstacional.
● Crear setters y getters.
● Escribir una función llamada esComestible() que devuelva verdadero cuando la fruta pesa menos de 200 gr y es de estación, y falso en cualquier otro caso.
● Definir dos constructores de modo tal que la fruta pueda crearse con los valores color, peso y estacional al momento de instanciarse, o bien crearse sin valores iniciales.

*/

using System;

public class Fruta
{
  private string color;
  private int peso;
  private bool esEstacional;

  // Constructor vacío
  public Fruta()
  {
  }

  // Constructor con parámetros
  public Fruta(string color, int peso, bool esEstacional)
  {
    this.color = color;
    this.peso = peso;
    this.esEstacional = esEstacional;
  }

  // Setters
  public void SetColor(string color)
  {
    this.color = color;
  }

  public void SetPeso(int peso)
  {
    this.peso = peso;
  }

  public void SetEsEstacional(bool esEstacional)
  {
    this.esEstacional = esEstacional;
  }

  // Getters
  public string GetColor()
  {
    return color;
  }

  public int GetPeso()
  {
    return peso;
  }

  public bool GetEsEstacional()
  {
    return esEstacional;
  }

  // Método lógico
  public bool EsComestible()
  {
    return peso < 200 && esEstacional;
  }
}

public class Program
{
  public static void Main()
  {
    // ✔ Usando constructor vacío + setters
    Fruta fruta1 = new Fruta();
    fruta1.SetColor("Rojo");
    fruta1.SetPeso(150);
    fruta1.SetEsEstacional(true);

    Console.WriteLine("Fruta 1:");
    Console.WriteLine($"Color: {fruta1.GetColor()}");
    Console.WriteLine($"Peso: {fruta1.GetPeso()} gr");
    Console.WriteLine($"Es estacional: {fruta1.GetEsEstacional()}");
    Console.WriteLine($"¿Es comestible?: {fruta1.EsComestible()}");

    Console.WriteLine();

    // ✔ Usando constructor con parámetros
    Fruta fruta2 = new Fruta("Verde", 250, false);

    Console.WriteLine("Fruta 2:");
    Console.WriteLine($"Color: {fruta2.GetColor()}");
    Console.WriteLine($"Peso: {fruta2.GetPeso()} gr");
    Console.WriteLine($"Es estacional: {fruta2.GetEsEstacional()}");
    Console.WriteLine($"¿Es comestible?: {fruta2.EsComestible()}");
  }
}
