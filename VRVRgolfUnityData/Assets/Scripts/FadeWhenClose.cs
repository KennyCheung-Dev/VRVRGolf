using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeWhenClose : MonoBehaviour {
    public Color original;
    public GameObject player;

    public float distanceThreshold;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //original = GetComponent<MeshRenderer>().material.color;
        original = GetComponent<MeshRenderer>().material.GetColor("_TintColor");

    }
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(player.transform.position, new Vector3(transform.position.x, player.transform.position.y, transform.position.z)) <= distanceThreshold) {
            GetComponent<MeshRenderer>().material.SetColor("_TintColor", new Color(original.r, original.b, original.b, Map(Vector3.Distance(player.transform.position, new Vector3(transform.position.x, player.transform.position.y, transform.position.z)), 0, distanceThreshold, 0 ,0.5f)));
           
        } else
        {
        }

        
	}

    private void OnDestroy()
    {
        GetComponent<MeshRenderer>().material.color = original;


    }

    public float Map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }
}
