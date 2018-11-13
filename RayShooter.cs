using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
    public AudioSource fuenteDisparo;
    public AudioClip clipDisparo;
    Camera camara;
    public ParticleSystem chispas;
    public ParticleSystem humito;
    int zombiDisparos = 0;
 public    GameObject yaku;

	// Use this for initialization
	void Start () {
        camara = GetComponent<Camera>();
        //Las siguientes lineas ocultan el cursor p flecha del mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

	}
	
	// Update is called once per frame
	void Update () {


        if (zombiDisparos < 3)
        {
            Vector3 pos = new Vector3(transform.position.x,
                yaku.transform.position.y, transform.position.z);

            yaku.transform.LookAt(pos);
            //Vamos a hacer que nos siga hasta el final
            yaku.transform.Translate(0, 0, Time.deltaTime * 1);
        }

        if (Input.GetMouseButtonDown(0))
        {
            print("DISPARASTE!!");
            fuenteDisparo.PlayOneShot(clipDisparo);
            //Ubicamos el punto P1
            Vector3 p1 = 
          new Vector3(camara.pixelWidth / 2, camara.pixelHeight / 2,0);

            //Generamos el rayo que sale del punto P1
            Ray rayo = camara.ScreenPointToRay(p1);

            //Generamos otras clase predefinida de unity el golpe
            RaycastHit golpe;
            if(Physics.Raycast(rayo, out golpe))
            {
                //Aqui va la animacin de las chispas y el humito
                StartCoroutine(lanzarChispitas(golpe.point));
                StartCoroutine(lanzarHumito(golpe.point));
                //verificamos colision con el zombi

               
                if (golpe.transform.gameObject.tag == "zombi")
                {
                    zombiDisparos++;
                    if (zombiDisparos == 3)
                    {
                        //  Destroy(golpe.transform.gameObject);
golpe.transform.gameObject.GetComponent<Animator>().Play("caer");

                        YakuControlador1.velocidad = 0;
                        
                       
                    }
                }


            }
        }
		
	}

    public void OnGUI()
    {
        //Dibujamos una caja  a partir e un panel opaco
        //Buscamos la posicion de la camara
        float posx = camara.pixelWidth / 2 - 6;
        float posy = camara.pixelHeight / 2 - 6;
        GUI.Box(new Rect(posx, posy, 12, 12), "*");
    }

    private IEnumerator lanzarChispitas(Vector3 pos)
    {
     ParticleSystem chis = Instantiate(chispas, pos, Quaternion.identity);

        yield return new WaitForSeconds(3);
        Destroy(chis);
    }
    private IEnumerator lanzarHumito(Vector3 pos)
    {
        ParticleSystem hum = Instantiate(humito, pos, Quaternion.identity);

        yield return new WaitForSeconds(5);
        Destroy(hum);
    }
}
