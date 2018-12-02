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

  public override void OnTriggerEnter2D(Collider2D collider) {
    base.OnTriggerEnter2D(collider);

    if (collider.gameObject.tag == "Heart") {
      if (hp < 3) {
        hp += 1;
      }

      AudioManager.instance.PlaySfx("WizardOnHeal");
    }
    if (collider.gameObject.tag == "Soul") {
      ArenaState.instance.souls++;
      
      AudioManager.instance.PlaySfx("WizardOnSoul");
    }
  }
}
