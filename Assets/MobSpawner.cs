using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour {

  public MobSpawn[] mobSpawns;
  public float spawnRate = 1.0f;
  public float spawnRateDifficultyIncrease = 0.1f;

    public float artySpawnChance = 10f;
    public float spidumSpawnChance = 40f;
    public float skeletorSpawnChance = 40f;

    float cooldown = 0.0f;

	// Use this for initialization
	void Start () {
    cooldown = 1.0f / (spawnRate + spawnRateDifficultyIncrease * State.instance.difficultyLevel);
  }
	
	// Update is called once per frame
	void Update () {
    cooldown -= Time.deltaTime;
    if (cooldown <= 0) {
      cooldown = 1.0f / (spawnRate + spawnRateDifficultyIncrease * State.instance.difficultyLevel);
      SpawnRandomMob();
    }
  }

  void SpawnRandomMob() {


    Debug.Log("Spawning random mob");
    // (8, 8, 2) = 18
    // 0-7 = index 0
    // 8-15 = index 1
    // 16-17 = index 2

    int totalWeight = 0;
    foreach (MobSpawn mobSpawn in mobSpawns) {
      totalWeight += mobSpawn.spawnWeight;
    }
    Debug.Log("Total weight: " + totalWeight);

    int mobToSpawn = Random.Range(0, totalWeight);

    GameObject mobPrefab = null;
    foreach (MobSpawn mobSpawn in mobSpawns) {
      mobToSpawn -= mobSpawn.spawnWeight;
      if (mobToSpawn < 0) {
        mobPrefab = mobSpawn.mobPrefab;
        break;
      }
    }
    Debug.Log("mobPrefab: " + mobPrefab);

    if (mobPrefab != null) {
      Instantiate(mobPrefab, transform.position, Quaternion.identity);
    }
  }

    [System.Serializable]
    public class MobSpawn {
        public GameObject mobPrefab;

        [Range(1,10)]
        public int spawnWeight = 1;
    }
}
