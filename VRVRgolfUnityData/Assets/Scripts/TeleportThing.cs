using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportThing : MonoBehaviour {

    [SerializeField]
    private GameObject ball;

    public Vector3 posOffset;


    private void Start() {
        TeleportScript.onTeleport += calledTeleport;
    }

    private void OnDestroy() {
        TeleportScript.onTeleport -= calledTeleport;
    }
    
    public void calledTeleport() {
        //posOffset = transform.position - ball.transform.position;
        transform.position = ball.transform.position + posOffset;
    }
}
