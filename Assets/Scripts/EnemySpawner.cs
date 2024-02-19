using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject projectile;
    private int projectileCount = 0;
    // Update is called once per frame
    void Update()
    {
        if(PlayerController.enemyHealth > 0 && projectileCount <= 10) {
            int randX = Random.Range(-47,10);
            int randY = Random.Range(40,275);

            Vector2 projPos = new Vector2(randX, randY);
            Instantiate(projectile, projPos, Quaternion.identity);
            projectileCount += 1;
        } 
    }
}
