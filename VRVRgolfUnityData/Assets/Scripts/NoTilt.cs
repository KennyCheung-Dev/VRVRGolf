using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTilt : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 currentPosition = new Vector3(0, 0, 0);
        Vector3 currentRotation = new Vector3(0, 0, 0);
        transform.position = currentPosition;
        transform.rotation = Quaternion.Euler(currentRotation);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
