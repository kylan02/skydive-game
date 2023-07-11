using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<PlayerMovement>() == null) return;

        Player.i.BirdHit();
        Destroy(gameObject);
    }

    private void Update() {
        if (transform.position.y > Camera.main.transform.position.y + 4) {
            Destroy(gameObject);
        }
    }
}
