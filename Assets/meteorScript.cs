using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorScript : MonoBehaviour {

    public GameObject thisObject;

	// Use this for initialization
	void Start () {
    EZCameraShake.CameraShaker.Instance.ShakeOnce(1.0f, 15.2f, 0.5f, 1.5f);
    Destroy(thisObject, 3.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
