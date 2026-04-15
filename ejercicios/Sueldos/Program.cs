/*
Una empresa desea crear un programa para calcular el sueldo de sus empleados. La fórmula
para calcular el sueldo de un empleado es la siguiente:
sueldo = neto + bonopresentismo + bonoresultado
Los empleados pueden categorizarse en:
Gerente. Sueldo neto 100000
Administrativo. Sueldo neto 40000
Operador. Sueldo neto 10500
Cadete. Sueldo neto 1000

Existen 2 bonos por presentismo.
1-El bono A asigna:
$1000 si el empleado no faltó nunca.
$450 si el empleado faltó 1 única vez
$0 en cualquier otro caso.

2-El bono B siempre suma $500.

El bono por resultados ofrece 3 posibilidades:
10% sobre el sueldo neto en caso de objetivo cumplido
$800 fijos en caso de cumplir el 80& del objetivo
$0 (cero pesos) en cualquier otro caso.

Desarrolle una aplicación que permita calcular el sueldo de un empleado. Pruebe distintos
escenarios.
*/


using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

public abstract class Empleado
{
  private int inasistencias;
  public int Inasistencias
  {
    get { return inasistencias; }
    set { inasistencias = value; }
  }
  private int objetivoCumplido;
  public int ObjetivoCumplido
  {
    get { return objetivoCumplido; }
    set { objetivoCumplido = value; }
  }

  private BonoPresentismo bonoPresentismo;
  public BonoPresentismo BonoPresentismo
  {
    get { return bonoPresentismo; }
    set { bonoPresentismo = value; }
  }
  private BonoResultado bonoResultado;
  public BonoResultado BonoResultado
  {
    get { return bonoResultado; }
    set { bonoResultado = value; }
  }

  // Constructor
  public Empleado()
  {
    bonoPresentismo = new BonoA(); // porDefault
    bonoResultado = new BonoResultado();
  }
  // Métodos

  public abstract int CalcularNeto();
  public virtual int CalcularSueldo()
  {
    return this.CalcularNeto() + this.BonoPresentismo.Calcular(this.Inasistencias) + this.BonoResultado.Calcular(this.ObjetivoCumplido, this.CalcularNeto());
  }

}

public abstract class BonoPresentismo
{
  public abstract int Calcular(int inasistencias);
}

public class BonoA : BonoPresentismo
{
  public override int Calcular(int inasistencias)
  {
    if (inasistencias == 0)
    {
      return 1000;
    }
    else if (inasistencias == 1)
    {
      return 450;
    }
    else
    {
      return 0;
    }
  }
}

public class BonoB : BonoPresentismo
{
  public override int Calcular(int inasistencias)
  {
    return 500;
  }
}


public class BonoResultado
{
  public int Calcular(int objetivoCumplido, int neto)
  {
    if (objetivoCumplido == 100)
    {
      return (int)(neto * 0.1);
    }
    else if (objetivoCumplido >= 80)
    {
      return 800;
    }
    else
    {
      return 0;
    }
  }
}

public class Gerente : Empleado
{
  public override int CalcularNeto()
  {
    return 10000;
  }

}

public class Program
{
  public static void Main()
  {
    BonoPresentismo bonoA = new BonoA();
    BonoPresentismo bonoB = new BonoB();
    BonoResultado bonoResultado = new BonoResultado();

    Empleado empleado = new Gerente();
    empleado.BonoPresentismo = bonoA;
    empleado.BonoResultado = bonoResultado;
    empleado.Inasistencias = 1;
    empleado.ObjetivoCumplido = 100;

    Console.WriteLine($"El {empleado.GetType().Name} tiene un sueldo de ${empleado.CalcularSueldo()}");

    Console.WriteLine("----------------------");

    empleado.BonoPresentismo = bonoB;

    Console.WriteLine($"El {empleado.GetType().Name} tiene un sueldo de ${empleado.CalcularSueldo()}");
  }
}