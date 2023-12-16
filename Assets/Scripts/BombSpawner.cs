using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab1; // Premier prefab de bombe
    public GameObject bombPrefab2; // Deuxième prefab de bombe
    public Transform[] spawnPoints; // Tableau des positions de spawn
    public float spawnDelay = 1.5f; // Délai entre les spawners

    private void Start()
    {
        SpawnBombs();
    }

    void SpawnBombs()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Vector3 spawnPos = spawnPoints[i].position;
            GameObject selectedBombPrefab = Random.Range(0, 2) == 0 ? bombPrefab1 : bombPrefab2; // Alterner entre les deux prefabs de bombe

            Instantiate(selectedBombPrefab, spawnPos, Quaternion.identity);

            // Attendre avant de spawner la prochaine bombe
            if (i < spawnPoints.Length)
                StartCoroutine(WaitForNextSpawn());
        }
    }

    System.Collections.IEnumerator WaitForNextSpawn()
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnBombs();
    }
}

