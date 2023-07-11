using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] float playerFallSpeed = 0.1f, spawnRange = 10;

    [Header("Birds")]
    [SerializeField] GameObject birdPrefab;
    [SerializeField] float spawnResetTime = 2, Maxoffset;
    float spawnCooldown;
    

    private void Update() {

        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0) {
            spawnCooldown = spawnResetTime;
            SpawnBird();
        }


        foreach (Transform child in transform) {
            child.transform.position += Vector3.up * playerFallSpeed * Time.deltaTime;
        }
    }

    void SpawnBird() {
        var spawnPos = transform.position + Vector3.down * spawnRange;
        spawnPos += new Vector3(Random.Range(-Maxoffset, Maxoffset), 0, Random.Range(-Maxoffset, Maxoffset));
        Instantiate(birdPrefab, spawnPos, Quaternion.identity, transform);
    }

    private void OnDrawGizmosSelected() {
        var size = new Vector3(Maxoffset * 2, 1, Maxoffset * 2);
        Gizmos.DrawWireCube(transform.position + Vector3.down * spawnRange, size);
    }
}
