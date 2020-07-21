using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Esta clase se agrega para poder administrar los cambios de escenas
using UnityEngine.SceneManagement;
using System;

public class AnimacionesZombis : MonoBehaviour
{

    public Text textoVidas;
    public Text textoDistancia;
   
    public GameObject yaku;
    //Aqui vamos a usar nuestro Script de BarraSaludable
    public BarraSaludable barra;

    //Aqui va el numero inicial de vidas vamos a usar porentaje el maximo sera 100%
   public int maximoVidas = 100;


    //Aqui vamos a declarar un objeto de juego que NO ESTARA EN EL ESCENARIO, ya que sera un prefab.
    public GameObject prefabYaku;

    //Aqui vamos a generar un objeto para manipular ese prefab, lo interesante es que
    //este puede ser un ARREGLO DE ZOMBIES, ES DECIR UNA HORDA DE ZOMBI!!
    // NO es necesario que sea publico este objeto porque solo estara en el codigo
    GameObject zombiClonado;

    //Declaramos un atributo publico de tipo AudioSoure para programar nuestro disparo
    public AudioSource fuenteGranada;
    //Se me olvido el audio clip
    public AudioClip granada;

    //Vamos a generar una bandera o estatus de muerte
    bool estaMuerto = false;

    
   //Vamos a implementar aqui un metodo que se va a llamar disparar()
   public void disparar()
    {
        //Aqui mas adelante pondremos el codigo del disparo, por ahora solo lo marcamos.
    }

    void Start()
    {
        //En este juego ocultaremos el puntero del mouse para darle calidad al videojeugo
        //ademas de que nos va a distraer para disparar en primera persona
        Cursor.lockState = CursorLockMode.Locked;
        //Lo ocultamos con la siguiente expresion
        Cursor.visible = false;

        //En esta sección vamos a invocar el maximo numero de vidas que lo pusimos en
        // en el script BarraSaludable
        barra.setMaximoVidas(maximoVidas);

        //Vamos a  probar si se hace bien la clonacion en la localizacion del cubo.
    zombiClonado=    Instantiate(prefabYaku, new Vector3(308, 0.85f, 380.85f), Quaternion.identity);

    }

    void Update()
    {

        //Mostramos la distancia entre el zombi y el player
      float distancia=  Vector3.Distance(yaku.transform.position, transform.position);
        //Por el momento mostramos en el score la distancia
        textoDistancia.text = "Dist " + distancia;


        //Vamos a hacer que el zombi yaku nos observe de forma inteligente
        //Hacemos que el zombi clonado voltee a vernos igual que el yaku original

     


        zombiClonado.transform.LookAt(transform.position);


        //La siguiente linea hace que el zombi no siga hacia donde nos movamos
        //Antes de que se mueva ponemos la condicion, aqui vamos a usar 5 metros para mas facil
        //El zombi clonado siempre nos va a seguir, independientemente de cualquier codigo
        
        
        //  zombiClonado.transform.position = Vector3.MoveTowards(zombiClonado.transform.position, transform.position, Time.deltaTime * 2.5f);

        //Implementamos el dispaaro como entrada del boton izquiedo del Mouse,
        //para indicar cliqueo del boton iquiero se le pone el cero, para el boton derecho es
        //el numero 1
        if (Input.GetMouseButtonDown(0))
        {
            //Generamos el sonido del disparo de la granada
            fuenteGranada.PlayOneShot(granada);
            //Vamos a matar a yaku independenientemte que nos siga o no nos siga
            //Esta es la primer version TIENE MUCHOS DEFECTOS.
           

        }


        if (distancia < 5 && !estaMuerto)
        {
            //Aqui le decimos que se anime con el estado de maqui de correr
            yaku.transform.LookAt(transform.position);
            yaku.GetComponent<Animator>().Play("Running");

            //Agregamos la condicion de la distancia d menos de 1.5 metros
            if(distancia<1.5f && Input.GetMouseButtonDown(0))
            {
                //Si se cumple esta condicion, yaku esta cerca de la granada y debe morir!!!
                estaMuerto = true;
                yaku.GetComponent<Animator>().Play("muerte");
            }
            else
            {
                yaku.transform.position = Vector3.MoveTowards(yaku.transform.position, transform.position, Time.deltaTime * 2.5f);
            }
           
           
        }
        else if (!estaMuerto)
        {
            yaku.GetComponent<Animator>().Play("Idle");
        }
        else
        {
            yaku.GetComponent<Animator>().Play("muerte");
            
        }
        
   
        
    }
    //Vamos a implementar en esta sección un metodo que funciona
    //siempre y cuando hayamos agregado las componentes Colliders a nuestro personajes
    //en este caso al zombi Yaku y al player Ethan
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == yaku)
        {

            maximoVidas = maximoVidas - 5;
            barra.setVidas(maximoVidas);
            //Vamos a decirle que si maximoVidas<=0 nos lleve al GAME_OVER
            if (maximoVidas <= 0)
            {
                SceneManager.LoadScene("Fin", LoadSceneMode.Single);
            }
       
        }
    }
    
}
