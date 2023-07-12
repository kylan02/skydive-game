using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] float playerFallSpeed = 0.1f, spawnRange = 10, Maxoffset;

    [Header("Birds")]
    [SerializeField] GameObject birdPrefab;
    [SerializeField] float birdSpawnResetTime = 2;
    float birdSpawnCooldown;

    [Header("Obstacles")]
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float obstacleSpawnResetTime = 5;

    float obstacleSpawnCooldown;
    Transform player;

    private void Start() {
        player = Player.i.transform;
    }

    private void Update()
    {

        birdSpawnCooldown -= Time.deltaTime;
        if (birdSpawnCooldown <= 0)
        {
            birdSpawnCooldown = birdSpawnResetTime;
            SpawnObject(birdPrefab);
        }

        obstacleSpawnCooldown -= Time.deltaTime;
        if (obstacleSpawnCooldown <= 0)
        {
            obstacleSpawnCooldown = obstacleSpawnResetTime;
            SpawnObject(obstaclePrefab);
        }


        foreach (Transform child in transform)
        {
            child.transform.position += Vector3.up * playerFallSpeed * Time.deltaTime;
        }
    }

    void SpawnObject(GameObject prefab)
    {
        var spawnPos = transform.position + Vector3.down * spawnRange;
        spawnPos.x = player.position.x;
        spawnPos.z = player.position.z;
        spawnPos += new Vector3(Random.Range(-Maxoffset, Maxoffset), 0, Random.Range(-Maxoffset, Maxoffset));
        Instantiate(prefab, spawnPos, Quaternion.identity, transform);
    }

    private void OnDrawGizmosSelected()
    {
        var size = new Vector3(Maxoffset * 2, 1, Maxoffset * 2);
        var pos = Application.isPlaying ? player.position : transform.position;
        pos.y = transform.position.y - spawnRange;
        Gizmos.DrawWireCube(pos, size);
    }
}
