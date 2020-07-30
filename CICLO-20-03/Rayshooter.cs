using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables; 

public class Rayshooter : MonoBehaviour
{
    public AudioSource audioDisparo;
    public AudioClip clipDisparo;
    PlayableDirector playable;
    Camera camara;
    public GameObject prefab;       
    public GameObject cubo;
    public GameObject prefab2;
    public GameObject punta;

    void Start()
    {
        playable = GetComponent<PlayableDirector>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camara = GetComponent<Camera>();

    }

    private IEnumerator disparar()
    {
        Instantiate<GameObject>(prefab2, punta.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2);
    }

    // Update is called once per frame
    void Update()
    {
        //Programamos el disparo con el mouse izquierdo, como con la granada
        if (Input.GetMouseButtonDown(0))
        {
            audioDisparo.PlayOneShot(clipDisparo);
            StartCoroutine(disparar());
            //Invocamos la animacion de nuestro timeline
            playable.Play();
            Vector3 p1 = new Vector3(camara.pixelWidth /2, camara.pixelHeight / 2, 0);

            RaycastHit golpe;
            Ray rayo = camara.ScreenPointToRay(p1);
            if (Physics.Raycast(rayo,out golpe))
            {
                print("Disparaste");
              //  Instantiate<GameObject>(prefab, golpe.point, Quaternion.identity);
        
                Vector3 vec =cubo.transform.position-transform.position;
            
                if (golpe.transform.gameObject.tag == "cubo")
                {
                    print("Le diste al cubo");
                    Rigidbody rb = golpe.transform.gameObject.GetComponent<Rigidbody>();
                    rb.AddForce(vec.normalized*500);
                }
              
            }
        }
    }
}
