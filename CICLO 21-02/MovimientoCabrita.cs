using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoCabrita : MonoBehaviour
{
    public Transform destino;
    NavMeshAgent agente;
    Animator animator;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void MoverAgente()
    {
        //Este codigo sirve para mover al granjero en la nimacion de caminar cuando se este desplazando
        if (Vector3.Distance(this.gameObject.transform.position, destino.transform.position) >= 0.4f && agente.velocity.magnitude != 0)
        {
            animator.SetBool("EstaCaminando", true);
        }
        else
        {
            animator.SetBool("EstaCaminando", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Llegaste borreguito");
            //Para no encimar a los animalitos
            Vector3 pos = destino.position + new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));
            agente.destination = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoverAgente();
    }
}
