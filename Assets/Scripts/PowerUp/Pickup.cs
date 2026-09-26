using UnityEngine;
using System;

public class Pickup : MonoBehaviour {
    public PowerUp powerup;

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Jumper>()) {
            other.GetComponent<Jumper>().Accept(powerup);
            Destroy(gameObject);
        }
    }
}
