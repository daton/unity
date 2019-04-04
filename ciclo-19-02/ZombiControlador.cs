using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiControlador : MonoBehaviour
{

    public GameObject player;
    GameObject esfera;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Crear", 2.0f, 3.0f);
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

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = player.transform.position - transform.position;
        //Ahra estableccemos la rotacion
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(direccion), Time.deltaTime * 1.8f);
        //Animacacion de la esfera
        if (esfera != null)
            esfera.transform.Translate(direccion.normalized * Time.deltaTime * 12f);
    }
}
