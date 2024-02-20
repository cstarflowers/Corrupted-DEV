using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public Rigidbody2D player;
    public GameObject holdingObj;
    public GameObject projectile;
    public GameObject healthProj;
    private int projectileCount = 0;
    public int maxProjectiles = 10;
    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerController>().enemyHealth > 0 && projectileCount < maxProjectiles) {
            int healChance = Random.Range(0,5);

            Vector2 projPos = new Vector2(Random.Range(-6,0), Random.Range(4,12));
            // Debug.Log("spawning at " + projPos.ToString());
            if(healChance < 4) {
                StartCoroutine(DelayDestruction(Instantiate(projectile, projPos, Quaternion.identity, holdingObj.transform)));
            }
            else {
                StartCoroutine(DelayDestruction(Instantiate(healthProj, projPos, Quaternion.identity, holdingObj.transform)));
            }
            projectileCount += 1;
        } 
    }
    IEnumerator DelayDestruction(GameObject proj) {
        yield return new WaitForSeconds(3);
        Destroy(proj);
        projectileCount -= 1;
    }
}
