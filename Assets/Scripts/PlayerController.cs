using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

public float speed;
public LayerMask collisionLayer;
public Transform moveTo;
public Animator animator;

void Start() {
    Application.targetFrameRate = 60;
    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

    // ORIGINAL CODE BY CG SMOOTHIE (https://www.youtube.com/watch?v=1YKfBh1FCWY)
    // WARNING: DO NOT ADD AS CHILD OF PLAYER
}

public void Update()
{
    float VerticalRaw = Input.GetAxisRaw("Vertical");
    float HorizontalRaw = Input.GetAxisRaw("Horizontal");
    transform.position = Vector3.MoveTowards(transform.position, moveTo.position, speed * Time.deltaTime);

    // Continue only if the player's position has changed by greater than the value on the right (0.1f)
    if(Vector3.Distance(transform.position, moveTo.position) <= 0.1f) {
        animator.SetBool("isWalking", true);

        // Check if the player is moving on the Horizontal (X) axis
        if(Mathf.Abs(HorizontalRaw) == 1) {
            // Update animator to reflect change in X-position
            animator.SetFloat("MoveX", HorizontalRaw);
            animator.SetFloat("MoveY", 0);
            // Ensure player's desired location is not colliding with an object before continuing
            if(!Physics2D.OverlapCircle(moveTo.position + new Vector3(HorizontalRaw, 0f), 0.2f, collisionLayer)) {
                // Add the player's desired movement to their coordinates, changing position
                moveTo.position += new Vector3(HorizontalRaw, 0f);
            }
        }

        // Check if player is instead moving on the Vertical (Y) axis
        else if(Mathf.Abs(VerticalRaw) == 1) {
            // Update animator to reflect change in Y-position
            animator.SetFloat("MoveY", VerticalRaw);
            animator.SetFloat("MoveX", 0);
            // Ensure player's desired location is not colliding with an object before continuing
            if(!Physics2D.OverlapCircle(moveTo.position + new Vector3(0f, VerticalRaw), 0.2f, collisionLayer)) {
                // Add the player's desired movement to their coordinates, changing position
                moveTo.position += new Vector3(0f, VerticalRaw);
            }
        }
    }
    // If player has stopped moving (no new input), update animator to stop
    if(Mathf.Abs(VerticalRaw) == 0 && Mathf.Abs(HorizontalRaw) == 0) {
        animator.SetBool("isWalking", false);
    }
}
}