using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] Vector2 range = new Vector2(-1, 1);
    Vector2 speed;

    private void Start()
    {
        speed = new Vector2(Random.Range(range.x, range.y), Random.Range(range.x, range.y));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() == null) return;

        Player.i.BirdHit();
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.GetChild(0).LookAt(transform.position + new Vector3(speed.x, 0, speed.y));
        transform.position += new Vector3(speed.x, 0, speed.y) * Time.deltaTime;
        if (transform.position.y > Camera.main.transform.position.y + 4)
        {
            Destroy(gameObject);
        }
    }
}
