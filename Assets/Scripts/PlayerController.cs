using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour {

public string nextLevel;
public TextMeshProUGUI healthText;
public TextMeshProUGUI enemyDamageText;
public int health = 100;
public int enemyHealth = 999;
private int enemyDamage = 0;
public float speed;
public Rigidbody2D player;
public Animator animator;

public float verticalRaw;
private float verticalAbs;
public float horizontalRaw;
private float horizontalAbs;

private int baseEnemyHealth;

void Start() {
    Application.targetFrameRate = 60;
    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

    baseEnemyHealth = enemyHealth;
    if(enemyDamageText != null) {
        enemyDamageText.text = "Enemy HP:" + enemyHealth.ToString() + "/" + baseEnemyHealth.ToString();
    }
    if(healthText != null) {
        healthText.text = "HP:" + health + "/100";
    }

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
            }
        }

    else {
        animator.SetBool("isWalking", false);
    }
}

void OnTriggerEnter2D(Collider2D enemy) {
    if(enemy.gameObject.tag == "Enemy") {
        health -= 20;
        if(healthText != null) {
            healthText.text = "HP:" + health + "/100";
        }
        if(health <= 0) {
            this.enabled = false;
            Initiate.Fade("CombatDemo",Color.white,5);
        }
    }
    else if(enemy.gameObject.tag == "AttackPoint") {
        enemyDamage = health / 2;
        enemyHealth -= enemyDamage;
        // Debug.Log("[Debug] Enemy HP: " + enemyHealth + "/" + baseEnemyHealth + " (" + enemyDamage + " damage)");

        if(enemyDamageText != null) {
            enemyDamageText.text = "Enemy HP:" + enemyHealth.ToString() + "/" + baseEnemyHealth.ToString();
        }
        if(enemyHealth <= 0) {
            this.enabled = false;
            Initiate.Fade(nextLevel,Color.black,5);
        }
    }
}
}