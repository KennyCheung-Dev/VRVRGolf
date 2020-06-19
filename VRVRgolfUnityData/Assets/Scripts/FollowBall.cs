using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour {

    public GameObject follow;
    
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = follow.transform.position;
	}
}
