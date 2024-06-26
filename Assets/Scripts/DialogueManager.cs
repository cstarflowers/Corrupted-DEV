using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {
    private float delay = 0.04f;
    private string currentText = " ";

    public string[] dialogue;

    public TextMeshProUGUI textObject;
    // public AudioSource successSound;
    public GameObject dialogueBox;

    private bool isColliding;
    static public bool inUse = false;
    private int onText = 0;
    public Rigidbody2D player;

    private PlayerController movement;
    private Animator animator;

    static public bool startEnemyDialogue = false;

    void Start() {
        movement = player.GetComponent<PlayerController>();
        animator = player.GetComponent<Animator>();
    }

    void Update() {
        if((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) || startEnemyDialogue) {
            if(isColliding && !inUse) {
                if(onText == -1) {
                    onText = 0;
                }
                if(dialogue[onText].ToString() == "STOP") {
                    dialogueBox.SetActive(false);
                    movement.enabled = true;
                    onText = -1;
                    startEnemyDialogue = false;
                }
                else if(dialogue[onText].ToString() == "GOTO NEXT") {
                    dialogueBox.SetActive(false);
                    movement.enabled = true;
                    Initiate.Fade(dialogue[onText+1].ToString(),Color.black,30);
                    if(startEnemyDialogue) { 
                        Destroy(this.gameObject);
                    }
                    onText = 0;
                    startEnemyDialogue = false;
                }
                else {
                    if(startEnemyDialogue && onText > 0) {
                        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) {
                            StartCoroutine(showText(dialogue[onText]));
                            inUse = true;
                            onText += 1;
                        }                        
                    }
                    else {
                        StartCoroutine(showText(dialogue[onText]));
                        inUse = true;
                        onText += 1;
                    }
                }
            }
        }
    }

    public IEnumerator showText(string displayText) {
        currentText = " ";
        // successSound.Play();
        disableMovement();
        dialogueBox.SetActive(true);
        for(int i = 0; i <= displayText.Length; i++) {
            currentText = displayText.Substring(0,i);
            textObject.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        inUse = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" || (startEnemyDialogue && this.gameObject.tag != "NPC")) {
            isColliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player" || (startEnemyDialogue && this.gameObject.tag != "NPC")) {
            isColliding = false;
            dialogueBox.SetActive(false);
            movement.enabled = true;
            onText = 0;
        }
    }

    void disableMovement() {
        player.velocity = new Vector2(0,0);
        movement.enabled = false;
        animator.SetBool("isWalking", false);
    }
}