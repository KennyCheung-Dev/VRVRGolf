using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubSpawner : MonoBehaviour {

    public GameObject[] club;
    public Vector3[] rotOffsets;
    public Vector3[] movOffsets;
    public int clubNo;
    public float minDistance;

    public GameObject newClub;
    private GameObject previousClub;
    public Vector3 rotOffset;
    //private bool canSpawn;

	// Use this for initialization
	void Start () {
        TeleportScript.onTeleport += calledTeleport;
        newClub = Instantiate(club[clubNo], transform.position + movOffsets[clubNo], transform.rotation * Quaternion.Euler(rotOffsets[clubNo]));
       
        clubNo++;
	}

    private void OnDestroy() {
        TeleportScript.onTeleport -= calledTeleport;
    }

    void calledTeleport() {

        StartCoroutine(afterTeleport());
    }

    IEnumerator afterTeleport() {
        yield return null;
        
           foreach(GameObject g in GameObject.FindGameObjectsWithTag("Club")) {
               if(g.transform.root.GetComponent<Rigidbody>().isKinematic && !g.transform.root.GetComponent<OVRGrabbable>().isGrabbed)
               {
                   Destroy(g);
               }
           }

        
        newClub = Instantiate(club[clubNo % club.Length], transform.position + movOffsets[clubNo % club.Length], transform.rotation * Quaternion.Euler(rotOffsets[clubNo % club.Length]));
        newClub.GetComponent<Rigidbody>().isKinematic = true;
        clubNo++;
    }

    // Update is called once per frame
    void FixedUpdate () {
		if(Vector3.Distance(newClub.transform.position, gameObject.transform.position) > minDistance)
        {
            newClub = Instantiate(club[clubNo % club.Length], transform.position + movOffsets[clubNo % club.Length], transform.rotation * Quaternion.Euler(rotOffsets[clubNo % club.Length])); //NOTE: CRASHES SOMETIMES ????
            newClub.GetComponent<Rigidbody>().isKinematic = true;
            clubNo++;
        }
	}
}
