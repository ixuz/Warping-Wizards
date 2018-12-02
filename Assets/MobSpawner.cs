using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour {

  public MobSpawn[] mobSpawns;
  public float spawnRate = 1.0f;

    public float artySpawnChance = 10f;
    public float spidumSpawnChance = 40f;
    public float skeletorSpawnChance = 40f;

    float cooldown = 0.0f;

	// Use this for initialization
	void Start () {
    cooldown = 1.0f / spawnRate;
  }
	
	// Update is called once per frame
	void Update () {
    cooldown -= Time.deltaTime;
    if (cooldown <= 0) {
      cooldown = 1.0f/spawnRate;
      SpawnRandomMob();
    }
  }

  void SpawnRandomMob() {
    int mobToSpawn = Random.Range(0, 90);
    GameObject mobPrefab = mobSpawns[0].mobPrefab;

    Instantiate(mobPrefab, transform.position, Quaternion.identity);
  }

    [System.Serializable]
    public class MobSpawn {
        public GameObject mobPrefab;

        [Range(0,10)]
        public int spawnWeight = 1;
    }
}
