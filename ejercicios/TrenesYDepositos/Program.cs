/*
Ejercicio – trenes y depósitos
Una administradora ferroviaria necesita una aplicación que le ayude a manejar las formaciones
que tiene disponibles en distintos depósitos.
Una formación es lo que habitualmente llamamos “un tren”, tiene una o varias locomotoras, y
uno o varios vagones. Hay vagones de pasajeros y vagones de carga.
En cada depósito hay: formaciones ya armadas, y locomotoras sueltas que pueden ser
agregadas a una formación.
De cada vagón de pasajeros se conoce el largo en metros, y el ancho útil también en metros.
La cantidad de pasajeros que puede transportar un vagón de pasajeros es:
Si el ancho útil es de hasta 2.5 metros: metros de largo * 8.
Si el ancho útil es de más de 2.5 metros: metros de largo * 10.
Por ejemplo, si tenemos dos vagones de pasajeros, los dos de 10 metros de largo, uno de 2
metros de ancho útil, y otro de 3 metros de ancho útil, entonces el primero puede llevar 80
pasajeros, y el segundo puede llevar 100.
Un vagón de pasajeros no puede llevar carga.
De cada vagón de carga se conoce la carga máxima que puede llevar, en kilos. Un vagón de
carga no puede llevar ningún pasajero.
No hay vagones mixtos.
El peso máximo de un vagón, medido en kilos, se calcula así:
Para un vagón de pasajeros: cantidad de pasajeros que puede llevar * 80.
Para un vagón de carga: la carga máxima que puede llevar + 160 (en cada vagón de carga
van dos guardas).
De cada locomotora se sabe: su peso, el peso máximo que puede arrastrar, y su velocidad
máxima. Por ejemplo, puedo tener una locomotora que pesa 1000 kg, puede arrastrar hasta
12000 kg, y su velocidad máxima es de 80 km/h. Obviamente se tiene que arrastrar a ella
misma, entonces no le puedo cargar 12000 kg de vagones, solamente 11000; diremos que este
es su “arrastre útil”.
Una locomotora puede ser agregada a una formación sólo si la formación se encuentra en el
depósito detenida o en depósito. Si la formación ya está en movimiento no se debe hacer nada.
Tener en cuenta que:
El peso útil de la locomotora a agregar debe ser mayor o igual a los kilos de empuje que le
faltan a la formación.
En caso de que no existan locomotoras disponibles se debe arrojar un error.
Generar el diagrama de clases y código que permita saber:
1. El total de pasajeros que puede transportar una formación
2. Cuántos vagones livianos tiene una formación; un vagón es liviano si su peso máximo es
menor a 2500 kg
3. La velocidad máxima de una formación, que es el mínimo entre las velocidades máximas
de las locomotoras.
4. Si una formación es eficiente; es eficiente si cada una de sus locomotoras arrastra, al
menos, 5 veces su peso (el de la locomotora misma).
5. Si una formación puede moverse. Una formación puede moverse si el arrastre útil total de
las locomotoras es mayor o igual al peso máximo total de los vagones.
6. Cuántos kilos de empuje le faltan a una formación para poder moverse, que es: 0 si ya se
puede mover, y (peso máximo total de los vagones – arrastre útil total de las locomotoras)
en caso contrario.
7. Dado un depósito, el conjunto formado por el vagón más pesado de cada formación; se
espera un conjunto de vagones.
8. Si un depósito necesita un conductor experimentado. Un depósito necesita un conductor
experimentado si alguna de sus formaciones es compleja. Una formación es compleja si:
tiene más de 20 unidades (sumando locomotoras y vagones), o el peso total (sumando
locomotoras y vagones) es de más de 10000 kg.
9. Agregar una locomotora a una formación. Evaluar distintos escenarios.
*/


using System.Reflection;
using System.Runtime.Intrinsics.X86;

public class Tren
{
  private bool enMovimiento;
  public bool EnMovimiento
  {
    get { return enMovimiento; }
    set { enMovimiento = value; }
  }

  private List<Locomotora> locomotoras = new List<Locomotora>();
  public List<Locomotora> Locomotoras
  {
    get { return locomotoras; }
  }

  private List<Vagon> vagones = new List<Vagon>();
  public List<Vagon> Vagones
  {
    get { return vagones; }
  }

  public int CalcularTotalPasajeros()
  {
    int total = 0;

    foreach (Vagon v in vagones)
    {
      if (v is VagonPasajeros vp)
      {
        total += vp.CantidadPasajeros();
      }
    }

    return total;
  }

  public int CantidadVagonesLivianos()
  {
    int total = 0;

    foreach (Vagon v in vagones)
    {
      if (v.PesoMaximo() < 2500)
      {
        total++;
      }
    }

    return total;
  }

  public double VelocidadMaximaFormacion()
  {
    if (locomotoras.Count == 0)
    {
      return 0;
    }

    double velocidadMinima = locomotoras[0].Velocidad;

    for (int i = 1; i < locomotoras.Count; i++)
    {
      if (locomotoras[i].Velocidad < velocidadMinima)
      {
        velocidadMinima = locomotoras[i].Velocidad;
      }
    }
    return velocidadMinima;

  }
  public bool EsEficiente()
  {
    foreach (Locomotora loc in locomotoras)
    {
      if (loc.ArrastreUtil() < 5 * loc.PesoLocomotora)
      {
        return false;
      }
    }

    return true;
  }

  public double CalcularPesoTotalVagones()
  {
    double totalPesoMax = 0;
    foreach (Vagon v in vagones)
    {
      totalPesoMax += v.PesoMaximo();
    }
    return totalPesoMax;
  }

  public double CalcularPesoTotalLocomotoras()
  {
    double pesoTotal = 0;
    foreach (Locomotora loc in locomotoras)
    {
      pesoTotal += loc.PesoLocomotora;
    }
    return pesoTotal;
  }
  public double CalcularArrastreUtilTotal()
  {
    double totalArrastreUtil = 0;
    foreach (Locomotora loc in locomotoras)
    {
      totalArrastreUtil += loc.ArrastreUtil();
    }
    return totalArrastreUtil;
  }
  public bool PuedeMoverse()
  {
    if (locomotoras.Count == 0)
      return false;

    if (CalcularArrastreUtilTotal() < CalcularPesoTotalVagones())
    {
      return false;
    }
    else
    {
      return true;
    }

  }
  public double KilosDeEmpujeFaltantes()
  {
    if (PuedeMoverse())
    {
      return 0;
    }
    else
    {
      return CalcularPesoTotalVagones() - CalcularArrastreUtilTotal();
    }

  }

  public Vagon VagonMasPesado()
  {
    if (vagones.Count == 0)
      return null;

    Vagon vagonMasPesado = vagones[0];

    for (int i = 1; i < vagones.Count; i++)
    {
      if (vagones[i].PesoMaximo() > vagonMasPesado.PesoMaximo())
      {
        vagonMasPesado = vagones[i];
      }
    }
    return vagonMasPesado;
  }

  public int CantidadUnidades()
  {
    return vagones.Count + locomotoras.Count;
  }

  public bool EsCompleja()
  {
    if (CantidadUnidades() > 20)
    {
      return true;
    }
    else if (CalcularPesoTotalVagones() + CalcularPesoTotalLocomotoras() > 10000)
    {
      return true;
    }
    return false;
  }
}

public abstract class Vagon
{
  public abstract double PesoMaximo();
}

public class Locomotora
{
  private double pesoLocomotora;
  public double PesoLocomotora
  {
    get { return pesoLocomotora; }
    set { pesoLocomotora = value; }
  }

  private double pesoMaximoArrastre;
  public double PesoMaximoArrastre
  {
    get { return pesoMaximoArrastre; }
    set { pesoMaximoArrastre = value; }
  }

  private double velocidad;
  public double Velocidad
  {
    get { return velocidad; }
    set { velocidad = value; }
  }

  public Locomotora(double pesoLocomotora, double pesoMaximoArrastre, double velocidad)
  {
    this.PesoLocomotora = pesoLocomotora;
    this.PesoMaximoArrastre = pesoMaximoArrastre;
    this.Velocidad = velocidad;
  }

  public double ArrastreUtil()
  {
    return this.PesoMaximoArrastre - this.PesoLocomotora;
  }
}

public class VagonPasajeros : Vagon
{
  private double ancho;
  public double Ancho
  {
    get { return ancho; }
    set { ancho = value; }
  }

  private double largo;
  public double Largo
  {
    get { return largo; }
    set { largo = value; }
  }

  public VagonPasajeros(double largo, double ancho)
  {
    Largo = largo;
    Ancho = ancho;
  }

  public int CantidadPasajeros()
  {
    if (this.Ancho <= 2.5)
      return (int)(this.Largo * 8);
    else
      return (int)(this.Largo * 10);
  }

  public override double PesoMaximo()
  {
    return CantidadPasajeros() * 80;
  }
}

public class VagonCarga : Vagon
{
  private double cargaMaxima;
  public double CargaMaxima
  {
    get { return cargaMaxima; }
    set { cargaMaxima = value; }
  }

  public VagonCarga(double cargaMaxima)
  {
    CargaMaxima = cargaMaxima;
  }

  public override double PesoMaximo()
  {
    return this.cargaMaxima + 160;
  }
}

public class Deposito
{
  private List<Locomotora> locomotoras = new List<Locomotora>();
  public List<Locomotora> Locomotoras
  {
    get { return locomotoras; }
  }

  private List<Tren> trenes = new List<Tren>();
  public List<Tren> Trenes
  {
    get { return trenes; }
  }

  public List<Vagon> VagonesMasPesadosEnDeposito()
  {
    List<Vagon> vagonesPesados = new List<Vagon>();

    foreach (Tren tren in trenes)
    {
      Vagon vagonMasPesado = tren.VagonMasPesado();

      if (vagonMasPesado != null)
      {
        vagonesPesados.Add(vagonMasPesado);
      }
    }
    return vagonesPesados;
  }

  public bool ConductorExperimentado()
  {
    foreach (Tren tren in trenes)
    {
      if (tren.EsCompleja())
      {
        return true;
      }
    }
    return false;
  }

  public void AgregarLocomotoraAFormacion(Tren tren)
  {
    // 1. No hay locomotoras en el depósito → ERROR
    if (locomotoras.Count == 0)
      throw new Exception("No hay locomotoras disponibles en el depósito");

    // 2. El tren está en movimiento → NO HACER NADA
    if (tren.EnMovimiento)
    {
      Console.WriteLine("El tren está en movimiento, no se pueden agregar locomotoras");
      return;
    }

    // 3. Calcular cuánto empuje falta
    double faltante = tren.KilosDeEmpujeFaltantes();

    // 4. Buscar locomotora que alcance
    Locomotora seleccionada = null;

    foreach (Locomotora loc in locomotoras)
    {
      if (loc.ArrastreUtil() >= faltante)
      {
        seleccionada = loc;
        break;
      }
    }

    // 5. Si se encontró → agregar
    if (seleccionada != null)
    {
      tren.Locomotoras.Add(seleccionada);
      locomotoras.Remove(seleccionada);

      Console.WriteLine($"Locomotora agregada correctamente. Arrastre útil: {seleccionada.ArrastreUtil()} kg");
    }
    else
    {
      // 6. Hay locomotoras pero ninguna alcanza
      Console.WriteLine($"No hay locomotoras suficientes. Faltan {faltante} kg de empuje.");
    }
  }

}

public class Program
{
  public static void Main()
  {
    VagonPasajeros vagonPasajerosUno = new VagonPasajeros(10, 3);
    VagonPasajeros vagonPasajerosDos = new VagonPasajeros(10, 2);

    VagonCarga vagonCargaUno = new VagonCarga(1000);
    VagonCarga vagonCargaDos = new VagonCarga(3000);
    VagonCarga vagonCargaTres = new VagonCarga(9000);

    Locomotora locomotoraUno = new Locomotora(1000, 12000, 300);
    Locomotora locomotoraDos = new Locomotora(1000, 12000, 200);
    Locomotora locomotoraTres = new Locomotora(1000, 12000, 100);
    Locomotora locomotoraCuatro = new Locomotora(1200, 5000, 400);

    Tren formacionUno = new Tren();
    formacionUno.Vagones.Add(vagonPasajerosUno);
    formacionUno.Vagones.Add(vagonPasajerosDos);

    Tren formacionDos = new Tren();
    formacionDos.Vagones.Add(vagonPasajerosUno);
    formacionDos.Vagones.Add(vagonPasajerosDos);
    formacionDos.Vagones.Add(vagonCargaUno);
    formacionDos.Vagones.Add(vagonCargaDos);
    formacionDos.Locomotoras.Add(locomotoraUno);
    formacionDos.Locomotoras.Add(locomotoraDos);
    formacionDos.Locomotoras.Add(locomotoraTres);

    Tren formacionTres = new Tren();
    formacionTres.Locomotoras.Add(locomotoraUno);
    formacionTres.Vagones.Add(vagonCargaUno);
    formacionTres.Vagones.Add(vagonCargaDos);
    formacionTres.Vagones.Add(vagonPasajerosUno);


    Tren formacionUnoEnDeposito = new Tren();
    Tren formacionDosEnDeposito = new Tren();
    Tren formacionTresEnDeposito = new Tren();
    Tren formacionCuatroEnDeposito = new Tren();

    formacionUnoEnDeposito.Vagones.Add(vagonCargaUno);
    formacionUnoEnDeposito.Vagones.Add(vagonPasajerosDos);
    formacionUnoEnDeposito.Locomotoras.Add(locomotoraUno);

    formacionDosEnDeposito.Vagones.Add(vagonCargaDos);
    formacionDosEnDeposito.Vagones.Add(vagonPasajerosUno);

    formacionTresEnDeposito.Locomotoras.Add(locomotoraUno);
    formacionTresEnDeposito.Vagones.Add(vagonCargaUno);
    formacionTresEnDeposito.Vagones.Add(vagonCargaDos);
    formacionTresEnDeposito.Vagones.Add(vagonPasajerosUno);
    formacionTresEnDeposito.EnMovimiento = true;

    formacionCuatroEnDeposito.Locomotoras.Add(locomotoraCuatro);
    formacionCuatroEnDeposito.Vagones.Add(vagonCargaTres);

    Deposito depositoUno = new Deposito();
    Deposito depositoDos = new Deposito();
    Deposito depositoTres = new Deposito();
    depositoUno.Trenes.Add(formacionUnoEnDeposito);
    depositoUno.Trenes.Add(formacionDosEnDeposito);
    depositoUno.Trenes.Add(formacionTresEnDeposito);
    depositoDos.Locomotoras.Add(locomotoraCuatro);
    depositoTres.Locomotoras.Add(locomotoraUno);
    depositoTres.Locomotoras.Add(locomotoraCuatro);

    //0. Pasajeros por vagón
    Console.WriteLine("Pasajeros por vagón:");
    Console.WriteLine($"Vagón 1: {vagonPasajerosUno.CantidadPasajeros()} pasajeros");
    Console.WriteLine($"Vagón 2: {vagonPasajerosDos.CantidadPasajeros()} pasajeros");

    //1. El total de pasajeros que puede transportar una formación
    Console.WriteLine();
    Console.WriteLine($"Total de pasajeros en la formación: {formacionUno.CalcularTotalPasajeros()}");

    //2. Cuántos vagones livianos tiene una formación; un vagón es liviano si su peso máximo es menor a 2500 kg
    Console.WriteLine();
    Console.WriteLine($"En la formacion hay {formacionDos.CantidadVagonesLivianos()} vagones livianos.");

    // 3 La velocidad máxima de una formación, que es el mínimo entre las velocidades máximas de las locomotoras.
    Console.WriteLine();
    Console.WriteLine($"La velocidad máxima de la formación {formacionDos.VelocidadMaximaFormacion()} km/h.");

    // 4 - Si una formación es eficiente; es eficiente si cada una de sus locomotoras arrastra, al menos, 5 veces su peso (el de la locomotora misma).
    Console.WriteLine();

    if (formacionDos.EsEficiente())
    {
      Console.WriteLine("La formacion es eficiente");
    }
    else
    {
      Console.WriteLine("La formacion no es eficiente");
    }

    //5 - Si una formación puede moverse. Una formación puede moverse si el arrastre útil total de las locomotoras es mayor o igual al peso máximo total de los vagones.
    Console.WriteLine();

    if (formacionDos.PuedeMoverse())
    {
      Console.WriteLine("La formacion puede moverse");
    }
    else
    {
      Console.WriteLine("La formacion no puede moverse");
    }

    //6 - Cuántos kilos de empuje le faltan a una formación para poder moverse, que es: 0 si ya se puede mover, y (peso máximo total de los vagones – arrastre útil total de las locomotoras) en caso contrario
    Console.WriteLine();
    if (formacionTres.PuedeMoverse())
    {
      Console.WriteLine("La formacion puede moverse");
    }
    else
    {
      Console.WriteLine($"La formacion no puede moverse y le faltan {formacionTres.KilosDeEmpujeFaltantes()} kilos de empuje");
    }

    //7-Dado un depósito, el conjunto formado por el vagón más pesado de cada formación; se espera un conjunto de vagones.
    Console.WriteLine();
    List<Vagon> resultado = depositoUno.VagonesMasPesadosEnDeposito();
    foreach (Vagon v in resultado)
    {
      if (v is VagonPasajeros vp)
      {
        Console.WriteLine($"Vagón de pasajeros - Peso: {vp.PesoMaximo()}");
      }
      else if (v is VagonCarga vc)
      {
        Console.WriteLine($"Vagón de carga - Peso: {vc.PesoMaximo()}");
      }
    }

    // 8-Si un depósito necesita un conductor experimentado. Un depósito necesita un conductor experimentado si alguna de sus formaciones es compleja. Una formación es compleja si: tiene más de 20 unidades (sumando locomotoras y vagones), o el peso total (sumando locomotoras y vagones) es de más de 10000 kg.

    Console.WriteLine();
    if (depositoUno.ConductorExperimentado())
    {
      Console.WriteLine("Se necesita un conductor experimentado");
    }
    else
    {
      Console.WriteLine("No se necesita un conductor experimentado");
    }

    //9-Agregar una locomotora a una formación. Evaluar distintos escenarios.
    Console.WriteLine();
    depositoDos.AgregarLocomotoraAFormacion(formacionTresEnDeposito); // El tren está en movimiento, no se pueden agregar locomotoras
    Console.WriteLine();
    depositoTres.AgregarLocomotoraAFormacion(formacionCuatroEnDeposito); //Locomotora agregada a la formacion, ya no se encuentra disponible en deposito.
    Console.WriteLine();
    depositoUno.AgregarLocomotoraAFormacion(formacionTresEnDeposito); //Unhandled exception. System.Exception: No hay locomotoras disponibles en el deposito

  }

}

