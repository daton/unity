using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BolaControlador : MonoBehaviour {
  float velocidad = 7;
	int direccion=1;
    public Text textoVidas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = 
			transform.position + new Vector3(0, 0, velocidad * Time.deltaTime*direccion);
	}


	private void OnCollisionEnter(Collision collision){
		direccion = direccion * -1;
       if(collision.gameObject.tag == "player")
        {
            //Aqui le quitamos una vida :'(
           ScoreControlador.misVidas--;
   textoVidas.text = "Vidas:" + ScoreControlador.misVidas;
            Destroy(this.gameObject);
        }
      
	}
}
