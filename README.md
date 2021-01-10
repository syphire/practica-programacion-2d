# Cómo jugar
El objetivo del juego es alcanzar el gran cofre. Para ello, el jugador tendrá que esquivar los pinchos que hay en el suelo y coger los pequeños cofres para acceder a la sala del tesoro en la que se encuentra el gran cofre.

El jugador contará con 3 corazones de vida que irá perdiendo a medida que pise los _pinchos_ del suelo. Si el jugador consigue acceder a la sala del tesoro sin morir, podrá obtener el gran cofre y terminar la partida. Para ello, el jugador podrá manejar al personaje con las teclas de dirección de su teclado y este se desplazará por el escenario.

El juego se iniciará desde la pantalla de logo de la UOC, y a partir de ahí llegaremos a la pantalla de menú principal donde habrá una serie de botones. Desde ahí podremos iniciar la partida o ver los controles/información del juego, así como salir del mismo.

# Implementación
Tras pensar en diferentes opciones de juego finalmente se optó por desarrollar un juego estilo _Zelda 2D_, concretamente una mazmorra. Aunque las mazmorras de los Zelda son bastante amplias y hay cantidad de objetos y monstruos, debido al tiempo disponible se optó por realizar un juego un poco más simple pero siguiente la estética de la obra de Nintendo.

Para ello, y buscando la máxima similitud para poder desarrollar un _gameplay_ sencillo pero similar, se decidió comprar un par de assets de Unity a través de la Unity Asset Store aprovechando las ofertas disponibles en ese momento y que ofrecían exactamente lo que se quería conseguir. Estos assets son https://assetstore.unity.com/packages/2d/characters/2d-customizable-character-male-101695 para el personaje principal del juego y https://assetstore.unity.com/packages/2d/environments/2d-hand-painted-dungeon-tileset-42935 para el diseño de las mazmorras. Aunque los assets incluyen animaciones y prefabs, únicamente se han utilizado los sprites para pintar los escenarios y se ha optado por desarrollar el resto a mano.

En cuanto a la música, se han escogido varios assets gratuitos de la Unity Asset Store que coincidieran lo máximo posible con el tipo de juego que se deseaba realizar. Finalmente se ha optado por este bundle de sonidos de un juego de fantasía https://assetstore.unity.com/packages/audio/sound-fx/fantasy-sfx-32833. Estos temas suenan cuando el personaje coge un cofre, cae en los pinchos, y también de fondo durante toda la partida o cuando gana/pierde.

A la hora de desarrollar el proyecto se han definido los siguientes _scripts_ donde se pueden encontrar las funciones que controlan la jugabilidad del título:

- _CharacterController.cs_. Implementa los controles del personaje.
- _LogoController.cs_. Implementa las funciones de la pantalla de logo del juego.
- _TitlePageController.cs_. Implementa las funciones de la pantalla de título del juego.
- _MenuPrincipalController.cs_. Implementa las funciones del menú principal del juego.
- _CreditosController.cs_.Implementa las funciones de la pantalla de créditos del juego.
- _GameplayManager.cs_. Implementa las funciones principales del flujo del juego.

En _CharacterController.cs_ se implementa todo lo relacionado al movimiento y colisiones del personaje. Se define el movimiento del protagonista a través de un vector en dos dimensiones y las colisiones contra todos los elementos del escenario. El juego incluye colisiones contra los cofres pequeños, los pinchos que se encuentran desperdigados por el suelo y el gran cofre. Además, también hay una colisión contra el hueco que deja la puerta cuando desaparece que es la que se encarga de indicar el cambio de escena.

En este _script_ también se contempla la vida de nuestro personaje que en un principio consta de tres corazones. Así, cada vez que el personaje pase por encima de los pinchos del suelo perderá un corazón y si el contador de corazones llega a 0 se terminará la partida.

En _LogoController.cs_ se implementa el comportamiento de la escena de Logo, donde únicamente se llama a una corrutina con un _delay_ para pasar a la siguiente escena. Lo mismo ocurre con el resto de _scripts_ asociadas a las escenas de pantallas de inicio/fin de la partida: _TitlePageController.cs_ implementa mediante otra corrutina el comportamiento de la escena de Título, donde al cumplirse el _delay_ redirecciona a la pantalla del menú principal. 

_TitlePageController.cs_ es el _script_ que implementa la escena de juego del menú principal, que está formada por tres botones. Estos tres botones nos permiten iniciar una nueva partida (redirigiendo a la primera escena de juego), ver los controles/información del juego (redirigiendo a una escena con información para el jugador).

También se ha implementado un _CreditosController.cs_ que implementa el comportamiento de la escena de créditos del juego, con una corrutina que tras un _delay_ te lleva al menú principal del título.

Por último, en _GameplayManager.cs_ encontramos el resto de funciones que gestionan el juego. Los textos activos al iniciar el juego, en qué momento suena cada canción o qué se muestra cuando la partida finaliza. Básicamente todas las funciones se encargan de activar/desactivar distintos elementos en función del momento del juego en el que nos encontramos.

Además de estos scripts, hay una serie de objetos de Unity que hay que configurar para el correcto funcionamiento del juego. A través de los assets comentados anteriormente se han pintado los dos escenarios del juego (mediante varios _tilemaps_), con distintos _colliders_ para detectar cuando chocan con el personaje principal. El personaje lleva también un _collider_ para detectar cuando choca con los distintos objetos del escenario.

Para darle mayor realismo al juego, el personaje cuenta con cuatro animaciones para caminar (en los cuatro sentidos), y también otra animación para cuando se abra el gran cofre final. Las animaciones de la caminata del personaje se han definido mediante un _blend tree_ para así controlar con mayor facilidad el movimiento de cada animación según la dirección en la que se mueva el personaje. Así, contamos con animaciones para cuando el personaje está quieto en las distintas direcciones, y otras cuatro animaciones para cuando este se desplaza, controlándolas mediante una variable _booleana_.

Por último, se ha implementado un flujo de juego natural y usable para cualquier jugador. Una vez iniciada la partida con la pantalla de logo, se pasa automáticamente a la pantalla del título del juego y de ahí al menú principal. Una vez se inicia la partida, el jugador irá cogiendo los pequeños cofres hasta que se abra la puerta, la cruzará y llegará a la escena final donde tendrá que coger el cofre grande para finalizar la partida. Se mostrará un mensaje de fin y acto seguido se mostrarán los créditos del juego donde, tras unos segundos, redirigirá de nuevo a la pantalla del menú.

