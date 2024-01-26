# ObjectPooling_AtrapaAlTopo
 TopoObjectPool.CS
 
Este código en C# es un script de Unity llamado `TopoObjectPool` que implementa un patrón de objeto de grupo (object pool) para manejar la creación y reutilización de objetos "topo" en el juego, en lugar de crear y destruirlos dinámicamente. La clase define variables públicas para el prefab del topo (`prefabTopo`) y el tamaño de la piscina (`tamanoPiscina`). Además, tiene una lista privada (`piscinaTopos`) para almacenar los objetos "topo" creados. En el método `Awake()`, se inicializa la instancia estática de `TopoObjectPool` y se crea la piscina de objetos "topo". Dentro del bucle `for`, se llama al método `CrearNuevoTopo()` para instanciar los objetos "topo" y agregarlos a la lista `piscinaTopos`, pero inicialmente los desactiva. El método `CrearNuevoTopo()` instancia un nuevo objeto "topo" a partir del prefab y lo desactiva antes de agregarlo a la piscina. El método `ObtenerTopo()` busca en la piscina de objetos "topo" uno que esté desactivado (es decir, no esté en uso) y lo devuelve. Si todos los objetos "topo" están en uso, crea uno nuevo llamando a `CrearNuevoTopo()` y devuelve el último objeto creado. Este patrón de grupo de objetos es útil para optimizar el rendimiento en juegos donde se crean y destruyen muchos objetos repetidamente, ya que evita los costosos procesos de creación y destrucción, en su lugar, se reutilizan objetos ya creados. 
 
 ![image](https://github.com/Ji07y/ObjectPooling_AtrapaAlTopo/assets/85076732/fa921d8b-135d-4b6f-8364-b0594578a30a)

![image](https://github.com/Ji07y/ObjectPooling_AtrapaAlTopo/assets/85076732/f8f4827d-818e-406a-8219-3619f19101dc)


# EscenaJuego.CS

El código es un script de C# para Unity que define una clase llamada `EscenaJuego` que hereda de `MonoBehaviour` y contiene un método público llamado `CambiarAEscena`, el cual carga una escena específica llamada "Juego" utilizando `SceneManager.LoadScene`. 

 ![image](https://github.com/Ji07y/ObjectPooling_AtrapaAlTopo/assets/85076732/5579880a-268a-4b42-991d-4112a8619615)


# GameManager.CS
Este script de C# es un componente de Unity que gestiona la lógica del juego. Comienza definiendo una clase llamada `GameManager`, que implementa un patrón Singleton para garantizar que solo haya una instancia del GameManager en ejecución. Este GameManager administra el puntaje del jugador, el tiempo de juego, y la lógica para mostrar y ocultar "topos" en el juego. El GameManager tiene referencias a varios objetos del juego, como prefabs de "topos" y objetos de texto para mostrar el puntaje y el tiempo. Además, tiene un evento `OnScoreUpdated` que se dispara cuando el puntaje se actualiza. El método `Start()` inicializa el tiempo de juego y llama a `IniciarJuego()`, que inicia un ciclo para mostrar "topos" a intervalos regulares. El método `MostrarTopo()` selecciona un agujero aleatorio para mostrar un "topo", mientras que `OcultarTopoDespuesDeMostrar()` oculta el "topo" después de un breve período de tiempo. El método `Update()` maneja la lógica del tiempo de juego, actualizando la interfaz y cambiando a la escena de "GameOver" cuando se acaba el tiempo. Finalmente, el método `CambiarAEscena()` permite cambiar a una escena específica. 
 
 
 
 ![image](https://github.com/Ji07y/ObjectPooling_AtrapaAlTopo/assets/85076732/4664c669-068f-4407-a6ea-83d442b44639)

 ![image](https://github.com/Ji07y/ObjectPooling_AtrapaAlTopo/assets/85076732/4e8cbe01-08ec-4339-a40e-bcd18bff98c8)
![image](https://github.com/Ji07y/ObjectPooling_AtrapaAlTopo/assets/85076732/fce2d422-6a4c-4c81-8634-0427366438e8)
![image](https://github.com/Ji07y/ObjectPooling_AtrapaAlTopo/assets/85076732/4c61ab1a-f9e7-4955-baa6-5e998bfb42e8)
![image](https://github.com/Ji07y/ObjectPooling_AtrapaAlTopo/assets/85076732/69f12c3c-b2f9-46a1-9b4a-309b4124646b)


# TopoController.CS
Este código en C# es un script de Unity llamado `TopoController` que controla el comportamiento de un objeto "topo" en el juego. La clase define una variable pública `puntos` que indica la cantidad de puntos que el jugador obtiene al golpear este topo.  El método `OnMouseDown()` se ejecuta cuando el jugador hace clic en el topo. Dentro de este método, se verifica si el juego aún no ha terminado (utilizando el método `FinDelJuego()` del GameManager). Si el juego aún está en curso, se incrementa el puntaje del jugador llamando al método `AumentarPuntaje()` del GameManager con la cantidad de puntos definida para este topo. Luego, se llama al método `OcultarTopo()` para ocultar el topo. Los métodos `MostrarTopo()` y `OcultarTopo()` son públicos y se utilizan para mostrar u ocultar el topo activando o desactivando su GameObject asociado.
![image](https://github.com/Ji07y/ObjectPooling_AtrapaAlTopo/assets/85076732/f1c56512-7092-4ee2-9beb-25ca84c0b2f2)

 

