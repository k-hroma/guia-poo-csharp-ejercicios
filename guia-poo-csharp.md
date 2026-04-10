# Guía de Programación Orientada a Objetos en C#

> _"La esencia del modelado es la abstracción."_ — Grady Booch

---

## ¿Qué es un Paradigma?

Antes de hablar de objetos y clases, necesitamos entender qué es un **paradigma de programación**.

Un paradigma es una **visión de la computación**: una forma arbitraria de definir qué es el software y cómo construirlo. Adoptar un paradigma te da un marco conceptual para entender lo que estás haciendo mientras desarrollás, ayudándote a tomar mejores decisiones de diseño.

La **Programación Orientada a Objetos (POO)** es un paradigma que permite abordar problemas modelando la solución a través de entidades llamadas **objetos**, que interactúan entre sí. El objetivo no es usarla por moda, sino construir software que cumpla cualidades como:

- **Escalabilidad**: que pueda crecer en carga y funcionalidad.
- **Robustez**: que no se rompa fácilmente ante situaciones inesperadas.
- **Mantenibilidad**: que sea fácil de modificar y corregir.
- **Legibilidad**: que otros (y vos mismo en el futuro) puedan entender el código.

---

## Los Tres Conceptos Fundamentales

Toda aplicación orientada a objetos se construye sobre tres conceptos básicos:

### 1. Objeto

> **Definición:** Un objeto es un **ente computacional que exhibe comportamiento**. Vive dentro del software y puede (o no) representar algo del mundo real.

Dos palabras clave de esta definición:

- **Comportamiento**: las cosas que el objeto _sabe hacer_.
- **Exhibe**: ese comportamiento es accesible _desde afuera_ del objeto, es decir, otros objetos pueden pedírselo.

### 2. Mensaje

En una aplicación orientada a objetos, los objetos no trabajan solos: se piden cosas entre sí a través de **mensajes**.

> **Definición:** Un mensaje es la **comunicación entre dos objetos**, un emisor (E) y un receptor (R). E le pide algo a R, y R puede o no devolver una respuesta.

Cuando un objeto recibe un mensaje que entiende, ejecuta el código asociado (su **método**). Si no lo entiende, ocurre un error.

### 3. Ambiente

> **Definición:** El ambiente es el **lugar donde viven los objetos**. Crear un objeto significa agregarlo al ambiente; destruirlo significa sacarlo.

---

## Software: Juntando Todo

Con estos tres conceptos podemos definir qué es el software desde la perspectiva de la POO:

> **El software es el resultado de la interacción de un conjunto de objetos que viven en un ambiente y que se comunican entre sí enviándose mensajes.**

Al diseñar software orientado a objetos, debemos definir:

- Qué objetos va a tener la aplicación.
- Qué mensajes va a entender cada objeto.
- Cuáles son los patrones de interacción entre ellos.
- Cómo se van a conocer entre sí.

---

## Clase y Objeto: La Diferencia Fundamental

Una confusión muy común al empezar es usar "clase" y "objeto" como sinónimos. Son cosas distintas:

| Concepto               | ¿Qué es?                                        | Analogía             |
| ---------------------- | ----------------------------------------------- | -------------------- |
| **Clase**              | La especificación, el molde                     | El plano de una casa |
| **Objeto / Instancia** | Un espacio en memoria RAM con valores concretos | La casa construida   |

> **Clase:** Es el molde a partir del cual se crean los objetos. Generaliza el comportamiento y los datos comunes, y define qué características tendrá cada nuevo objeto creado a partir de ella.

> **Objeto:** Es una **instancia** de una clase. Cuando creás un objeto, el sistema reserva espacio en la memoria RAM para alojar sus valores. De una misma clase podés crear tantos objetos como necesites.

**Ejemplo concreto:** Si definís la clase `Puerta` con atributos como `altura`, `ancho`, `color` y `material`, podés crear una puerta de madera marrón de 2 metros y también una puerta de metal gris de 1.8 metros. Ambas son instancias de la misma clase, pero con valores distintos.

---

## Cuerpo de una Clase

Una clase tiene los siguientes elementos:

- **Nombre**: identifica a la clase de forma única dentro del proyecto.
- **Atributos**: variables que guardan el estado o características del objeto.
- **Métodos / Funciones**: bloques de instrucciones que definen el comportamiento.
- **Constructor**: método especial que se ejecuta al crear un objeto.
- **Nivel de visibilidad**: controla quién puede acceder a cada miembro.

A los atributos y métodos juntos se los llama **miembros** de la clase.

---

## Visibilidad: ¿Quién puede ver qué?

Para que los objetos puedan interactuar entre sí, necesitamos controlar qué partes de una clase son accesibles desde afuera. Esto se logra con los **modificadores de visibilidad**:

| Modificador         | Clase propia | Mismo paquete | Subclases | Cualquier clase |
| ------------------- | ------------ | ------------- | --------- | --------------- |
| `private`           | ✅           | ❌            | ❌        | ❌              |
| _(sin modificador)_ | ✅           | ✅            | ❌        | ❌              |
| `protected`         | ✅           | ✅            | ✅        | ❌              |
| `public`            | ✅           | ✅            | ✅        | ✅              |

**Regla práctica:** Por convención, los **atributos deben ser privados** y accederse a través de métodos públicos llamados _getters_ y _setters_. Esto se llama **encapsulación**.

---

## Encapsulación

> **Definición:** La encapsulación es el principio que establece que los datos internos de un objeto deben estar protegidos, y que solo se accede a ellos a través de métodos específicos.

¿Por qué es importante? Porque te permite:

- Controlar exactamente cómo se leen o modifican los datos.
- Hacer que un atributo sea solo de lectura (solo getter), solo de escritura (solo setter), o ambos.
- Mantener la integridad de los datos.

**Getters y Setters** son métodos públicos que permiten leer o asignar el valor de un atributo privado, respectivamente.

---

## Constructor

> **Definición:** El constructor es el método que se invoca automáticamente cuando se crea un objeto con `new`. Su firma se distingue porque **no declara tipo de retorno**.

El constructor es el lugar ideal para inicializaciones obligatorias. Si no necesitás hacer nada especial al crear el objeto, podés omitirlo (el compilador asume uno vacío implícitamente). Pero si definís al menos un constructor personalizado, el constructor vacío ya no está disponible automáticamente y debés agregarlo vos si lo necesitás.

---

## Ejemplo Completo de una Clase

Veamos cómo se ve todo esto junto en C#:

```csharp
public class Persona
{
    // Atributos privados (encapsulados)
    private string nombre;
    private string apellido;

    // Constructor sin parámetros
    public Persona()
    {
        this.nombre = "Juan";
        this.apellido = "Pérez";
    }

    // Constructor con parámetros
    public Persona(string nombre, string apellido)
    {
        this.nombre = nombre;
        this.apellido = apellido;
    }

    // Getter de nombre
    public string GetNombre()
    {
        return nombre;
    }

    // Setter de nombre
    public void SetNombre(string nombre)
    {
        this.nombre = nombre;
    }

    // Getter de apellido
    public string GetApellido()
    {
        return apellido;
    }

    // Setter de apellido
    public void SetApellido(string apellido)
    {
        this.apellido = apellido;
    }

    // Método público
    public void Saludar()
    {
        Console.WriteLine($"Hola, mi nombre es {GetNombreCompleto()}");
    }

    // Método privado (solo accesible dentro de la clase)
    private string GetNombreCompleto()
    {
        return $"{GetNombre()} {GetApellido()}";
    }
}
```

### La palabra `this`

`this` es una autorreferencia a la instancia actual del objeto. Se usa principalmente cuando el nombre de un parámetro coincide con el nombre de un atributo, para que el compilador sepa cuál es cuál:

```csharp
public void SetNombre(string nombre)
{
    this.nombre = nombre; // "this.nombre" es el atributo; "nombre" es el parámetro
}
```

---

## Creación de Objetos

Para crear un objeto se usa la palabra reservada `new`, seguida del nombre de la clase y sus parámetros (si el constructor los requiere). El resultado se guarda en una variable del mismo tipo:

```csharp
// Usando el constructor sin parámetros
Persona persona1 = new Persona();

// Usando el constructor con parámetros
Persona persona2 = new Persona("Ana", "García");

// Llamando a un método del objeto
persona2.Saludar(); // Output: Hola, mi nombre es Ana García
```

El acceso a los miembros públicos se hace con un punto (`.`).

---

## Namespaces: Organización del Código

En C#, las clases se organizan en **namespaces** (espacios de nombre), que son contenedores lógicos que agrupan clases bajo un criterio común. Sirven para evitar conflictos de nombres y mantener el código ordenado.

```csharp
using System; // Importa el namespace System

namespace MiAplicacion
{
    public class Persona
    {
        // ...
    }
}
```

Cuando necesitás usar una clase de otro namespace, la importás con `using`:

```csharp
using MiAplicacion; // Ahora podés usar la clase Persona directamente
```

---

## Sobrecarga (Overloading)

> **Definición:** La sobrecarga es la capacidad de definir **múltiples métodos con el mismo nombre** dentro de una clase, siempre que difieran en la cantidad, tipo u orden de sus parámetros.

Esto permite usar un único nombre para operaciones similares que reciben distintos inputs. El compilador determina cuál versión ejecutar según los argumentos que recibe.

```csharp
public class InfoPersona
{
    // Versión 1: nombre y apellido
    public static string Concatenar(string nombre, string apellido)
    {
        return $"{nombre} {apellido}";
    }

    // Versión 2: nombre, segundo nombre y apellido
    public static string Concatenar(string nombre, string segundoNombre, string apellido)
    {
        return $"{nombre} {segundoNombre} {apellido}";
    }

    // Versión 3: nombre, apellido y edad
    public static string Concatenar(string nombre, string apellido, int edad)
    {
        return $"{nombre} {apellido}, {edad} años";
    }
}
```

```csharp
// El compilador elige la versión correcta automáticamente
Console.WriteLine(InfoPersona.Concatenar("Juan", "Pérez"));           // Versión 1
Console.WriteLine(InfoPersona.Concatenar("Juan", "Carlos", "Pérez")); // Versión 2
Console.WriteLine(InfoPersona.Concatenar("Juan", "Pérez", 30));       // Versión 3
```

> ⚠️ **Importante:** Dos métodos con el mismo nombre y los mismos tipos de parámetros (aunque tengan distinto nombre de parámetro) **no pueden coexistir** en la misma clase. El compilador no distingue por nombre de parámetro, solo por tipo.

---

## Herencia

> **Definición:** La herencia es la característica que permite crear una nueva clase (subclase o clase derivada) basándose en una clase existente (superclase o clase base). La subclase **hereda todos los miembros públicos y protegidos** de su clase base, como si fueran propios.

La herencia permite reutilizar código y organizar las entidades en jerarquías. En C#, se indica con los dos puntos (`:`):

```csharp
public class Empleado : Persona   // Empleado hereda de Persona
{
    public int Legajo { get; set; }
    public string Carrera { get; set; }
    // Empleado ya tiene nombre y apellido heredados de Persona
}

public class EmpleadoProveedor : Persona
{
    public int CodigoPermiso { get; set; }
    public int CodigoEmpresa { get; set; }
}
```

> ⚠️ **C# solo permite herencia simple**: una clase solo puede heredar de una sola clase base (aunque puede implementar múltiples interfaces, como veremos más adelante).

La premisa para usar herencia es la relación **"es un"**: un `Empleado` _es una_ `Persona`, por lo que tiene sentido que herede de ella.

---

## Upcasting y Downcasting

La herencia habilita el uso de **casting** entre tipos relacionados.

### Upcasting

Tratar un objeto de una subclase como si fuera de su clase base. Al hacer upcasting, **se pierde acceso a los miembros específicos de la subclase**.

```csharp
// Upcasting implícito: un Empleado es asignado a una variable de tipo Persona
Persona empleado = new Empleado();

// Upcasting explícito
Empleado emp = new Empleado();
Persona persona = (Persona)emp;
```

### Downcasting

Volver a tratar un objeto como su tipo original (más específico). Solo funciona si el objeto fue creado originalmente como ese tipo específico.

```csharp
Persona empleadoComoPersona = new Empleado(); // upcasting
Empleado empleado = (Empleado)empleadoComoPersona; // downcasting válido
```

> 💡 **¿Para qué sirve el upcasting?** Permite tratar objetos de distintos tipos de forma genérica. Por ejemplo, podés tener una lista de `Persona` que contenga tanto `Empleado` como `EmpleadoProveedor`, y operar sobre todos ellos con el mismo código.

---

## Sobreescritura (Overriding)

> **Definición:** La sobreescritura es la práctica mediante la cual una subclase **redefine un método heredado** de su clase base, manteniendo la misma firma pero cambiando la implementación.

El resultado es que ante el mismo mensaje, objetos de distintas clases reaccionan de manera diferente. En C#, el método de la clase base debe marcarse como `virtual`, y la subclase usa `override`:

```csharp
public class Persona
{
    public virtual void Saludar()
    {
        Console.WriteLine("Hola, soy una persona");
    }
}

public class Empleado : Persona
{
    public int Legajo { get; set; }

    public override void Saludar()
    {
        Console.WriteLine($"Hola, soy un empleado con legajo {Legajo}");
    }
}

public class EmpleadoProveedor : Persona
{
    public int CodigoEmpresa { get; set; }

    public override void Saludar()
    {
        Console.WriteLine($"Hola, soy proveedor de la empresa {CodigoEmpresa}");
    }
}
```

### Las tres razones para sobreescribir

**1. Reemplazar el comportamiento completamente** (no se usa `base`):

```csharp
public override void Saludar()
{
    Console.WriteLine("Soy empleado");  // Comportamiento totalmente nuevo
}
```

**2. Extender el comportamiento** (reutilizar lo del padre y agregar algo):

```csharp
public override void Saludar()
{
    base.Saludar();                          // Ejecuta el método del padre
    Console.WriteLine("...y soy empleado"); // Y agrega algo más
}
```

**3. En constructores** (cuando el padre tiene constructor con parámetros, la subclase debe llamarlo con `base`):

```csharp
public class Persona
{
    public string Nombre;
    public string Apellido;

    public Persona(string nombre, string apellido)
    {
        Nombre = nombre;
        Apellido = apellido;
    }
}

public class Empleado : Persona
{
    public int Legajo;

    public Empleado(string nombre, string apellido, int legajo)
        : base(nombre, apellido)  // Llama al constructor del padre PRIMERO
    {
        Legajo = legajo;  // Luego inicializa lo propio
    }
}
```

> ⚠️ **Importante:** Cuando el padre tiene al menos un constructor personalizado, la subclase **está obligada** a llamar a alguno de esos constructores usando `base(...)`.

---

## Clase Abstracta

> **Definición:** Una clase abstracta es una clase que **no puede ser instanciada directamente**. Su propósito es servir de base para subclases, concentrando características comunes pero dejando algunos comportamientos sin definir (métodos abstractos) para que cada subclase los implemente a su manera.

Se usa cuando existe una entidad que tiene sentido conceptualmente pero no tiene suficiente identidad propia como para ser instanciada. Por ejemplo, `Vehiculo` como clase base para `Auto`, `Camion` y `Moto`.

```csharp
public abstract class Vehiculo
{
    // Método abstracto: declarado pero sin implementación
    // Cada subclase DEBE implementarlo
    public abstract bool EncenderMotor();
    public abstract bool ApagarMotor();
}

public class Auto : Vehiculo
{
    public override bool EncenderMotor()
    {
        Console.WriteLine("Encendiendo el motor del auto...");
        return true;
    }

    public override bool ApagarMotor()
    {
        Console.WriteLine("Apagando el motor del auto...");
        return true;
    }
}
```

```csharp
// Vehiculo vehiculo = new Vehiculo(); ❌ ERROR: no se puede instanciar una clase abstracta
Auto auto = new Auto();             // ✅ Correcto
auto.EncenderMotor();
```

> 💡 **La utilidad** de las clases abstractas está en el código que _usa_ sus características abstractas, no en las características en sí mismas. Al declarar el método `EncenderMotor()` en `Vehiculo`, podés escribir código que funcione con cualquier vehículo sin saber de qué tipo específico es.

---

## Interfaces

> **Definición:** Una interfaz define un **contrato de comportamiento**: especifica las firmas de los métodos que una clase _debe_ implementar cuando decide adherirse a ella. No tiene implementación propia, solo declaraciones.

Una interfaz es similar a una clase abstracta donde todos los métodos son abstractos, pero con diferencias importantes:

- Las clases pueden implementar **múltiples interfaces** (algo que no se puede hacer con la herencia de clases en C#).
- Las interfaces no forman parte de la jerarquía de herencia de clases.

```csharp
public interface IEncendible
{
    bool Encender();
    bool Apagar();
}
```

```csharp
// Una clase puede implementar múltiples interfaces separadas por comas
public class AireAcondicionado : IEncendible
{
    public bool Encender()
    {
        Console.WriteLine("Encendiendo el aire acondicionado...");
        return true;
    }

    public bool Apagar()
    {
        Console.WriteLine("Apagando el aire acondicionado...");
        return true;
    }
}

public class Motor : IEncendible
{
    public bool Encender()
    {
        Console.WriteLine("Encendiendo el motor...");
        return true;
    }

    public bool Apagar()
    {
        Console.WriteLine("Apagando el motor...");
        return true;
    }
}
```

### ¿Qué ganamos con las interfaces?

Las interfaces **desacoplan el polimorfismo de la jerarquía de herencia**. Sin interfaces, para aprovechar el polimorfismo necesitás que los objetos desciendan de una misma clase base. Con interfaces, cualquier clase puede "comprometerse" a comportarse de cierta manera, sin importar de dónde hereda.

> 💡 **Buena práctica:** "Programar pensando en interfaces" significa escribir código que dependa de comportamientos (interfaces) y no de tipos concretos. Esto hace que tu código sea más flexible: si mañana cambiás la implementación concreta por otra que cumpla la misma interfaz, el resto del código no necesita modificarse.

---

## Polimorfismo

> **Definición:** El polimorfismo es la capacidad que tienen los objetos de **reaccionar de diferentes maneras ante el mismo mensaje**, como resultado de implementar comportamientos distintos en métodos que comparten la misma firma.

El polimorfismo es una consecuencia natural de combinar herencia, sobreescritura e interfaces. Se puede lograr de tres maneras:

**1. Por sobreescritura** (dentro de una misma jerarquía):

```csharp
// Todos son Persona, pero cada uno saluda diferente
Persona p1 = new Persona();
Persona p2 = new Empleado();
Persona p3 = new EmpleadoProveedor();

p1.Saludar(); // "Hola, soy una persona"
p2.Saludar(); // "Hola, soy un empleado con legajo..."
p3.Saludar(); // "Hola, soy proveedor de la empresa..."
```

**2. Por interfaces** (objetos de distinta naturaleza, mismo contrato):

```csharp
// Aunque son clases muy distintas, ambas implementan IEncendible
IEncendible[] dispositivos = { new Motor(), new AireAcondicionado() };

foreach (var d in dispositivos)
{
    d.Encender(); // Cada uno ejecuta su propia versión
}
```

**3. Por composición** (un objeto cambia de comportamiento en tiempo de ejecución según los objetos que lo componen).

---

## Composición y Agregación

> **Definición general:** La composición es la relación de dependencia donde un objeto (el compuesto) contiene referencias a otros objetos (los componentes) como parte de sí mismo.

Hay dos variantes:

- **Composición fuerte**: el objeto principal **no puede existir** sin el componente. Ejemplo: un auto sin motor no puede funcionar.
- **Agregación (composición débil)**: el objeto principal **no requiere** necesariamente del componente. Ejemplo: un auto sin aire acondicionado aún puede funcionar.

```csharp
public abstract class Vehiculo
{
    private Motor motor;                   // Composición fuerte: esencial
    private AireAcondicionado airAc;       // Agregación: opcional

    protected Vehiculo(Motor motor, AireAcondicionado airAc)
    {
        this.motor = motor;
        this.airAc = airAc;
    }

    public bool EncenderMotor()
    {
        return motor.Encender();    // Delega al componente
    }

    public bool EncenderAire()
    {
        return airAc.Encender();    // Delega al componente
    }
}
```

> 💡 La composición permite **cambiar el comportamiento en tiempo de ejecución** reasignando los componentes, lo cual es una forma poderosa de polimorfismo.

---

## Bases de la POO: Los Cuatro Pilares

| Pilar              | Definición                                                                         |
| ------------------ | ---------------------------------------------------------------------------------- |
| **Abstracción**    | Extraer las características esenciales de algo, ignorando los detalles superfluos. |
| **Encapsulación**  | Ocultar los detalles internos de implementación, exponiendo solo lo necesario.     |
| **Modularización** | Descomponer el sistema en piezas independientes y cohesivas con bajo acoplamiento. |
| **Jerarquización** | Organizar las entidades en niveles de responsabilidad o composición.               |

---

## Principios SOLID

Los principios SOLID son una guía para escribir código orientado a objetos de calidad:

| Letra | Principio                 | Qué dice                                                                        |
| ----- | ------------------------- | ------------------------------------------------------------------------------- |
| **S** | Responsabilidad única     | Cada clase debe tener una sola razón para cambiar.                              |
| **O** | Abierto/Cerrado           | Las clases deben estar abiertas para extenderse pero cerradas para modificarse. |
| **L** | Sustitución de Liskov     | Si B hereda de A, debería poder usarse B donde se usa A sin problemas.          |
| **I** | Segregación de interfaces | No obligar a una clase a implementar métodos que no usa.                        |
| **D** | Inversión de dependencias | Depender de abstracciones, no de implementaciones concretas.                    |

---

## Diagrama de Clases UML

El **diagrama de clases** es una herramienta visual para modelar las relaciones entre clases. En UML, cada clase se representa con un rectángulo de tres secciones:

```
+------------------+
|     NombreClase  |  ← Nombre
+------------------+
| - atributo: Tipo |  ← Atributos (- privado, + público, # protegido)
+------------------+
| + metodo(): void |  ← Operaciones
+------------------+
```

### Relaciones entre clases

| Relación                                | Símbolo                       | Significado                          |
| --------------------------------------- | ----------------------------- | ------------------------------------ |
| **Hereda**                              | Flecha sólida con triángulo   | Una clase extiende a otra            |
| **Implementa**                          | Flecha punteada con triángulo | Una clase implementa una interfaz    |
| **Asociación (Conoce)**                 | Línea sólida                  | Un objeto almacena referencia a otro |
| **Dependencia (Usa)**                   | Flecha punteada               | Relación débil, temporal             |
| **Composición/Agregación (Todo-Parte)** | Rombo en el extremo del todo  | Un objeto es parte de otro           |

> 💡 **El modelo no es la realidad.** El objetivo no es reflejar la realidad tal cual, sino construir una **simplificación útil** que resuelva el problema específico que tenemos.

---

## Colecciones

Las colecciones son objetos que agrupan elementos del mismo tipo y ofrecen operaciones para trabajar con ellos. A diferencia de los arrays (tamaño fijo), las colecciones se **autodimensionan**.

En C#, las principales colecciones están en el namespace `System.Collections.Generic`:

### List — Lista dinámica

```csharp
using System.Collections.Generic;

List<int> numeros = new List<int>();

numeros.Add(1);          // Agregar al final
numeros.Add(10);
numeros.Add(5);

numeros.RemoveAt(1);     // Eliminar por índice (elimina el 10)

foreach (int n in numeros)
{
    Console.WriteLine(n); // Output: 1, 5
}
```

### Dictionary — Clave-Valor

Permite almacenar pares clave-valor donde **cada clave es única**.

```csharp
Dictionary<string, int> agenda = new Dictionary<string, int>();

agenda["Juan"] = 1234;
agenda["Ana"] = 5678;

Console.WriteLine(agenda["Ana"]);               // 5678
Console.WriteLine(agenda.ContainsKey("Juan"));  // True

agenda.Remove("Juan");

foreach (var kvp in agenda)
{
    Console.WriteLine($"Nombre: {kvp.Key}, Tel: {kvp.Value}");
}
```

### HashSet — Conjunto sin Duplicados

Garantiza que **no haya elementos repetidos**.

```csharp
HashSet<int> unicos = new HashSet<int>();

unicos.Add(1234);
unicos.Add(5678);
unicos.Add(1234); // ← Ignorado, ya existe

Console.WriteLine(unicos.Contains(5678)); // True
unicos.Remove(5678);
```

> ⚠️ Para usar `HashSet` con objetos propios (clases que definiste vos), necesitás redefinir `Equals()` y `GetHashCode()` para que el conjunto pueda determinar correctamente cuándo dos objetos son iguales:

```csharp
public class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is Persona otra)
            return Nombre == otra.Nombre && Edad == otra.Edad;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Nombre, Edad);
    }
}
```

---

## La Palabra `static`

> **Definición:** Un miembro `static` pertenece a la **clase** en sí misma, no a cada objeto. Existe una sola copia en memoria y es compartida por todas las instancias.

Un miembro **no estático** (de instancia) requiere que exista un objeto para ser accedido. Uno **estático** puede usarse directamente desde la clase.

```csharp
class Persona
{
    public static int ContadorPersonas = 0;  // Compartido por todos
    public int Edad;                          // Cada objeto tiene el suyo

    public void MetodoNormal()
    {
        ContadorPersonas++;  // ✅ Un método normal puede acceder a miembros static
        Edad = 25;           // ✅ También puede acceder a miembros de instancia
    }

    public static void MetodoEstatico()
    {
        ContadorPersonas++;  // ✅ Un método static puede acceder a otros static
        // Edad = 25;        // ❌ ERROR: no puede acceder a miembros de instancia
                             //    (¿de cuál objeto sería "Edad"? No hay objeto.)
    }
}

// Se puede llamar sin crear ningún objeto:
Persona.MetodoEstatico();
```

### Constantes con `static readonly`

Combinando `static` y `readonly` se crea una constante de clase: un valor que existe una sola vez en memoria y no puede modificarse.

```csharp
public class Modem
{
    public static readonly int BAUD_RATE_9600 = 9600;
    public static readonly int BAUD_RATE_115200 = 115200;
}

// Uso:
Console.WriteLine(Modem.BAUD_RATE_9600);    // 9600
Console.WriteLine(Modem.BAUD_RATE_115200);  // 115200
```

---

## Enumerados (Enum)

Los enumerados son tipos especiales que agrupan un conjunto fijo de valores con nombre. Son más formales y seguros que usar números mágicos o strings sueltos.

```csharp
enum DiaDeSemana
{
    Lunes,
    Martes,
    Miercoles,
    Jueves,
    Viernes,
    Sabado,
    Domingo
}
```

```csharp
DiaDeSemana hoy = DiaDeSemana.Lunes;

switch (hoy)
{
    case DiaDeSemana.Lunes:
        Console.WriteLine("Comienzo de semana 💪");
        break;
    case DiaDeSemana.Viernes:
        Console.WriteLine("¡Por fin viernes!");
        break;
    case DiaDeSemana.Sabado:
    case DiaDeSemana.Domingo:
        Console.WriteLine("Fin de semana 🎉");
        break;
    default:
        Console.WriteLine("Día de semana");
        break;
}
```

> Los enums no pueden extenderse ni modificarse una vez definidos, lo que los hace perfectos para representar conjuntos de valores fijos como estados, categorías, días, etc.

---

## Errores y Excepciones

En el desarrollo, hay tres tipos de fallas:

| Tipo                         | Cuándo ocurre          | Cómo se detecta                                  |
| ---------------------------- | ---------------------- | ------------------------------------------------ |
| **Sintácticos y semánticos** | Al escribir el código  | El IDE o el compilador los señala en tiempo real |
| **De lógica**                | En tiempo de ejecución | Solo aparecen cuando el programa corre           |
| **Eventos externos**         | En tiempo de ejecución | Conexión caída, archivo no encontrado, etc.      |

> **Definición de Excepción:** Una excepción ocurre cuando el flujo normal del programa es alterado por un evento no contemplado, resultando en la terminación inmediata si no se maneja adecuadamente.

---

## Control de Excepciones: try / catch / finally

Para manejar excepciones se usa el bloque `try/catch/finally`:

```csharp
try
{
    // Código que podría fallar
    string nombre = empleado.GetNombre();
    return nombre;
}
catch (NullReferenceException ex)
{
    // Se ejecuta SOLO si ocurre una NullReferenceException
    Console.Error.WriteLine($"El empleado era null: {ex.Message}");
    return "N/A";
}
catch (Exception ex)
{
    // Captura cualquier otra excepción (siempre va ÚLTIMA, de más específica a más genérica)
    Console.Error.WriteLine($"Error inesperado: {ex.Message}");
    return "N/A";
}
finally
{
    // Se ejecuta SIEMPRE, haya o no excepción (ideal para cerrar conexiones, liberar recursos)
    Console.WriteLine("El bloque finally siempre se ejecuta.");
}
```

> ⚠️ **Regla importante:** Declarar los `catch` de **más específico a más genérico**. Si ponés `Exception` primero, los otros `catch` nunca se alcanzarán.

---

## Excepciones Personalizadas

Podés crear tus propios tipos de excepción extendiendo la clase base `Exception`:

```csharp
public class EmpleadoException : Exception
{
    public EmpleadoException(string mensaje) : base(mensaje)
    {
    }
}

public class EmpleadoAtributoException : Exception
{
    public EmpleadoAtributoException(string mensaje) : base(mensaje)
    {
    }
}
```

```csharp
public class GestorPersonas
{
    public string ObtenerApellido(Empleado empleado)
    {
        if (empleado == null)
            throw new EmpleadoException("El empleado es null.");

        if (string.IsNullOrWhiteSpace(empleado.GetApellido()))
            throw new EmpleadoAtributoException("El apellido está vacío.");

        return empleado.GetApellido();
    }
}
```

```csharp
// Capturando excepciones personalizadas
try
{
    GestorPersonas gestor = new GestorPersonas();
    string apellido = gestor.ObtenerApellido(null);
    Console.WriteLine(apellido);
}
catch (EmpleadoException ex)
{
    Console.Error.WriteLine($"Error de empleado: {ex.Message}");
}
catch (EmpleadoAtributoException ex)
{
    Console.Error.WriteLine($"Error de atributo: {ex.Message}");
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Error inesperado: {ex.Message}");
}
```

---

## Resumen Visual de Conceptos Clave

```
PARADIGMA POO
│
├── Conceptos base
│   ├── Objeto ──────── Ente computacional que exhibe comportamiento
│   ├── Mensaje ─────── Comunicación entre objetos (emisor → receptor)
│   └── Ambiente ────── Donde viven los objetos
│
├── Estructura de Clase
│   ├── Atributos (privados por convención)
│   ├── Métodos (getters, setters, comportamiento)
│   ├── Constructor (se ejecuta al crear con "new")
│   └── Visibilidad (private / protected / public)
│
├── Mecanismos
│   ├── Encapsulación ──── Proteger datos con setters/getters
│   ├── Herencia ──────── Reutilizar y extender clases existentes
│   ├── Sobrecarga ─────── Mismo nombre, distintos parámetros
│   ├── Sobreescritura ─── Redefinir comportamiento heredado (virtual + override)
│   ├── Composición ────── Un objeto contiene a otro
│   └── Polimorfismo ───── Mismo mensaje, distintas reacciones
│
├── Tipos especiales
│   ├── Clase abstracta ── No instanciable, puede tener métodos abstractos
│   ├── Interfaz ────────── Solo firmas de métodos (contrato)
│   ├── static ──────────── Miembro de clase (compartido, sin objeto)
│   ├── readonly ─────────── No modificable
│   └── enum ────────────── Conjunto de valores fijos
│
└── Colecciones
    ├── List<T> ──────── Lista dinámica ordenada
    ├── Dictionary<K,V> ─ Clave-valor sin claves duplicadas
    └── HashSet<T> ─────── Sin elementos duplicados
```

---

_Guía elaborada para la Unidad Temática N°1 — Programación II, TSSI._
