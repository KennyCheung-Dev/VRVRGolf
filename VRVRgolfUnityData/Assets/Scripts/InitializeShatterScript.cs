using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeShatterScript : MonoBehaviour {

    public GameObject childToHide;

	// Use this for initialization
	void Start () {
        childToHide.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
