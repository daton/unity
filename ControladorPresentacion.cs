using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPresentacion : MonoBehaviour {
    public GameObject[] personajes;
    public Text textoPersonaje;
    int indice = 0;
    public string[] textos;
	public void mostrarPersonajes()
    {
        //La siguiente condicion es el numero de personales
        ocultar();
        if (indice >= personajes.Length) indice = 0;
        personajes[indice].SetActive(true);
        textoPersonaje.text = textos[indice];
        indice++;
    }

    void ocultar()
    {
        foreach(GameObject ob in personajes)
        {
            ob.SetActive(false);
        }
    }
}
