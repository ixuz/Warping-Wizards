using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour {

    public Transform Aim;
    public Transform FireSpawnpoint;
    public Transform FieAim;
    public int Dir;
    public GameObject Fireball;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fire();
        }
    }

    public void fire()
    {
        // mouse pos
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        Debug.Log(mousePos);

        // position
        Vector3 direction = mousePos - Aim.position;
        direction.Normalize();

        Instantiate(Fireball, Aim.position, Quaternion.LookRotation(direction));
    }
}
