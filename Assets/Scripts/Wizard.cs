using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour {

  public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    Vector2 pos = transform.position;
    Vector2 input = GetInput();
    input.Normalize();

    pos += input * speed * Time.deltaTime;

    transform.position = pos;
  }

  Vector2 GetInput() {

    Vector2 input = Vector2.zero;
    if (Input.GetKey(KeyCode.A)) {
      input += -Vector2.right;
    }
    if (Input.GetKey(KeyCode.D)) {
      input += Vector2.right;
    }
    if (Input.GetKey(KeyCode.W)) {
      input += Vector2.up;
    }
    if (Input.GetKey(KeyCode.S)) {
      input += -Vector2.up;
    }

    return input;
  }
}
