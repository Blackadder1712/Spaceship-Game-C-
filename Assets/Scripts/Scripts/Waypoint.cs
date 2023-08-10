using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;//connect to tower script/object
   
    [SerializeField] bool isPlacable; // only place on land/ unoccupied tile

    public bool IsPlacable{get{ return isPlacable;}} //return variable

  
    void OnMouseDown()//if hovering
    {
        if(isPlacable) //if tower can be placed set bool to true 
        {
               
                bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position); //get the position of the tower and initiate method 
                isPlacable = !isPlaced;//tiles not blocked if turret cant be placed
                        
        }
       
    }
}
