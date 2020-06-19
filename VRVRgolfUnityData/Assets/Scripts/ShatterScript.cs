using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterScript : MonoBehaviour {
    public GameObject replacement;

    private void Start() {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.root.gameObject.tag == "Club") {
            replacement.SetActive(true);
            Destroy(gameObject);
        }

        /*
        print(collision.gameObject.name);

        if (collision.gameObject.tag == "Terrain" && Vector3.Magnitude(gameObject.transform.root.GetComponent<Rigidbody>().velocity) > 0.1) {
            replacement.SetActive(true);
            Destroy(gameObject);
        }*/
    }

	private void OnTriggerEnter (Collider collider) {
        //print(collider.transform.root.gameObject.tag);

        if (collider.transform.root.gameObject.tag == "Club") {
			replacement.SetActive(true);
			Destroy(gameObject);
		}
	}
}
