namespace ejercicios.Ejercicio13.Dominio;

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
