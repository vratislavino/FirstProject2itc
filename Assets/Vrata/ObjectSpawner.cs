using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    List<SpawnData> spawnData;

    [SerializeField]
    float interval; // s

    [SerializeField]
    float initialVelocity;

    float speedMultiplier = 1;

    void Start()
    {
        StartCoroutine(SpawnRandomObject());
        Score.Instance.ScoreChanged += TryToSpeedUp;
    }

    private void TryToSpeedUp(int newScore) {
        int speedLevel = newScore / 1000;
        speedMultiplier = (float)Math.Pow(1.2f, speedLevel);
    }

    IEnumerator SpawnRandomObject() {
        while (true) {
            SpawnObject(GetRandomObject());
            yield return new WaitForSeconds(UnityEngine.Random.Range(interval - 0.2f, interval + 0.2f));
        }
    }

    Rigidbody GetRandomObject() {
        float rnd = UnityEngine.Random.Range(0f, 1f);
        float sum = 0;
        for(int i = 0; i < spawnData.Count; i++) {
            sum += spawnData[i].Probability;
            if(rnd <= sum) {
                return spawnData[i].SpawnPrefab;
            }
        }

        return spawnData.First().SpawnPrefab;
    }

    void SpawnObject(Rigidbody g) {
        var r = Instantiate(g, GetRandomPosition(), Quaternion.identity, transform);
        r.velocity = Vector3.down * initialVelocity * speedMultiplier;
        r.AddTorque(Vector3.up * 100);
        Destroy(r.gameObject, 5f);
    }

    Vector3 GetRandomPosition() {
        return new Vector3(
            UnityEngine.Random.Range(-2.8f, 2.8f), 
            transform.position.y, 
            transform.position.z
            );
    }
}

[Serializable]
public class SpawnData
{
    public Rigidbody SpawnPrefab;
    public float Probability;
}