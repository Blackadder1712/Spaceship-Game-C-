using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject turret;
    [SerializeField] bool isPlacable; // only place on land/ unoccupied tile

    public bool IsPlacable{get{ return isPlacable;}} //return variable

  
    void OnMouseDown()//if hovering
    {
        if(isPlacable)
        {
           
                Instantiate(turret, transform.position, Quaternion.identity);//place turret 
                isPlacable = false;
                        
        }
       
    }
}
