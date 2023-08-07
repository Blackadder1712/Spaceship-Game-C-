using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscilation : MonoBehaviour
{

    Vector3 startingPosition; //starting position of object 
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor; // adds slider for movement control 
    [SerializeField] float period = 10f; //speed of rotation 
    void Start()
    {
        startingPosition = transform.position;
        Debug.Log(startingPosition);
    }

    // Update is called once per frame
    void Update()
    {
           if(period <= Mathf.Epsilon) //absolute 0
        {
           return;        
        }
         float cycles = Time.time / period;//measure time  
        const float tau = Mathf.PI * 2;//tau as a value is pie x2
        float rawSinWave = Mathf.Sin(cycles * tau);//sin value, F is input value of radians full circle , nomber of cycles / time it takes * tau
        // shows between the two transforms 
        movementFactor = (rawSinWave +1f) / 2f;//go back and forth 
        Vector3 offset = movementVector * movementFactor;//offset added to starting position
        transform.position = startingPosition + offset; //get new position
     
    
    }
}
