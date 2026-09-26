using UnityEngine;
using System;

public class MovingObstacle : MonoBehaviour {
    public Rigidbody rb;
    public float pathStart; //Lower x position of path
    public float pathLength = 17; //Travel distance of path
    public float frequency = 1; //Hertz
    private float timeValue;
    void Start() {
        if (rb.position.x < pathStart) {
            rb.position = new Vector3(pathStart,rb.position.y,rb.position.z);
        } else if(rb.position.x > pathStart+pathLength) {
            rb.position = new Vector3(pathStart+pathLength,rb.position.y,rb.position.z);
        }

        timeValue = (float)(Math.Asin(2*(rb.position.x-(pathStart+pathLength/2))/pathLength)/(frequency*Math.PI)); //Get where in the sine wave the obstacle is starting.
        rb.linearVelocity = new Vector3((float)(pathLength*frequency*Math.PI*Math.Cos(timeValue*frequency*Math.PI)),0,0); //Set velocity to match sine wave position.
    }
    void FixedUpdate() {
        if (rb.position.x < pathStart) {
            rb.position = new Vector3(pathStart,rb.position.y,rb.position.z);
        } else if(rb.position.x > pathStart+pathLength) {
            rb.position = new Vector3(pathStart+pathLength,rb.position.y,rb.position.z);
        }

        timeValue = (float)(Math.Asin(2*(rb.position.x-(pathStart+pathLength/2))/pathLength)/(frequency*Math.PI));
        rb.AddForce((float)(-pathLength*Math.Pow(frequency,2)*Math.Pow(Math.PI,2)*Math.Sin(frequency*Math.PI*timeValue)),0,0, ForceMode.Acceleration);
    }
}
