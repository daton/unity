using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Orco : MonoBehaviour
{
    //Declaramos una variable  para acceder con codigo al agente de navegacion que agregamos previamente
    NavMeshAgent agente;
    //DEclaramos una variable publica, que sera el player, pues lo tendra que seguir para matarlo!
    public GameObject player;
    Animator animator;
    public GameObject casa;
    public GameObject textoGameOver;
    
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        textoGameOver.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Aqui vamos a indicar que el agente se dirija  a nuestro player!!

   
     
            agente.SetDestination(player.transform.position);
        float distancia = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
     


            if (distancia > 2.0f )
            {
                animator.SetBool("EstaCorriendo", true);
                animator.SetBool("EstaAtacando", false);
              
              
             }

            
           if(distancia<=2)
            {
        
                if (PlayerSalud.estaVivo)
                {
                    animator.SetBool("EstaAtacando", true);
                   
                }
                else
                {
                    animator.SetBool("YaGano", true);
                    print("Ya esta muerto");
                textoGameOver.SetActive(true);
                }
      
        }
        
       
    }
}
