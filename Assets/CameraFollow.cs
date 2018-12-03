using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

  public Transform followObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector3 followPos = followObject.transform.position;

    mousePos.z = transform.position.z;
    followPos.z = transform.position.z;

    transform.position = Vector3.Lerp(followPos, mousePos, 0.1f);
  }
}
