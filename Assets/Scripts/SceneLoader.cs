using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string newLevel;
    public float delay;
    public float fadeSpeed;
    //public AudioSource interactSound;

    void LoadScene()
    {
        Application.targetFrameRate = 60;
        StartCoroutine(LoadLevelAfterDelay(delay));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Initiate.Fade(newLevel,Color.black,fadeSpeed);
         //interactSound.Play();
        }
    }

