using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaControlador : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        // print("se imprime a lo loco");

        transform.Rotate(Vector3.up * 60 * Time.deltaTime, Space.World);
    }
}
