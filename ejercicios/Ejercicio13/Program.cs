/*
13. El laboratorio Kokumo Technologies está desarrollando el prototipo de un robot explorador cuyo sistema de tracción puede ser personalizado para que se adapte mejor al terreno.
El robot, llamado KT-2020, tiene las siguientes características:
● Número de serie: KT-2020-P
● Potencia de tracción base (PTB): 10 hp
● Tracción: cualquiera de las dos opciones desarrolladas.
Los sistemas de tracción disponibles son:
● Rueda de caucho: ideal para entornos urbanos, su uso le resta 1 hp al PTB y permite el rodado de hasta 100 km; cuando se gasta, debe reemplazarse.
● Oruga: para todo tipo de terreno, le permite avanzar hasta 400 km antes de requerir reemplazo y resta 3 hp al PTB. Incorpora sensores Meke-M0 que le permiten conocer la temperatura.
Analizar, diseñar, diagramar las relaciones e implementar el código.
Crear instancias de cada una de las clases y asignarle al robot los distintos sistemas de tracción, procurando mostrar por pantalla los siguientes datos entre las distintas asignaciones: Número de serie, potencia de tracción final, tipo de tracción, cuanto puede avanzar y datos sobre cualquier característica adicional que posea.
*/


public class Robot
{

  private string _numSerie;
  public string NumSerie
  {
    get { return _numSerie; }
    set { _numSerie = value; }
  }

  private int _potencia;
  public int Potencia
  {
    get { return _potencia; }
    set { _potencia = value; }
  }

  private TipoTraccion _tipoDeTraccion;
  public TipoTraccion TipoDeTraccion
  {
    get { return _tipoDeTraccion; }
    set { _tipoDeTraccion = value; }
  }

  public Robot(string numSerie, int potencia, TipoTraccion tipoDetraccion)
  {
    this._numSerie = numSerie;
    this._potencia = potencia;
    this._tipoDeTraccion = tipoDetraccion;
  }
  public int CalcularPotenciaFinal()
  {
    return _potencia - _tipoDeTraccion.DesgastePorUso;
  }

  public void Recorrer(int distancia)
  {
    if (distancia <= TipoDeTraccion.Autonomia)
    {
      Console.WriteLine("El robot pudo recorrer la distancia");
    }
    else
    {
      Console.WriteLine("La tracción se agotó, necesita reemplazo");
    }
  }

  public void MostrarRobot()
  {
    Console.WriteLine(
      $"Numero de serie: {this._numSerie}\n" +
      $"Potencia Final: {CalcularPotenciaFinal()}\n" +
      $"TipoDeTraccion: {TipoDeTraccion.GetType().Name}\n" +
      $"Autonomia: {this._tipoDeTraccion.Autonomia}\n" +
      $"Desgaste: {this._tipoDeTraccion.DesgastePorUso}"
    );
  }
}

public abstract class TipoTraccion
{
  // atributos privados
  private int _desgastePorUso;
  private int _autonomia;

  // prop con el getter publico para acceso y sin setter porque es valor fijo
  public int DesgastePorUso
  {
    get { return _desgastePorUso; }
  }

  public int Autonomia
  {
    get { return _autonomia; }
  }

  // constructor de clase
  protected TipoTraccion(int desgaste, int autonomia)
  {
    _desgastePorUso = desgaste;
    _autonomia = autonomia;
  }
}

public class Oruga : TipoTraccion
{
  private string _sensor;

  public string Sensor
  {
    get { return _sensor; }
  }

  public Oruga() : base(3, 400)
  {
    _sensor = "MEKE M0";
  }
}

public class RuedaCaucho : TipoTraccion
{
  public RuedaCaucho() : base(1, 100)
  {

  }
}

public class Program
{
  public static void Main()
  {
    Oruga oruga = new Oruga();
    RuedaCaucho rueda = new RuedaCaucho();

    Robot robotin = new Robot("KT-2020-P", 10, oruga);
    Robot robotina = new Robot("KT-2020-P", 10, rueda);

    robotin.MostrarRobot();
    Console.WriteLine("-----------------------------------------------");
    robotin.Recorrer(50);
    robotin.MostrarRobot();
    Console.WriteLine("-----------------------------------------------");

    robotina.MostrarRobot();
    Console.WriteLine("-----------------------------------------------");
    robotina.Recorrer(150);
    robotina.MostrarRobot();


  }
}