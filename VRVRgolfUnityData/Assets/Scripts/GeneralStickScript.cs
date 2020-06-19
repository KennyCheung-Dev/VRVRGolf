using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralStickScript : MonoBehaviour {

    private Rigidbody rb;
    
    public GameObject leftBigCol;
    public GameObject rightBigCol;
    public GameObject smallCol;

    public bool forBastardSword;


    public float thresh;

    private bool canHit;

    void Start() {
        rb = transform.root.gameObject.GetComponent<Rigidbody>();
        TeleportScript.onTeleport += calledTeleport;
        canHit = true;
    }

    private void OnDestroy() {
        TeleportScript.onTeleport -= calledTeleport;
    }

    void calledTeleport() {
        canHit = false;
        leftBigCol.SetActive(false);
        rightBigCol.SetActive(false);
        smallCol.SetActive(false);
        Invoke("resetHit", 0.5f);
    }

    void resetHit() {
        canHit = true;
    }

    // Update is called once per frame
    void FixedUpdate() {

        //print(rb.velocity.magnitude);

        //print(transform.InverseTransformDirection(rb.velocity).x);
        Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector2 secondaryAxis = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        if (secondaryAxis.magnitude > 0.1f && canHit)
        {
            StartCoroutine(SecondThumb());
        }

        if (primaryAxis.magnitude > 0.1f && rb.isKinematic)
        {
            leftBigCol.SetActive(false);
            rightBigCol.SetActive(false);
        } else if (canHit && !forBastardSword) {
            if (transform.InverseTransformDirection(rb.velocity).x >= thresh)
            {
                leftBigCol.SetActive(true);
                rightBigCol.SetActive(false);
                smallCol.SetActive(false);
            } else if (transform.InverseTransformDirection(rb.velocity).x <= -thresh)
            {
                leftBigCol.SetActive(false);
                rightBigCol.SetActive(true);
                smallCol.SetActive(false);
            } else
            {
                leftBigCol.SetActive(false);
                rightBigCol.SetActive(false);
                smallCol.SetActive(true);
            }
        } else if(canHit && forBastardSword) {
            if (transform.InverseTransformDirection(rb.velocity).y >= thresh)
            {
                leftBigCol.SetActive(true);
                rightBigCol.SetActive(false);
                smallCol.SetActive(false);
            }
            else if (transform.InverseTransformDirection(rb.velocity).y <= -thresh)
            {
                leftBigCol.SetActive(false);
                rightBigCol.SetActive(true);
                smallCol.SetActive(false);
            }
            else
            {
                leftBigCol.SetActive(false);
                rightBigCol.SetActive(false);
                smallCol.SetActive(true);
            }
        }
    }

    IEnumerator SecondThumb() {
        canHit = false;
        yield return new WaitForSeconds(0.5f);
        canHit = true;
    }
}
