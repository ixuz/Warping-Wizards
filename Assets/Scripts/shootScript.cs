using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour {

  public GameObject Fireball;
  Vector2 direction;

  public float CoolDown;
  public float CoolDownTime;

  private void Start()
  {
      CoolDown = CoolDownTime;
  }

  void Update()
  {


    if (Input.GetKeyDown(KeyCode.Mouse0) && CoolDown < 0)
    {
        fire();
    }
    CoolDown = CoolDown - Time.deltaTime;

  }

  public void fire()
  {
    // mouse pos
    Vector3 mousePos = Input.mousePosition;
    mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    mousePos.z = 0;

    // position
    direction = mousePos - transform.position;
    direction.Normalize();
    GameObject fireball = Instantiate(Fireball, transform.position, Quaternion.LookRotation(direction));

    Physics2D.IgnoreCollision(fireball.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    CoolDown = CoolDownTime;

    CameraShaker.instance.ShakeOnce(0.2f);

    AudioManager.instance.PlaySfx("WizardOnFire");
  }
}
