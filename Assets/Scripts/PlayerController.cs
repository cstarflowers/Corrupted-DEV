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
    // DO NOT ADD AS CHILD OF PLAYER
}

public void Update()
{
    transform.position = Vector3.MoveTowards(transform.position, moveTo.position, speed * Time.deltaTime);

    // Continue only if the player's position has changed by greater than the value on the right (0.1f)
    if(Vector3.Distance(transform.position, moveTo.position) <= 0.1f) {

        // Check if the player is moving on the Horizontal (X) axis
        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1) {
            // Ensure player's desired location is not colliding with an object before continuing
            if(!Physics2D.OverlapCircle(moveTo.position + new Vector3(Input.GetAxisRaw("Horizontal"),0f), 0.2f,collisionLayer)) {
                // Add the player's desired movement to their coordinates, changing position
                moveTo.position += new Vector3(Input.GetAxisRaw("Horizontal"),0f);
            }
        }

        // Check if player is instead moving on the Vertical (Y) axis
        else if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1) {
            // Ensure player's desired location is not colliding with an object before continuing
            if(!Physics2D.OverlapCircle(moveTo.position + new Vector3(0f, Input.GetAxisRaw("Vertical")), 0.2f,collisionLayer)) {
                // Add the player's desired movement to their coordinates, changing position
                moveTo.position += new Vector3(0f, Input.GetAxisRaw("Vertical"));
            }
        }
    }
}
}