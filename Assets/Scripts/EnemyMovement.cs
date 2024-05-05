using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D player;
    private float speed;
    private float distance;
    static private bool isColliding = false;
    void Start()
    {
        // Original code from MoreBBlakeyyy (https://www.youtube.com/watch?v=2SXa10ILJms)
        speed = (player.GetComponent<PlayerController>().speed / 10);
    }

    void Update()
    {
     distance = Vector2.Distance(transform.position, player.transform.position);
     Vector2 direction = (player.transform.position - transform.position);

     if((distance < 5 && !isColliding) && player.GetComponent<PlayerController>().enabled == true) {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
     }
    }

    void OnTriggerEnter2D(Collider2D player) {
        if(player.gameObject.tag == "Player") {
            isColliding = true;
            transform.position = Vector2.MoveTowards(this.transform.position, this.transform.position, 0);
            //Initiate.Fade(enemyLevel,Color.white,5);
            DialogueManager.startEnemyDialogue = true;
        }
        //else if(DialogueManager.inUse) {
        //    gameObject.SetActive(false);
        //}
    }

    void OnTriggerExit2D(Collider2D player) {
        if(player.gameObject.tag == "Player") {
            isColliding = false;
        }
    }
}
