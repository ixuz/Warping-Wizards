using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour {

    public GameObject ThisObject;
    public float Speed = 2f;
    public Transform ExplodePoint;
    public Transform SpawnPoint;

    private void Start()
    {
        Destroy(ThisObject.gameObject, 5);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll.gameObject.transform.name);
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
            Debug.Log("hit 1");
            Instantiate(ExplodePoint, SpawnPoint.position, SpawnPoint.rotation);
                Destroy(ThisObject, 0);

    }
}
