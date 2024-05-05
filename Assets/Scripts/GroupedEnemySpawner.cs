using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GroupedEnemySpawner : MonoBehaviour
{
    public Rigidbody2D player;
    public GameObject holdingObj;
    public GameObject healthProj;
    public GameObject config1, config2, config3;
    private int projectileCount = 0;
    public int maxProjectiles = 10;
    
    private int prevPosY = 4;
    private int projY;
    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerController>().enemyHealth > 0 && projectileCount < maxProjectiles) {
            int healPos = Random.Range(0,2);
            projY = Random.Range(4,8);
            Vector2 projPos = new Vector2(-4.3f, projY);
            if(Mathf.Abs(projY - prevPosY) > 2f) {
                switch(healPos) {
                    case 0:
                        StartCoroutine(DelayDestruction(Instantiate(config1, projPos, Quaternion.identity, holdingObj.transform)));
                        break;
                    case 1:
                        StartCoroutine(DelayDestruction(Instantiate(config2, projPos, Quaternion.identity, holdingObj.transform)));
                        break;
                    case 2:
                        StartCoroutine(DelayDestruction(Instantiate(config3, projPos, Quaternion.identity, holdingObj.transform)));
                        break;
                }
                prevPosY = projY;
                projectileCount += 1;
            }
        } 
    }
    IEnumerator DelayDestruction(GameObject proj) {
        yield return new WaitForSeconds(2.5f);
        Destroy(proj);
        projectileCount -= 1;
    }
}