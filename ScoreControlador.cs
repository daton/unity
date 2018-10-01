using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControlador : MonoBehaviour {
   public  AudioSource fuenteMoneda;
    public AudioClip clipCaja;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "monedita")
        {
            fuenteMoneda.PlayOneShot(clipCaja);
            //SE destruye
            Destroy(other.gameObject);
        }
    }
}
