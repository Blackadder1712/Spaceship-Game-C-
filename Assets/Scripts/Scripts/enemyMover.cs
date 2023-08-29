using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] //auto add enemy scripts 

public class enemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();// array of waypoints
    [SerializeField] [Range(0f, 5f)]float speed = 2f; //adjust enemy speed within limits
    Enemy enemy; // access enemy 
    void OnEnable()//call everytime enemy is called
    {   
        FindPath();   
        ReturnToStart();
        StartCoroutine(FollowPath()); //start timed event 
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();//ready for new path

        GameObject parent = GameObject.FindGameObjectWithTag("Path");//put objects with path tag in array

        foreach(Transform child in parent.transform)//put list items in array
        {
            path.Add(child.GetComponent<Waypoint>()); //get waypoint compnent on object
        }
        
    }//find tile path

    void ReturnToStart()
    {
      
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {      
        enemy.StealPizza(); //if enemy reaches end steal pizza 
        gameObject.SetActive(false); // remove enemy from hierachy 
    }

    IEnumerator FollowPath() //returns countable value
    {
        foreach(Waypoint waypoint in path)  
        {
            Vector3 startPosition = transform.position;//smoother motion
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            //rotate in correct direction
            transform.LookAt(endPosition);
            
            while(travelPercent < 1f)//update travel position
            {
                travelPercent += Time.deltaTime * speed; //add time to travel percent * by speed variable 
                transform.position= Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame(); //value goes into method 
            }
           
        }

        FinishPath();

    }

   
}
