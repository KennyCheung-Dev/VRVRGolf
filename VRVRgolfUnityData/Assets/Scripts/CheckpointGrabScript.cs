using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckpointGrabScript : MonoBehaviour {

    private OVRGrabbable ovrgrab;

    public bool objectiveDone;
    public float downSpeed;

    public GameObject objectiveRays;
    public GameObject finalRays;

    public Animator rayzAnim;
    public Animator finalRayzAnim;

    public GameObject initParticle;
    public GameObject heldParticle;


    // Use this for initialization
    void Start () {
        ovrgrab = GetComponent<OVRGrabbable>();
        
	}
	
	// Update is called once per frame
	void Update () {
		if(ovrgrab.isGrabbed) {
            if (!objectiveDone) {
                initParticle.SetActive(false);
                heldParticle.SetActive(true);
                StartCoroutine(doObjectiveDone());
                rayzAnim.SetTrigger("Completed");
                finalRayzAnim.SetTrigger("Completed");
           
            }
            objectiveDone = true;
        }
	}

    IEnumerator doObjectiveDone() {
        while (transform.localScale.x > 0) {
            transform.localScale = new Vector3(transform.localScale.x - downSpeed, transform.localScale.y - downSpeed, transform.localScale.y - downSpeed);
            yield return new WaitForFixedUpdate();
        }

        //yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
