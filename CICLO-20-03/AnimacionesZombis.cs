using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimacionesZombis : MonoBehaviour
{

    public Text textoVidas;
    public Text textoDistancia;
    int vidas=0;
    public GameObject yaku;
    

   

    void Start()
    {
        //Aqui inicializamos todo lo que debe aparecer al poner play
        textoVidas.text = "Vidas: " + vidas;
    }

    void Update()
    {

        //Mostramos la distancia entre el zombi y el player
      float distancia=  Vector3.Distance(yaku.transform.position, transform.position);
        //Por el momento mostramos en el score la distancia
        textoDistancia.text = "Dist " + distancia;


        //Vamos a hacer que el zombi yaku nos observe de forma inteligente
        yaku.transform.LookAt(transform.position);

        //La siguiente linea hace que el zombi no siga hacia donde nos movamos
        //Antes de que se mueva ponemos la condicion, aqui vamos a usar 5 metros para mas facil
        if (distancia < 5)
        {
            //Aqui le decimos que se anime con el estado de maqui de correr
            yaku.GetComponent<Animator>().Play("Running");
            yaku.transform.position = Vector3.MoveTowards(yaku.transform.position, transform.position, Time.deltaTime * 2.5f);
        }
        else
        {
            yaku.GetComponent<Animator>().Play("Idle");
        }
        
   
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == yaku)
        {
            print("Te ha alcanzado Yaku");
            SceneManager.LoadScene("Gato", LoadSceneMode.Single);

        }
    }
}
