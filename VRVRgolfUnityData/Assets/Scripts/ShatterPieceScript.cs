using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterPieceScript : MonoBehaviour {
    
	void Start () {
        TeleportScript.onTeleport += calledTeleport;
    }

    private void OnDestroy() {
        TeleportScript.onTeleport -= calledTeleport;
    }

    void calledTeleport() {
        deleteSelf();
    }

    void deleteSelf() {
        Destroy(gameObject);
    }
	
}
