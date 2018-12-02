using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

  public float collectionRange = 3.0f;
  public float acceleration = 0.01f;
  public float moveSpeed = 0.1f;

  GameObject player;
  Vector3 initialPosition;
  float timePassed = 0.0f;
  bool collected = false;

	void Start () {

    initialPosition = transform.position;
    player = GameObject.FindGameObjectWithTag("Player");
  }
	
	// Update is called once per frame
	void Update () {

    if (!collected) {
      if (Vector2.Distance(transform.position, player.transform.position) < collectionRange) {
        collected = true;
      }
    }

    if (collected) {
      timePassed += Time.deltaTime;
      moveSpeed += acceleration * Time.deltaTime;
      transform.position = Vector3.Slerp(initialPosition, player.transform.position, timePassed * moveSpeed);
    }
	}

  public void OnCollisionEnter2D(Collision2D collision) {
    if (collision.collider.gameObject.tag == "Player") {
      Destroy(gameObject);
    }
  }
}
