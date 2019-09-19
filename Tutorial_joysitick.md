## USO DE JOYSTICK 

Con este tutorial crearemos un personaje en un videojuego y lo haremos mover con el joystick que previamente se descarga una vez comprado.

![](.Tutorial_joysitick_images/183992f0.png)

Este joystick lo adquirimos en la parte de Asset Store, en esta parte podemos adquirir una gran variedad de complementos para la ambientación de videojuego.

![](.Tutorial_joysitick_images/dac6a7d3.png)

Lo primero que haremos será crear un escenario donde integraremos a nuestro personaje, con los movimientos que necesitamos para éste, además que ahi mismo podremos incorporar una gran cantidad de elementos para el ambiente del escenario.

En la parte de Assets, en la carpeta de Scenes ingresamos a ésta y creamos un nuevo proyecto, dentro de la carpeta Scene damos click derecho escogemos Create/scenes y nombramos el nuevo proyecto:

![](.Tutorial_joysitick_images/c147c1fd.png)

Una vez creado el proyecto ingresamos a el, unicamente tenemos dos objetos para trabajar, "Main Camara" y "Directional ligth".

![](.Tutorial_joysitick_images/d4b00c51.png)

Dentro del proyecto nos vamos a GameObject/3d object/Plane , una vez insertado el plano le cambiamos al dimensión del mismo como se muestra en la scale.

![](.Tutorial_joysitick_images/5ff59b0e.png)

Dentro de la carpeta scenes, tenemos al personaje aj@Excited el cual vamos a arrastrar al centro del plano.

![](.Tutorial_joysitick_images/7a1425e2.png)

![](.Tutorial_joysitick_images/bdb8abc2.png)

Una vez que colocamos al personaje en el plano, procedemos a posicionar la cámara en el lugar donde queramos que inicie el video juego, en este caso lo posicionamos viendo la espalda del personaje, nos posicionamos en la parte de "scene" y ahi nos colocamos en "Main Camera", y ahi podemos usar los recursos del menú para mover la camara ya sea alejarla o acercarla.

![](.Tutorial_joysitick_images/969fe4cd.png)

Para alinear la cámara, le damos en la opción GameObjetc y escogemos la opción Align With View, le damos en esa opción y la cámara se queda alinea justo donde queremos que inicie la imagen del videojuego.

![](.Tutorial_joysitick_images/b5f68a1b.png)

Lo ponemos en modo de Game y le damos Play, ahi vemos como iniciará el personaje una vez inicializado el videojuego.

![](.Tutorial_joysitick_images/5d348336.png)

De igual forma colocamos la luz que hará la que indicará la dirección de las sombras o la parte que alumbrará al personaje en forma de "sol", repetriremos los mismos pasos que el anterior, es decir, seleccionamos la opción "Directonal Ligth", nos vamos a GameObject y le damos la opción Align with view.

![](.Tutorial_joysitick_images/4065e1fc.png)

Asi es como se vería la luz una vez que se acomodó la Directional ligth.

![](.Tutorial_joysitick_images/23d5677b.png)

Para visualizarlo en el celular es necesario que se instale la app Unity remote 5, el cual nos ayudará para ver como se verá el videojuego en el mismo. 

Una vez instalado en el celular, procedemos a ligarlo con la computadora, nos vamos a File/ Build settings, selecciono el icono de Android y con ella la opción Switch Platform.

![](.Tutorial_joysitick_images/9a332cad.png)

Posterior a eso seleccionamos la opción Add Open Scenes y nos agregará la que estamos realizando en ese momento

![](.Tutorial_joysitick_images/6eb8da27.png)

Para correrlo en el celular, nos vamos a Edit/Projects settings vamos a la opción Editor, en Device escogemos la opción Any Android Device.

![](.Tutorial_joysitick_images/1620ec99.png)

Abrimos la app del celular Unity Remote 5, nos vamos a la opción de GAME en la computadora y le damos PLAY, lo que ocurrirá es que el videojuego se visualizará en el celular.

![](.Tutorial_joysitick_images/f0fd4f81.png)



