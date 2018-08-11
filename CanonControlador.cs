using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanonControlador : MonoBehaviour {
    public GameObject player;
    public Text textoResultado;
    Vector3 posCanon;
    Vector3 posPlayer;
    GameObject esfera;
	// Use this for initialization
	void Start () {
        posCanon = transform.position;
        posPlayer = player.transform.position;
        Vector3 direccion = posPlayer - posCanon;
        float distancia = direccion.magnitude;
        textoResultado.text = "Distancia: " + distancia;

        //Esta funcion o metodo invoca cualquier metodo y o repite
        //el numero de veces necesario con incrementos iguales
        InvokeRepeating("Crear", 2.0f, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
        //<<Sacamos el vector resultante
        Vector3 direccion = player.transform.position - transform.position;
        //Ahra estableccemos la rotacion
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(direccion), Time.deltaTime * 1.8f);
        //Animacacion de la esfera
        esfera.transform.Translate(direccion.normalized * Time.deltaTime * 12f);
      
	}

    private void Crear()
    {
        Vector3 direccion = player.transform.position - transform.position;
        //Checamos la distancia, si es menor de 10 que dispare, sino, pues no!!
        if (direccion.magnitude < 10)
        {
            Destroy(esfera);

            //Generamos la esfera
            esfera = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            esfera.transform.position = transform.position;
        }
    }

    private void OnGUI()
    {
        //Vamos a mostrar la distancia de cañon al player
        Vector3 direccion = player.transform.position - transform.position;
        textoResultado.text="Distancia:" + direccion.magnitude;
    }
}
