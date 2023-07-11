using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] Vector2 speed = new Vector2(1, 0);
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() == null) return;

        Player.i.BirdHit();
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position += new Vector3(speed.x, 0, speed.y) * Time.deltaTime;
        if (transform.position.y > Camera.main.transform.position.y + 4)
        {
            Destroy(gameObject);
        }
    }
}
