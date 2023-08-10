using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles; //enemy explode effect when ihit in range 
    [SerializeField] float range = 15f;//turret range
    Transform target;

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
      Enemy[] enemies = FindObjectsOfType<Enemy>(); //compare distances of enemies in array
      Transform closestTarget = null;
      float maxDistance = Mathf.Infinity; //registers any distance

      foreach(Enemy enemy in enemies)
      {
        float targetDistance = Vector3.Distance(transform.position, enemy.transform.position); // check distance between enemy and turret
        
        if(targetDistance < maxDistance) // compare distance of enemies 
        {
            closestTarget = enemy.transform;
            maxDistance = targetDistance;
        }

        target = closestTarget;
      }
    }

    void AimWeapon()
    {
       float targetDistance = Vector3.Distance(transform.position, target.position);//check if enemy is in range of tower 

       weapon.LookAt(target); //rotate turret 

       if(targetDistance < range)
       {
        Attack(true); //if in range fire particle system
       }
       else
       {
        Attack(false); //dont fire 
       }
    }
    
    void Attack(bool isActive) //only shoot if enemy in range
    {
        var emissionModule = projectileParticles.emission; //particle system in variable 
        emissionModule.enabled = isActive; // enable variable 
    }


}
