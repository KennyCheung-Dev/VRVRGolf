using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hapticFeedback : MonoBehaviour {

    

    public float freq = 0.0f;
    public float trigger = 255;

    public float vibrateLength;


    // Use this for initialization
    void Start () {
        //OVRInput.SetControllerVibration(freq, trigger, OVRInput.Controller.RTouch);
        //StartCoroutine(stopVibrating(vibrateLength));
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Club"))
        {
            if (collision.transform.root.gameObject.GetComponent<OVRGrabbable>().isGrabbed)
            {
                OVRInput.SetControllerVibration(freq, trigger, OVRInput.Controller.RTouch);
                StartCoroutine(stopVibrating(vibrateLength));
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Club"))
        {
            if (other.transform.root.gameObject.GetComponent<OVRGrabbable>().isGrabbed)
            {
                OVRInput.SetControllerVibration(freq, trigger, OVRInput.Controller.RTouch);
                StartCoroutine(stopVibrating(vibrateLength));
            }
        }

    }

    public IEnumerator stopVibrating(float time)
    {
        yield return new WaitForSeconds(time);
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }

}
