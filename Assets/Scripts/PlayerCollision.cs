using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    public delegate void CollisionEvent(Collision collision);
    public static event CollisionEvent CollisionOccured;
    public PlayerMovement movement;
    public InputHandler inputHandler;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "Obstacle") {
            Debug.Log("Hit an obstacle!");
            movement.enabled = false;
            inputHandler.enabled = false;
            FindAnyObjectByType<GameManager>().EndGame();
            CollisionOccured(collision);
        }
    }
}
