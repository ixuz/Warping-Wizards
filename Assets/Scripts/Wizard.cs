using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Wizard : Unit {

  // Update is called once per frame
  void Update () {

    // Handle inputs
    Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    SetInput(input);
    UpdateVelocity();
    UpdateAnimator();
  }

  protected override void OnHit() {
    base.OnHit();

    AudioManager.instance.PlaySfx("WizardOnHit");
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "AOE") {
      hp -= 1;
      CameraShaker.instance.ShakeOnce(0.2f);
      AudioManager.instance.PlaySfx("WizardOnHit");
    }
  }
}
