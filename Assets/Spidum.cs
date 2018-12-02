using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spidum : Unit {

  public GameObject attack;
  public GameObject attackTrigger;

  void Start() {

    fsm.AddStateName("Spin");

    attack = GameObject.FindGameObjectWithTag("Player");

    if (attack != null) {
      SetFollow(attack.transform);
    }
  }

  void Update() {

    animator.SetBool("isFollowing", IsFollowing());
    if (IsFollowing()) {
      animator.SetFloat("isFollowingDistance", Vector3.Distance(GetFollowing().position, transform.position));
    } else {
      animator.SetFloat("isFollowingDistance", Mathf.Infinity);
    }

    UpdateVelocity();
    UpdateAnimator();
  }

  void OnFsmStateChangeEvent(GameObject go, Fsm fsm, string stateName) {
    if (go == gameObject) {

      switch (stateName) {
        case "Idle":
          SetFollow(attack.transform);
          break;
        case "Run":
          break;
        case "Spin":
          Instantiate(attackTrigger, transform.position, transform.rotation);
          AudioManager.instance.PlaySfx("SpidumOnSpin");
          SetFollow(null);
          break;
        
      }
    }
  }

  protected override void OnHit() {
    base.OnHit();

    AudioManager.instance.PlaySfx("SpidumOnHit");
  }

  protected override void OnEnable() {
    base.OnEnable();
    Fsm.OnFsmStateChangeEvent += OnFsmStateChangeEvent;
  }

  protected override void OnDisable() {
    base.OnEnable();
    Fsm.OnFsmStateChangeEvent -= OnFsmStateChangeEvent;
  }
}
