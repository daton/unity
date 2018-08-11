using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiControlador : MonoBehaviour {

    //DEclaramos un atributo para enlazar a nuestro player
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //daremos seguimiento al player con la tecnica AI de seguimiento autonomo
        Vector3 posicion = new Vector3(player.transform.position.x, player.transform.position.y,
                           player.transform.position.z);
        //Rotamos el zombi hacia e,l player
        transform.LookAt(posicion);
        //Con el metodo translate lo movemos hacia el player
        transform.Translate(0, 0, Time.deltaTime * 1.0f);

		
	}
}
