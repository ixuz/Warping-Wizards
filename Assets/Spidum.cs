using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spidum : Unit {

  private GameObject player;

  void Start() {

    player = GameObject.FindGameObjectsWithTag("Player")[0];
    SetFollow(player.transform);
  }

  void Update() {

    UpdateVelocity();
    UpdateAnimator();
  }
}
