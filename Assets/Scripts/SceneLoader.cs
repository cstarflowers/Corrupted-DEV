using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    private int onText = 0;
    private bool inUse = false;
    private bool isPrinting = false;
    private float textDelay = 0.04f;
    private string currentText = " ";

    public string[] dialogue;
    public TextMeshProUGUI textObject;
    // public AudioSource successSound;
    public GameObject dialogueBox;


    public string newLevel;
    public float delay;
    public float fadeSpeed;
    //public AudioSource interactSound;

    void LoadScene() {
        Application.targetFrameRate = 60;
        if(inUse == false) {
            if(dialogue[onText].ToString() == "STOP") {
                dialogueBox.SetActive(false);
                onText = 0;
                StartCoroutine(LoadLevelAfterDelay(delay));
            }
            else {
                StartCoroutine(showText(dialogue[onText]));
                onText += 1;
                inUse = true;
            }
        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) {
            if(dialogue[onText].ToString() == "STOP") {
                dialogueBox.SetActive(false);
                onText = 0;
                StartCoroutine(LoadLevelAfterDelay(delay));
            }
            else if(isPrinting == false) {
                StartCoroutine(showText(dialogue[onText]));
                onText += 1;
            }
        }
    }

    public IEnumerator showText(string displayText) {
        isPrinting = true;
        currentText = " ";
        // successSound.Play();
        dialogueBox.SetActive(true);
        for(int i = 0; i <= displayText.Length; i++) {
            currentText = displayText.Substring(0,i);
            textObject.text = currentText;
            yield return new WaitForSeconds(textDelay);
        }
        isPrinting = false;
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Initiate.Fade(newLevel,Color.black,fadeSpeed);
         //interactSound.Play();
        }
    }