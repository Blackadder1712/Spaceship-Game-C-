using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("General Setup Settings")] // header in inspector
     
    [Tooltip("How fast ship moves up and down based upon player input")]//appears on hover 
    
    [SerializeField] float controlSpeed = 10f;

    [Tooltip("Range of movement on screen")]

    [SerializeField] float xRange = 100f;

    [SerializeField] float yRange = 30f;

    [Tooltip("Array of accessible laser objects")]

    [SerializeField] GameObject[] lasers; //array of lasers 

   
    [Header("Screen Position settings")] // header in inspector
    
    [SerializeField] float positionPitchFactor = 2f; //rotate from 

    [SerializeField] float controlPitchFactor = -10f;

    [SerializeField] float positionYawFactor = 5f;
   
     float xThrow, yThrow;

      [Tooltip("laser sound effect")]

      public AudioSource shoot;

      public AudioClip spacelasers;

   


    // Update is called once per frame
    void Update()
    {

        ShipControls();
        //ShipRotate();
        ProcessFiring();//shoot laser on button press

     
    }

    void ProcessFiring()
    {
        if(Input.GetButton("Fire1"))
        {
            ActivateLaser(true);
            Debug.Log("shot");
           if(!shoot.isPlaying)
           {
            shoot.PlayOneShot(spacelasers);
           }
        }
        else
        {
            ActivateLaser(false);
            Debug.Log("nope");
        }
         
    }

    void ActivateLaser(bool isActive)
    {
       foreach (GameObject laser in lasers)//turn each laser in array on
       {
           var emissionModule = laser.GetComponent<ParticleSystem>().emission; //disable emmision variable 
           emissionModule.enabled = isActive; //if bool is true
          
   

       }  
    }


    

    void ShipControls()
    {
       float xThrow = Input.GetAxis("Horizontal"); // control stored in movement variable 
       float yThrow = Input.GetAxis("Vertical"); // control stored in movement variable
       

       float xOffset = xThrow * Time.deltaTime * controlSpeed;
       float rawXPos = transform.localPosition.x + xOffset; //move left and right, no restriction
       float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); // stops ship going out of screen
       
       float yOffset = yThrow * Time.deltaTime * controlSpeed;
       float rawYPos = transform.localPosition.y + yOffset; //move left and right, no restriction 
       float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange); // stops ship going out of screen

       transform.localPosition = new Vector3 (clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ShipRotate()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = -90f;//transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor; //180f;
        float roll = -180f;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll); //angled position
    }

 

 
   
     
    
}
