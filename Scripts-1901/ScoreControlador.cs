using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControlador : MonoBehaviour {
   public  AudioSource fuenteMoneda;
    public AudioClip clipCaja;
    public Text textoScore;
    int score = 0;
    public static int misVidas = 5;

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
            //Sumamos el score por cada moneda sumar 2 punto
            score = score + 2;
            //Lo mostramos en el texto del panel
            textoScore.text = "Score:" + score;

        }
    }
}
