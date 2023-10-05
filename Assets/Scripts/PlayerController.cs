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

public void FixedUpdate()
{
    float verticalRaw = Input.GetAxisRaw("Vertical");
    float horizontalRaw = Input.GetAxisRaw("Horizontal");
    transform.position = Vector3.MoveTowards(transform.position, moveTo.position, speed * Time.deltaTime);

    if (Vector3.Distance(transform.position, moveTo.position) <= 0.1f) {
        animator.SetBool("isWalking", true);

        if (Mathf.Abs(horizontalRaw) == 1) {
            animator.SetFloat("MoveX", horizontalRaw);
            animator.SetFloat("MoveY", 0);
            if (!Physics2D.OverlapCircle(moveTo.position + new Vector3(horizontalRaw, 0f), 0.2f, collisionLayer)) {
                moveTo.position += new Vector3(horizontalRaw, 0f);
            }
        }

        else if (Mathf.Abs(verticalRaw) == 1) {
            animator.SetFloat("MoveY", verticalRaw);
            animator.SetFloat("MoveX", 0);
            if (!Physics2D.OverlapCircle(moveTo.position + new Vector3(0f, verticalRaw), 0.2f, collisionLayer)) {
                moveTo.position += new Vector3(0f, verticalRaw);
            }
        }
    }

    if (Mathf.Abs(verticalRaw) == 0 && Mathf.Abs(horizontalRaw) == 0) {
        animator.SetBool("isWalking", false);
    }
}
}