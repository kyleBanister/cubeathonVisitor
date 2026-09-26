using UnityEngine;

public class Jumper : MonoBehaviour {
    float jumpForce = 300f;
    float jetpackForce = 60f;
    public bool hasJetpack = false;

    private float distToGround;
    public void Jump(Rigidbody rb, BoxCollider collider) {
        distToGround = collider.bounds.extents.y;
        if(Physics.Raycast(rb.transform.position, -Vector3.up, distToGround+0.1f)) {
            rb.AddForce(0, jumpForce*Time.deltaTime, 0, ForceMode.VelocityChange);
        } else if(hasJetpack) {
            rb.AddForce(0, jetpackForce*Time.deltaTime, 0, ForceMode.VelocityChange);
        }
    }

    public void Accept(VisitorInterface visitor) {
        visitor.Visit(this);
    }
}
