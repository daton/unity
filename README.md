# unity
Cursito basico de unity

[Descargar de aqui los sistemas de particulas](https://sierra-guadalupe.org/unity/piromaniaco.unitypackage)

## Cinemachine
 
Cinemachine es el director de camaras y permite añadir cámaras virtuales y poder hacer un blending de camaras

![](2019-07-06-17-30-02.png)
Timeline es un secuenciador podemos añadir tracks y en es emismo track tener eventos y alli mismo agregar dichas secuencias de cámaras virtuales y otras animaciones. <br>

Primero debemos de crear un objeto vació que se llame Mis cut scenes del intro. Recetar la componente para que la ponga en ceros. <br>
Después creamos las cámaras virtuales y las agregamos adenrto de ese objeto vacio.<br>
Observa que en cuanto agrega la primer camara virtual tu Main Camera tiene en automatico la propiedad Cinemachine Brain, ya que sera la que maneje todoas las camaras virtuales.<br><br>
Posteriormente debes de posicionarte en la compnente de las CutScenes y en ella vas a agregar un timeline
Cuando lo hagas quitas el animator y en el boton de add le das click y agregas la opcione "Cinemachine timeline".<br><br>
 Ya despues en la timeline le das click y agrega "Add cinemachine shot" y en el slot que aparece en el inspector de propiedades agregas la camara virtual de tu prefernecias, para cada camara repites el procedimiento, aqui es donde puedes hacer un blending para tener un efecto de transicin mas profesional.
 ![](2019-07-06-17-17-05.png)