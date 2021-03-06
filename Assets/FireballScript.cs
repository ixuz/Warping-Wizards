﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour {

  public GameObject ThisObject;
  public float Speed = 2f;
  public Transform SpawnPoint;
  public GameObject Explode;

  private void Start()
  {
    Destroy(ThisObject.gameObject, 5);
  }
  void Update()
  {
    transform.Translate(Vector3.forward * Time.deltaTime * Speed);
  }

  public void OnCollisionEnter2D(Collision2D coll)
  {
    Instantiate(Explode, SpawnPoint.position, SpawnPoint.rotation);
    Destroy(ThisObject, 0);
    AudioManager.instance.PlaySfx("FireballDestroyed");
    EZCameraShake.CameraShaker.Instance.ShakeOnce(1.0f, 15.2f, 0.1f, 0.5f);
  }
}
