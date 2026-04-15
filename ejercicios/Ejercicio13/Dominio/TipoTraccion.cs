namespace ejercicios.Ejercicio13.Dominio;

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
