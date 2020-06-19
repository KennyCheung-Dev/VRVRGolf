using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeleportScript : MonoBehaviour {

    private Rigidbody rb;
    public bool canTeleport;

    public Vector3 teleportOffset;

    public float duration;
    public float fwdMult = 1f;

    [Header("Gameobject to teleport to")]
    public GameObject teleportTo;

    public float minVel;

    public bool isTeleporting;

    private GameObject canvas;
    private Image img;

    private Color c;

    public GameObject centerEyeCam;

    //public UnityEvent teleportEvent;

    public delegate void teleportDelegate();
    public static teleportDelegate onTeleport;

    //public float freq = 200f;
    //public float trigger = 255;

    // Use this for initialization
    void Start () {
        rb = teleportTo.GetComponent<Rigidbody>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        img = canvas.transform.Find("TeleportImage").GetComponent<Image>();
        c = img.color;
        c.a = 0;
        img.color = c;

        //print("test");

        /*
        if (teleportEvent == null)
            teleportEvent = new UnityEvent();*/

       // teleportEvent.AddListener(tEvent);

    }
    
	
	// Update is called once per frame
	void FixedUpdate () {

        if(Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("tut");
        }

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}

        if(rb.velocity.magnitude <= minVel) {
            canTeleport = true;
        } else {
            canTeleport = false;
        }

		if(canTeleport && !isTeleporting) {
            if(OVRInput.Get(OVRInput.Button.PrimaryThumbstick)) {
                centerEyeCam.GetComponent<OVRScreenFade>().fadeInOut();
            }
        }
	}

    public void teleport() {
        Vector3 newPos = new Vector3(
                    teleportTo.transform.position.x,
                    teleportTo.transform.position.y,
                    teleportTo.transform.position.z
                    );

        gameObject.transform.position = newPos - (transform.forward * fwdMult) ;
        transform.position = new Vector3(transform.position.x, Terrain.activeTerrain.SampleHeight(transform.position) + 1, transform.position.z);
        //gameObject.transform.localPosition = new Vector3(transform.localPosition.x + teleportOffset.x, transform.localPosition.y + teleportOffset.y, transform.localPosition.z + teleportOffset.z);
        onTeleport();
        //teleportEvent.Invoke();
    }


    IEnumerator fade() {
        float timer = duration / 2;
        while(timer > 0) {//fade in
            c.a = Mathf.Lerp(1, 0, timer * 2);
            img.color = c;
            timer -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        timer = duration / 2;
        while (timer > 0) {//fade out
            c.a = Mathf.Lerp(0, 1, timer * 2);
            img.color = c;
            timer -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public void doThing(string s) {
        StartCoroutine(fadeToNewScene(s));
    }

    IEnumerator fadeToNewScene(string s) {
        float timer = duration / 2;
        while (timer > 0)
        {//fade in
            c.a = Mathf.Lerp(1, 0, timer * 2);
            img.color = c;
            timer -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        SceneManager.LoadScene(s);

        /*
        timer = duration / 2;
        while (timer > 0)
        {//fade out
            c.a = Mathf.Lerp(0, 1, timer * 2);
            img.color = c;
            timer -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }*/
    }
}
