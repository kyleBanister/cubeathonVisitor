using UnityEngine;

public class HudController : MonoBehaviour {
    private string previousDirection;
    void OnEnable() {
        PlayerMovement.MovementOccured+=MovementHandler;
    }
    void OnDisable() {
        PlayerMovement.MovementOccured-=MovementHandler;
    }

    void OnGUI() {
        GUILayout.BeginArea(new Rect (50,50,100,100));
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Dir: " + previousDirection);
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    void MovementHandler(float dir) {
        if(dir > 0) {
            previousDirection = "->";
        } else if(dir < 0) {
            previousDirection = "<-";
        }
    }
}
