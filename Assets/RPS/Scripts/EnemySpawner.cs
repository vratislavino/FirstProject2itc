using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    [Range(1, 100)]
    int enemyCount;

    [SerializeField]
    LayerMask mask;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyCount; i++) {
            SpawnAtRandomPosition();
        }
    }

    private void SpawnAtRandomPosition() {
        Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity);
    }

    private Vector3 GetRandomPosition() {
        var pos = new Vector3(Random.Range(20f, 100f), 60f, Random.Range(20f, 100f));

        if (Physics.Raycast(pos, Vector3.down, out RaycastHit info, 100, mask)) {
            return info.point;
        }
        return GetRandomPosition();
    }
}
