using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Wizard : MonoBehaviour {

    public Animator animator;
    public Rigidbody2D rb;
    public float movementSmoothing = 1.0f;
    public float speed = 2f;

    private Vector2 currentVelocity;

    // Update is called once per frame
    void Update () {

        // Handle inputs
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 desiredVelocity = input * speed;

        Vector2 actualVelocity = Vector2.Lerp(currentVelocity, desiredVelocity, 1/movementSmoothing * Time.deltaTime);
        rb.velocity = actualVelocity;

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) {
            //Interact();
        }
        currentVelocity = rb.velocity;

        animator.SetFloat("velocity", currentVelocity.magnitude);
        if (currentVelocity.x > 0) {
            animator.SetBool("facing_right", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (currentVelocity.x < 0) {
            animator.SetBool("facing_right", false);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
