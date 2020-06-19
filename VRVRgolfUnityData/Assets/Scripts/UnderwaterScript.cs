using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterScript : MonoBehaviour {
    public bool under;
    public float threshold;

    public GameObject water;
    private GameObject player;

    public Color skyboxFogColor;
    public Color skyboxOriginalColor;

    private float currentHeight;

    private bool hadChanged;
	// Use this for initialization
	void Start () {
        player = transform.root.gameObject;
        //threshold = water.transform.position.y;
        changeToRegularMode();

    }
	
	// Update is called once per frame
	void Update () {

        currentHeight = player.transform.position.y + transform.localPosition.y;

        if (currentHeight <= threshold && !hadChanged) {
            changeToUnderwaterMode();
            hadChanged = true;
        } else if (currentHeight > threshold && hadChanged) {
            changeToRegularMode();
            hadChanged = false;
        }
	}

    private void changeToUnderwaterMode() {
        RenderSettings.fog = true;
        water.transform.rotation = Quaternion.Euler(180, 0, 0);
        if (RenderSettings.skybox.HasProperty("_Tint"))
            RenderSettings.skybox.SetColor("_Tint", skyboxFogColor);
        else if (RenderSettings.skybox.HasProperty("_SkyTint"))
            RenderSettings.skybox.SetColor("_SkyTint", skyboxFogColor);
    }

    private void changeToRegularMode() {
        RenderSettings.fog = false;
        water.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (RenderSettings.skybox.HasProperty("_Tint"))
            RenderSettings.skybox.SetColor("_Tint", skyboxOriginalColor);
        else if (RenderSettings.skybox.HasProperty("_SkyTint"))
            RenderSettings.skybox.SetColor("_SkyTint", skyboxOriginalColor);
    }



}
