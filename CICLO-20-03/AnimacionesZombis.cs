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
    public bool estaMuerto = false;


    //Aqui vamos a declarar un objeto de juego que NO ESTARA EN EL ESCENARIO, ya que sera un prefab.
    public GameObject prefabYaku;

    //Aqui vamos a generar un objeto para manipular ese prefab, lo interesante es que
    //este puede ser un ARREGLO DE ZOMBIES, ES DECIR UNA HORDA DE ZOMBI!!
    // NO es necesario que sea publico este objeto porque solo estara en el codigo
    GameObject zombiClonado;

    //Fuente disparo
   public AudioSource fuenteDisparo;

    //Clip Disparo
    public AudioClip clipDisparo;
    
   

    void Start()
    {
        //En esta sección vamos a invocar el maximo numero de vidas que lo pusimos en
        // en el script BarraSaludable
        barra.setMaximoVidas(maximoVidas);

        //Vamos a  probar si se hace bien la clonacion en la localizacion del cubo.
    zombiClonado=    Instantiate(prefabYaku, new Vector3(308, 0.85f, 380.85f), Quaternion.identity);

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            print("Disparaste");
           
        
            fuenteDisparo.PlayOneShot(clipDisparo);
        }

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
       // zombiClonado.transform.position = Vector3.MoveTowards(zombiClonado.transform.position, transform.position, Time.deltaTime * 2.5f);


        if (distancia < 5  && !estaMuerto )
        {
            //Aqui le decimos que se anime con el estado de maqui de correr

            yaku.GetComponent<Animator>().Play("Running");
            yaku.transform.LookAt(transform.position);


            //Checamos que la distancia sea poca y si disparamos
            if (distancia < 1.5f && Input.GetMouseButtonDown(0))
            {
         
                estaMuerto = true;
                yaku.GetComponent<Animator>().Play("morir");
            }
            else
            {
                yaku.transform.position = Vector3.MoveTowards(yaku.transform.position, transform.position, Time.deltaTime * 2.5f);
            }

        }
    
        else if(!estaMuerto)
        {
            yaku.GetComponent<Animator>().Play("Idle");
        }
        else
        {
            yaku.GetComponent<Animator>().Play("morir");
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
