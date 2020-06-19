using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverScript : MonoBehaviour {

    private Rigidbody rb;

    public float thresh;

    public GameObject smol;
    public GameObject large;


    public bool canHit;

	// Use this for initialization
	void Start () {
        rb = transform.root.gameObject.GetComponent<Rigidbody>();
        TeleportScript.onTeleport += calledTeleport;
        canHit = true;
    }

    private void OnDestroy() {
        TeleportScript.onTeleport -= calledTeleport;
    }

    void calledTeleport() {
        canHit = false;
        large.SetActive(false);
        smol.SetActive(false);
        Invoke("resetHit", 0.5f);
    }

    void resetHit() {
        canHit = true;
    }

    // Update is called once per frame
    void FixedUpdate () {

        if (canHit)
        {
            if (rb.velocity.magnitude >= thresh)
            {
                large.SetActive(true);
                smol.SetActive(false);
            }
            else
            {
                large.SetActive(false);
                smol.SetActive(true);
            }
        }
	}


}
