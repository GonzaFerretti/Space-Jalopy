using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public BoundaryInfo boundaryInfo;
    public SpawnerWave[] enemyWaves;
    public List<GameObject> remainingEnemies;
    public int currentWaveIndex = 0;
    public Vector2 extraPadding;

    public void Update()
    {
        if (remainingEnemies.Count == 0)
        {
            if (currentWaveIndex < enemyWaves.Length)
            {
                SpawnWave();
            }
            else
            {
                GetComponent<GameStateController>().PlayerWon();
            }
            currentWaveIndex++;
        }
    }

    public void SpawnWave()
    {
        int currentSpawnWaveLength = enemyWaves[currentWaveIndex].shipsToSpawnInOrder.Length;
        try
        {
            foreach (HookProjectile hook in FindObjectsOfType<HookProjectile>())
            {
                Destroy(hook.gameObject);
            }
        }
        catch { }
        if (enemyWaves[currentWaveIndex].shouldHeal)
        {
            FindObjectOfType<PlayerShip>().currentHp = FindObjectOfType<PlayerShip>().startHp;
        }
        for (int i = 0; i < currentSpawnWaveLength; i++)
        {
            GameObject go = Instantiate(enemyWaves[currentWaveIndex].shipsToSpawnInOrder[i], null);
            go.transform.position = enemyWaves[currentWaveIndex].positions[i];
            remainingEnemies.Add(go);
        }
    }

    public void UpdateDeadEnemy(GameObject go)
    {
        remainingEnemies.Remove(go);
    }
    /*
    public Vector3 GetActualPosition(Vector2 relativeSize, GameObject go)
    {
        Vector2 padding = go.GetComponent<BoundaryChecker>().padding;
        float padx = (relativeSize.x > 0.5f) ? -padding.x - extraPadding.x : padding.x + extraPadding.x;
        float pady = (relativeSize.y > 0.5f) ? -padding.y - extraPadding.y : padding.y + extraPadding.y;
        float x = relativeSize.x * (boundaryInfo.max.x - boundaryInfo.min.x) - boundaryInfo.min.x + padx * 3;
        float y = relativeSize.y * (boundaryInfo.max.y - boundaryInfo.min.y) - boundaryInfo.min.y + pady * 3;
        return new Vector3(x, y, 0);
    }*/
}
