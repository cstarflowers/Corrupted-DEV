using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CircleEnemySpawner : MonoBehaviour {
    public Rigidbody2D player;
    public GameObject holdingObj;
    public GameObject healthProj;
    public GameObject config1, config2;
    private Vector2 projPos;
    private int projectileCount = 0;
    public int maxProjectiles = 10;
    
    void Update() {
        if(player.GetComponent<PlayerController>().enemyHealth > 0 && projectileCount < maxProjectiles) {
            int healChance = Random.Range(0,2);
            int rotation = Random.Range(0,3);

            switch(rotation) {
                case 0: 
                    projPos = new Vector2(-7.1f, 6);
                    break;
                case 1:
                    projPos = new Vector2(-4.2f, 6);
                    break;
                case 2:
                    projPos = new Vector2(-1.8f, 6);
                    break;
            }
            
            if(healChance == 0) {
                StartCoroutine(DelayDestruction(Instantiate(config1, projPos, Quaternion.identity, holdingObj.transform)));
            }
            else {
                StartCoroutine(DelayDestruction(Instantiate(config2, projPos, Quaternion.identity, holdingObj.transform)));
            }
            projectileCount += 1; 
        }
    }

    IEnumerator DelayDestruction(GameObject proj) {
        yield return new WaitForSeconds(2.5f);
        Destroy(proj);
        projectileCount -= 1;
    }
}