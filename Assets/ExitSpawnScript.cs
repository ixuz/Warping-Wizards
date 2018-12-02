using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSpawnScript : MonoBehaviour {

    public Transform spidumSpawnPoint;
    public GameObject spidum;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(spidum, spidumSpawnPoint.position, spidumSpawnPoint.rotation);
        Destroy(gameObject, 0f);
    }
}
