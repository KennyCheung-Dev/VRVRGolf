using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {
    public Color original;
    public float upSpeed;
    public float currentAlpha;
    public bool objectiveCompleted = false;

    public float distanceThreshold;
    // Use this for initialization
    void Start() {

        //original = GetComponent<MeshRenderer>().material.color;
        original = GetComponent<MeshRenderer>().material.GetColor("_TintColor");
        currentAlpha = original.a;
    }

    // Update is called once per frame
    void Update() {
        if (objectiveCompleted)
        {
            currentAlpha += upSpeed;
            GetComponent<MeshRenderer>().material.SetColor("_TintColor", new Color(original.r, original.b, original.b, currentAlpha));
        }
    }

    private void OnDestroy() {
        GetComponent<MeshRenderer>().material.color = original;


    }

    public float Map(float x, float in_min, float in_max, float out_min, float out_max) {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

    public void SetComplete() {
        objectiveCompleted = true;
    }
}
