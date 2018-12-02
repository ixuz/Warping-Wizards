using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour {

    public Transform Spawnpoint1;
    public Transform Spawnpoint2;
    public GameObject MobSpawner;

    public GameObject BloodExplosion;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.instance.PlaySfx("StartMobSpawners");

            Instantiate(MobSpawner, Spawnpoint1.position, Spawnpoint1.rotation);
            Instantiate(MobSpawner, Spawnpoint2.position, Spawnpoint2.rotation);
            Instantiate(BloodExplosion, transform.position, transform.rotation);
            Destroy(gameObject, 0f);
        }
    }
}
