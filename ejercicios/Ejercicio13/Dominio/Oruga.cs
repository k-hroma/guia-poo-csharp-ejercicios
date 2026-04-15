namespace ejercicios.Ejercicio13.Dominio;

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
