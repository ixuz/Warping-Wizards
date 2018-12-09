using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Wizard : Unit {

    public GameObject mainCamera;
    public GameObject virtualCamera;
    public GameObject ghostPrefab;
    public GameObject activeGhost = null;

    // Blink settings
    public float blinkDistance;
    public float blinkCooldown;
    public GameObject blinkSprites;
    public GameObject blinkForeground;

    private LayerMask wallsOnly;
    private float nextBlinkTime;

    private void Start() {
        wallsOnly = 1 << LayerMask.NameToLayer("Walls");
    }

    // Update is called once per frame
    void Update() {
        // Handle inputs
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (Input.GetKeyDown(KeyCode.Mouse1) && Time.timeSinceLevelLoad > nextBlinkTime) {
            Blink(input);
            nextBlinkTime = Time.timeSinceLevelLoad + blinkCooldown;
            blinkSprites.SetActive(true);
        }

        SetInput(input);
        UpdateVelocity();
        UpdateAnimator();

        ScaleBlinkBar();
    }

    void ScaleBlinkBar() {
        if (Time.timeSinceLevelLoad < nextBlinkTime) {
            float t = 1 - (nextBlinkTime - Time.timeSinceLevelLoad) / blinkCooldown;
            blinkForeground.transform.localScale = new Vector3(
                t,
                blinkForeground.transform.localScale.y,
                blinkForeground.transform.localScale.z
            );
            blinkForeground.transform.localPosition = new Vector3(
                (-1f + t) / 2f, // EVIL HACKING
                blinkForeground.transform.localPosition.y,
                blinkForeground.transform.localPosition.z
            );

            // Left/right flip
            blinkSprites.transform.localScale = new Vector3(
                transform.localScale.x,
                blinkSprites.transform.localScale.y,
                blinkSprites.transform.localScale.z
            );
        } else {
            blinkSprites.SetActive(false);
        }
    }

    void Blink(Vector3 direction) {
        direction.Normalize();
        Vector3 targetPosition = transform.position + direction * blinkDistance;

        // Raycast in direction to ensure we don't go through a wall
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, blinkDistance, wallsOnly);
        Debug.DrawRay(transform.position, direction * blinkDistance, Color.green, 5f);

        Vector3 oneThirdPosition = transform.position + direction * blinkDistance / 3f;
        Vector3 twoThirdPosition = transform.position + direction * blinkDistance * 2 / 3f;

        // Constrain blink to bounds of walls
        if (hit.collider != null) {
            Vector2 toPoint = hit.point - (Vector2)transform.position;
            targetPosition = hit.point - toPoint.normalized * 0.5f;

            // Do another cast along the wall
            float blinkDistanceRemaining = blinkDistance - hit.distance;
            Vector2 parallel = Vector2.Perpendicular(hit.normal);
            if (Vector2.Dot(parallel, direction) < 0) {
                parallel *= -1;
            }

            if (blinkDistanceRemaining > blinkDistance * 2f / 3f) {
                oneThirdPosition = targetPosition + (Vector3)parallel * (blinkDistanceRemaining - blinkDistance * 2f / 3f);
            }
            if (blinkDistanceRemaining > blinkDistance * 1f / 3f) {
                twoThirdPosition = targetPosition + (Vector3)parallel * (blinkDistanceRemaining - blinkDistance * 1f / 3f);
            }

            hit = Physics2D.Raycast(targetPosition, parallel, blinkDistanceRemaining, wallsOnly);
            Debug.DrawRay(targetPosition, parallel * blinkDistanceRemaining, Color.cyan, 5f);

            if (hit.collider != null) {
                toPoint = hit.point - (Vector2)transform.position;
                targetPosition = hit.point - toPoint.normalized * 0.5f;

                blinkDistanceRemaining -= hit.distance;
                if (blinkDistanceRemaining > blinkDistance * 2f / 3f) {
                    oneThirdPosition = targetPosition;
                }
                if (blinkDistanceRemaining > blinkDistance * 1f / 3f) {
                    twoThirdPosition = targetPosition;
                }

            } else {
                targetPosition += (Vector3)parallel * blinkDistanceRemaining;
            }
        }

        Destroy(Instantiate(ghostPrefab, transform.position, transform.rotation), 0.05f);
        Destroy(Instantiate(ghostPrefab, oneThirdPosition, transform.rotation), 0.1f);
        Destroy(Instantiate(ghostPrefab, twoThirdPosition, transform.rotation), 0.15f);
        Destroy(Instantiate(ghostPrefab, targetPosition, transform.rotation), 0.2f);


        transform.position = targetPosition;
    }

    void disableLookAhead() {

    }

    protected override void OnDeath() {
        base.OnDeath();
        StartCoroutine(delayedReloadScene());
    }

    public void killShadow() {
        Destroy(activeGhost);
    }

    IEnumerator delayedReloadScene() {
        yield return new WaitForSeconds(2.0f);
        FadeScreen.instance.LoadScene("TheArena");
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
            Debug.Log("Collected soul:" + collider.gameObject.GetInstanceID());
        }
    }
}
