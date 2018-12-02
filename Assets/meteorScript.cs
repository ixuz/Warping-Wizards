using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorScript : MonoBehaviour {

    public GameObject thisObject;

	// Use this for initialization
	void Start () {
        Destroy(thisObject, 3.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
