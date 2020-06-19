using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSpaceOffset : MonoBehaviour {

    public float yOffset;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, transform.position.z);
	}
	
}
