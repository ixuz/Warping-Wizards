using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour {

    public Transform Aim;
    public int Dir;
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
        Debug.Log(mousePos);

        // position
        direction = mousePos - Aim.position;
        direction.Normalize();
        Instantiate(Fireball, Aim.position, Quaternion.LookRotation(direction));
        CoolDown = CoolDownTime;
    }
}
