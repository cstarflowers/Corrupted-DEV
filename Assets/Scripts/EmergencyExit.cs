using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmergencyExit : MonoBehaviour
{
public Rigidbody2D player;

public string newLevel;

void Update() {
    /*string sceneName = SceneManager.GetActiveScene().name.ToString();
    if (sceneName == "BossDemo_Stage1" || sceneName == "BossDemo_Stage2")) {}*/
    if(Input.GetKeyDown(KeyCode.Escape)) {
        Initiate.Fade(newLevel,Color.black,20);
    }
}
}