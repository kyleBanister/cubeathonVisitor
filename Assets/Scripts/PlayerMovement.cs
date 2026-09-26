using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public delegate void MovementEvent(float dir);
    public static event MovementEvent MovementOccured;

    public delegate void ElevationEvent();
    public static event ElevationEvent ElevationOccured;

    public Jumper jumper;

    public Rigidbody rb;
    public BoxCollider collider;
    public float forwardForce = 1000f;
    public float sidewaysForce = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        Debug.Log("Hello, World!");
        
    }
    public void MoveLeft() {
        rb.AddForce(-sidewaysForce*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        MovementOccured(-1f);
    }

    public void MoveRight() {
        rb.AddForce(sidewaysForce*Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        MovementOccured(1f);
    }

    public void Jump() {
        jumper.Jump(rb, collider);
    }

    void FixedUpdate() {
        rb.AddForce(0, 0, forwardForce*Time.deltaTime);
    
        if (rb.position.y < -1f) {
            ElevationOccured();
            FindAnyObjectByType<GameManager>().EndGame();
        }
    }
}
