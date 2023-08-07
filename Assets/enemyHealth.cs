using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int currentHitPoints = 0; //store hit points 
    // Start is called before the first frame update
    void Start()
    {
        currentHitPoints = maxHitPoints;
    }

    void OnParticleCollision(GameObject other)//when shot hits enemy
    {
        ProcessHit();
       
    }

    void ProcessHit()
    {
        currentHitPoints--; //remove point with collision 

        if(currentHitPoints <= 0) //enemy dies when points hit 0
        {
            Destroy(gameObject);
     
        }
    }
}
