using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    private bool zoomoutActive = false;

    void OnEnable() {
        PlayerMovement.ElevationOccured+=ElevationHandler;
    }
    void OnDisable() {
        PlayerMovement.ElevationOccured-=ElevationHandler;
    }

    public Transform player;
    public Vector3 offset;
    // Update is called once per frame
    void Update() {
        transform.position = player.position + offset;
    }

    void ElevationHandler() {
        if(!zoomoutActive) {
            offset*=2;
        }
        zoomoutActive = true;
    }
}
