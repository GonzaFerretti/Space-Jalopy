using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Level/Spawner Wave")]
public class SpawnerWave : ScriptableObject
{
    public GameObject[] shipsToSpawnInOrder;
    public Vector2[] positions;
    public bool shouldHeal;
    public float timeBeforeStarting;
}
