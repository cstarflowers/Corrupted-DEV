using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

public float speed;
public Rigidbody2D player;
public Animator animator;

public float verticalRaw;
private float verticalAbs;
public float horizontalRaw;
private float horizontalAbs;

void Start() {
    Application.targetFrameRate = 60;
    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

    // ORIGINAL CODE BY CG SMOOTHIE (https://www.youtube.com/watch?v=1YKfBh1FCWY)
    // WITH CODE FROM NIGHT RUN STUDIO (https://www.youtube.com/watch?v=d9bcmvr_Me4) 
    // WARNING: DO NOT ADD AS CHILD OF PLAYER
}

void Update() {
    verticalRaw = Input.GetAxisRaw("Vertical");
    horizontalRaw = Input.GetAxisRaw("Horizontal");
    verticalAbs = Mathf.Abs(verticalRaw);
    horizontalAbs = Mathf.Abs(horizontalRaw);
}

void FixedUpdate() {
    if (verticalAbs > 0 || horizontalAbs > 0) {
        animator.SetBool("isWalking", true);

        if (horizontalAbs == 1) {
            animator.SetFloat("MoveX", horizontalRaw);
            animator.SetFloat("MoveY", 0);
            player.AddForce(new Vector2(horizontalRaw * speed, 0));
        }

        else if (verticalAbs == 1) {
            animator.SetFloat("MoveY", verticalRaw);
            animator.SetFloat("MoveX", 0);
            player.AddForce(new Vector2(0, verticalRaw * speed));
            //verticalRaw = 0;
            }
        }

    else {
        animator.SetBool("isWalking", false);
    }
}
}