using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float spawnInterval = 3;
    private float spawnCooldown;

    [SerializeField]
    private FPSPlayerController player;

    [SerializeField]
    private List<Enemy> enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        spawnCooldown = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnCooldown > 0)
        {
            spawnCooldown -= Time.deltaTime;
            if(spawnCooldown <= 0)
            {
                SpawnEnemy();
                spawnCooldown = spawnInterval;
            }
        }
    }

    private void SpawnEnemy()
    {
        var prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        var position = GetPosition();
        Instantiate(prefab, position, Quaternion.identity);
    }

    private Vector3 GetPosition()
    {                          // -1, 1, 1
        Vector3 pos = new Vector3(1, 1, 1);
        if (player.transform.position.x > 0)
            pos.x *= -1;

        if(player.transform.position.z > 0)
            pos.z *= -1;

        pos.x *= Random.Range(5f, 15f);
        pos.z *= Random.Range(5f, 15f);

        return pos;
    }
}
