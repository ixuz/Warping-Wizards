using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Skeletor : Unit {

  public GameObject attack;

  void Start() {

    fsm.AddStateName("Magic");

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
      Debug.Log("Fsm changed to " + stateName + "!");

      switch (stateName) {
        case "Idle":
          SetFollow(attack.transform);
          break;
        case "Run":
          break;
        case "Spin":
          SetFollow(null);
          break;
        
      }
    }
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
