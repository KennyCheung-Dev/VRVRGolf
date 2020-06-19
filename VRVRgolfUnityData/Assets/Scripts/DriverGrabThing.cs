using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverGrabThing : MonoBehaviour {

    private OVRGrabbable ovgboi;
    private Rigidbody rb;

    [SerializeField]
    private bool isGrabbed;

    [SerializeField]
    private bool hadBeenGrabbed;

    //public GameObject rotAxis;
    

    private float rotX, rotY;

    public float rotSpeed;

    private OVRGrabber previousGrab;

	// Use this for initialization
	void Start () {
        ovgboi = GetComponent<OVRGrabbable>();
        rb = GetComponent<Rigidbody>();
        //rotAxis = transform.Find("RotationAxis").gameObject;
        hadBeenGrabbed = false;
	}
	
	// Update is called once per frame
	void Update () {

        if(ovgboi.isGrabbed && !hadBeenGrabbed) { 
            rb.useGravity = true;
            hadBeenGrabbed = true;
        }

        if(hadBeenGrabbed && !ovgboi.isGrabbed)
        {
            rb.isKinematic = false;
        }

        //PRIMARY IS LEFT CONTROLLER, SECONDARY IS RIGHT CONTROLLER

        if (ovgboi.isGrabbed)  {

            previousGrab = ovgboi.m_grabbedBy;

            if(ovgboi.grabbedBy.name == "LeftHandAnchor")
            {
                //print("left " + ovgboi.grabbedBy.name);

                if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick))
                {

                    //centerEyeCam.GetComponent<OVRScreenFade>().fadeInOut();
                }

            } else
            {
                //print("right" + " "+ ovgboi.grabbedBy.name);
                if (OVRInput.Get(OVRInput.Button.SecondaryThumbstick))
                {
                    
                    Vector2 secondaryAxis = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
                    rotX += secondaryAxis.x;
                    //float rotY = transform.rotation.y + secondaryAxis.y;
                    ovgboi.m_grabbedBy.addRot = new Vector3(0, rotX * rotSpeed, 0);
                    //transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y +rotX, transform.rotation.z);
                    //transform.rotation = Quaternion.AngleAxis(rotX, ovgboi.grabbedBy.transform.position);
                    //transform.RotateAround(rotAxis.transform.position, Vector3.up, rotX);
                    //print("AAAA");
                    //print(secondaryAxis);
                    //centerEyeCam.GetComponent<OVRScreenFade>().fadeInOut();
                } 

            }

            
        } else {
            //if(previousGrab)
            //previousGrab.addRot = Vector3.zero;
        }
    }
}
