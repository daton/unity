using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movimiento : MonoBehaviour
{
    /************************************************************************
     * Este script controla el movimiento por medio del touch sobre la pantalla de nuestro granjero
     * Funcionna tanto en celulares , tablets o navegador web.
     ********************************************************************************* */
    NavMeshAgent agente;
    //Vamos a declarar un vector de posicion en 3D al cual lo vamos a relacionar a el punto donde el nino 
    //o nina toque con su dedito
    Vector3 destino;
    // Declaramos una varable de tipo Animator para invocar la componente Animator de granjero
    Animator animator;

    void Start()
    {
        //Vamos a enlazar la variable "agente" a la componente NavMesh Agent que esta en el inspector del objto granjerita
        agente = GetComponent<NavMeshAgent>();
        //Vamos a invocar igual que el NavMeshAgent, la componente Animator
        animator = GetComponent<Animator>();
    }


    //Este metodo va a encargarse de efectuar las animaciones dependiendo del estado del movimiento
    private void MoverAgente()
    {
       //Este codigo sirve para mover al granjero en la nimacion de caminar cuando se este desplazando
       if(Vector3.Distance(this.gameObject.transform.position, destino) >= 0.4f && agente.velocity.magnitude != 0)
        {
            animator.SetBool("EstaCaminando", true);
        }
        else
        {
            animator.SetBool("EstaCaminando", false);
        }
    }



    // Update is called once per frame
    void Update()
    {

        MoverAgente();
        //Aqui en el update vamos a programar nuestro evento de touch para que se dirija nuestro agente de navegacion
        //hacia el punto donde toque el dedito del nino o nina
        if (Input.GetMouseButtonDown(0))
        {
            //La siguiente clase nos ayuda a proyectar un rayo donde vamos a tocar la pantalla
            RaycastHit hit;
            //Verificamos que el cliqueo del mouse sea correcto
            print("Haz cliqueado la pantalla");

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                //Aqui dentro, si se cumple esta condicion, le vamos a indicar a nuestro agente que se mueva
                //al punto de hit.
                agente.destination = hit.point;
                print("SE VA A MOVER");
                //Asignamos el vector 3d de arriba que le pusimos destino ese valor
                destino = hit.point;
            }
        }
        
    }
}
