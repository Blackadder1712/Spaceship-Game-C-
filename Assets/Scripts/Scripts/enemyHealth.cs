using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Enemy))] //component gets added with script
public class enemyHealth : MonoBehaviour
{
     int maxHitPoints = 7;

    [Tooltip("Add amount to enemy heath")]
     int difficultyRamp = 4;//enemy health increase
     int currentHitPoints = 0; //store hit points 
    
  
        
    Enemy enemy;
    // Start is called before the first frame update
    void OnEnable() // fresh hitpoints 
    {
        currentHitPoints = maxHitPoints;
       
    }



    void Start()
    {
        enemy = GetComponent<Enemy>(); // access enemy 
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
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;//increase enemy health
            enemy.RewardPizza(); //if enemy killed reward player pizzapoints
        }
         
     
    }


}
