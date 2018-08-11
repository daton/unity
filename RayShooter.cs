using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
    Camera camara;
    public AudioSource fuenteDisparo;
    public AudioClip clipDisparo;
    public ParticleSystem explosion;
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
            print("Se activo el disparo");
            //Activamos el disparo
            fuenteDisparo.PlayOneShot(clipDisparo);
            //Para aplicar la tecnica del RayCasting primero obtenemos
            //la posicion de la camara
            float ancho = camara.pixelWidth / 2;
            float alto = camara.pixelHeight / 2;
            //Aplicamos el RayCasting
            Vector3 punto = new Vector3(ancho, alto, 0);
            Ray rayo = camara.ScreenPointToRay(punto);
            //Sacamos la proyecccion hasta un objeto de golpe
            RaycastHit golpe;
            //Con un if preguntamos si el rayo choco con un objeto
            if (Physics.Raycast(rayo, out golpe))
            {
                StartCoroutine(AccionarExplosion(golpe.point));
                if (golpe.transform.gameObject.tag == "cubeta")
                {
                    //Le pedimos el rigid body
          Rigidbody rb=golpe.transform.gameObject.GetComponent<Rigidbody>();
                    //Con este rb
                    rb.AddForce(transform.forward * 10, ForceMode.Impulse);
                }
            }
        }
    }

    public void OnGUI()
    {
        float ancho = camara.pixelWidth / 2 - 6;
        float alto = camara.pixelHeight / 2 - 6;
        GUI.Box(new Rect(ancho, alto, 12, 12), "*");
    }

    public IEnumerator AccionarExplosion(Vector3 pos)
    {
        ParticleSystem explo = Instantiate(explosion, pos, Quaternion.identity);
        yield return new WaitForSeconds(3);
        Destroy(explo);
    }
}
