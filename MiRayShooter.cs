using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiRayShooter : MonoBehaviour {
    Camera camara;
   public ParticleSystem parti;
   public AudioSource fuenteDisparo;
   public  AudioClip clipDisparo;
    public GameObject caja;
    public int aguante = 0;
    public GameObject zombiPoli;
    public bool generarMosntruo = true;
	// Use this for initialization
	void Start () {
        camara = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            print("Disparaste!!");
            float ancho = camara.pixelWidth / 2;
            float alto = camara.pixelHeight / 2;
            Vector3 punto = new Vector3(ancho, alto, 0);
            Ray rayo = camara.ScreenPointToRay(punto);
            RaycastHit golpe;
            if(Physics.Raycast(rayo, out golpe))
            {
            GameObject objeto=    golpe.transform.gameObject;
                StartCoroutine(MarcarGolpe(golpe.point));
                fuenteDisparo.PlayOneShot(clipDisparo);
            if(golpe.transform.gameObject.tag == "cubeta")
                {
                    print("le diste a la cubeta");
                 Rigidbody rb=   golpe.transform.gameObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        print("si detecto el rb");
                        rb.AddForce(transform.forward *8.5f,ForceMode.Impulse);
                    }
                   
                }
                if (golpe.transform.gameObject.tag == "zombi")
                {
                    print("le diste al zombi");
                    Rigidbody rb = golpe.transform.gameObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        print("si detecto el rb");
                        rb.AddForce(transform.forward * 4.5f, ForceMode.Impulse);
                    }
                    aguante++;
                    if (aguante >=5) Destroy(golpe.transform.gameObject);
                }
            }
        }

        //Checamos la psicion
        Vector3 distanciaCaja = caja.transform.position - transform.position;
        print("distancia a caja:" + distanciaCaja.magnitude);
        if (distanciaCaja.magnitude < 10 && generarMosntruo)
        {
            GenerarMonstruo();
          
        }
        if (!generarMosntruo)
        {
            Vector3 posicion = new Vector3(transform.position.x, zombiPoli.transform.position.y, transform.position.z);
            zombiPoli.transform.LookAt(posicion);
            zombiPoli.transform.Translate(0, 0, 1.5f * Time.deltaTime);
        }

    }

    public void OnGUI()
    {
        float ancho = camara.pixelWidth / 2-6;
        float alto = camara.pixelHeight / 2 - 6;
        GUI.Box(new Rect(ancho, alto, 12, 12), "*");
    }

    public IEnumerator MarcarGolpe(Vector3 pos)
    {
   ParticleSystem explocion=     Instantiate(parti, pos, Quaternion.identity);
        yield return new WaitForSeconds(3);
        Destroy(explocion);
    }

    void GenerarMonstruo()
    {
        zombiPoli = Instantiate(zombiPoli, caja.transform.position, Quaternion.identity);
        
        generarMosntruo = false;
    }

}
