using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

      [SerializeField] GameObject deathVFX;
      //[SerializeField] GameObject hitVFX;
 
   //   [SerializeField] int point = 1; // increase score with 
     // [SerializeField] int hitPoints = 2; // 2 lives

      //ScoreBoard scoreBoard; //scoreboard reference 
       // GameObject parentGameObject; //store explosion

      void Start() 
      {
         //scoreBoard = FindObjectOfType<ScoreBoard>(); //sets and finds method scoreboard object 
        //parentGameObject = GameObject.FindWithTag("SpawnAtRuntime"); // grabbing enemy explosion container 
         Rigidbody rb = gameObject.AddComponent<Rigidbody>();// store rigidbody added on play 
        // rb.useGravity = false; //turn off gravity
      }
   
       void OnParticleCollision(GameObject other) 
    {
       // ProcessHit();
        
       // if(hitPoints < 1) //only kill when run out of hitpoints
       // {
          KillEnemy();
       // }
    }

    void ProcessHit()
    {
        
        //GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        //vfx.transform.parent = parent; //explosion has parent and parent variable
      //hitPoints--; // lose 1 when hit 
      //vfx.transform.parent = parentGameObject.transform;
     // scoreBoard.increaseScore(point); //increase by value in point variable 
    }

    void KillEnemy()//dissapear and explode
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        //vfx.transform.parent = parentGameObject.transform; //explosion has parent and parent variable
        Destroy(gameObject);
        
    }

}
