using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour {

  public GameObject[] mobPrefabs;
  public float spawnRate = 1.0f;

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
    GameObject mobPrefab = mobPrefabs[Random.Range(0, mobPrefabs.Length)];
    Instantiate(mobPrefab, transform.position, Quaternion.identity);
  }
}
