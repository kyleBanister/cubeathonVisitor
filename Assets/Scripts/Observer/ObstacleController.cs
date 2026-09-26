using UnityEngine;

public class ObstacleController : MonoBehaviour {
    public MeshRenderer meshRenderer;

    void OnEnable() {
        PlayerCollision.CollisionOccured+=CollisionHandler;
    }
    void OnDisable() {
        PlayerCollision.CollisionOccured-=CollisionHandler;
    }
    void CollisionHandler(Collision collision) {
        
        if (gameObject == collision.gameObject) {
        Color newColor = new Color(1f, 0.5f, 0f);
        Material newMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit")) {
            color = newColor
        };
        meshRenderer.material = newMaterial;
        }
    }
}
