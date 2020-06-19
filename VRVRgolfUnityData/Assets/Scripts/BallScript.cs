using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    
    private Vector3 vectorBoi;
    private RaycastHit hit;

    [Header("Offset slightly above ground")]
    public float teleportOffset;

    
	// Update is called once per frame
	void LateUpdate () {

       // print(Terrain.activeTerrain.SampleHeight(transform.position) + " vs " + transform.position.y);

        vectorBoi = -Vector3.up;
        if (!Physics.Raycast(transform.position, vectorBoi, out hit)) {
           
            transform.root.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position) + teleportOffset, transform.position.z);
        }
    }
}
