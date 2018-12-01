using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public float time = 5f;
    public GameObject objectToDestroy;

	void Start () {
        Destroy(objectToDestroy, time);
	}

}
