using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSpawnScript : MonoBehaviour {

    public Transform spidumSpawnPoint;
    public GameObject spidum;

    public bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered != true)
        {
        triggered = true;
                Instantiate(spidum, spidumSpawnPoint.position, spidumSpawnPoint.rotation);
                Destroy(gameObject, 0f);
        }
            
    }
}
