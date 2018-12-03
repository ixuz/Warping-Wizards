using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Wizard : Unit {

  public GameObject mainCamera;
  public GameObject virtualCamera;
  public GameObject ghostPrefab;
  public GameObject activeGhost = null;

  // Update is called once per frame
  void Update () {

    // Handle inputs

    if (Input.GetKeyDown(KeyCode.Mouse1)) {
      if (activeGhost == null) {
        activeGhost = Instantiate(ghostPrefab, transform.position, Quaternion.identity);
      } else {
        transform.position = activeGhost.transform.position;
        Destroy(activeGhost);
      }
    }

    Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    SetInput(input);
    UpdateVelocity();
    UpdateAnimator();
  }

  void disableLookAhead() {

  }

  protected override void OnHit() {
    base.OnHit();

    AudioManager.instance.PlaySfx("WizardOnHit");
    EZCameraShake.CameraShaker.Instance.ShakeOnce(1.0f, 15.2f, 0.1f, 0.5f);
  }

  public override void OnTriggerEnter2D(Collider2D collider) {
    base.OnTriggerEnter2D(collider);

    if (collider.gameObject.tag == "AOE") {
      OnHit();
    }

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
