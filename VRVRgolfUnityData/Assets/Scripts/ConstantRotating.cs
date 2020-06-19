using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotating : MonoBehaviour {
    private Rigidbody rigidBoi;
    public float rotateVelocity;
	// Use this for initialization
	void Start () {
        rigidBoi = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rigidBoi.angularVelocity = new Vector3(0, rotateVelocity, 0);
	}
}
