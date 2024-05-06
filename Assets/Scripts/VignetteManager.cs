using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VignetteManager : MonoBehaviour
{
    public GameObject vignette, vignetteEffect;
    // Start is called before the first frame update
    void OnTriggerEnter2D (Collider2D hitbox) {
        if(hitbox.gameObject.tag == "Player" && this.gameObject.tag == "Vignette") {
            vignette.SetActive(false);
            vignetteEffect.SetActive(false);
        }
    }
    void OnTriggerExit2D (Collider2D hitbox) {
        if(hitbox.gameObject.tag == "Player" && this.gameObject.tag == "Vignette") {
            vignette.SetActive(true);
            vignetteEffect.SetActive(true);
        }
    }
}