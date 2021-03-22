using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSalud : MonoBehaviour
{
    // Start is called before the first frame update
    BarraSaludable barraSaludable;
    public GameObject objetoBarra;
    int vidas=40;
    Animator animator;
    public static  bool estaVivo;

    void Start()
    {

        estaVivo = true;

            barraSaludable = objetoBarra.GetComponent<BarraSaludable>();
      
            barraSaludable.setMaximoVidas(40);
        animator=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "mazo"&&estaVivo)
        {
            vidas = vidas - 5;
            barraSaludable.setVidas(vidas);
            if (vidas <= 0)
            {
               // animator.SetLayerWeight(1, 1.0f);
              //  animator.SetLayerWeight(0, 0.0f);
                animator.Play("morir");
                //   gameObject.SetActive(false);
                estaVivo = false;
            }
        }
    }
}
