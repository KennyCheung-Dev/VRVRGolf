using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    public GameObject particlez;

    public bool toNextLevel = false;
    public string sceneName;

    public float duration;

    private Image img;
    private GameObject canvas;

    private Color c;

    private GameObject player;

    public GameObject centerEyeCam;


    // Use this for initialization
    void Start () {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        img = canvas.transform.Find("TeleportImage").GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        c = img.color;
        c.a = 0;
        img.color = c;
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other) {
		if (other.transform.root.gameObject.name == "ball")
        {
			if (toNextLevel) {
				centerEyeCam.GetComponent<OVRScreenFade> ().toNextLevel (sceneName);
			} else {
				particlez.SetActive (true);
			}

        }

    }
}
