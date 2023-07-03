using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour

{
    AudioSource boost;
    Rigidbody rb;
    [SerializeField] AudioClip Engine;
    
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotateThrust = 100f;

    
    [SerializeField] ParticleSystem leftParticles; //booster effects 
    [SerializeField] ParticleSystem rightParticles;
    [SerializeField] ParticleSystem mainParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();     
        boost = GetComponent<AudioSource>();
        
    }
    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        Thrusting();  //function on button press
    }

     void ProcessRotation()
    {
        Rotate(); // a button function

    }

    void Thrusting()
    {
         if(Input.GetKey(KeyCode.Space))
        {
            SpaceBar();// when press space bar 
        }
        else
        {
            StopThrusting();
                
        }
    }

        void Rotate() //when you press A
    {
        if(Input.GetKey(KeyCode.A))
        {
           PressA();

        }
            else if(Input.GetKey(KeyCode.D))  //not going left and right at same time
        {
           PressD();
        }
    }



    void SpaceBar()
    {
          rb.AddRelativeForce(0,1,0 * mainThrust * Time.deltaTime);// framerate independent 
        

            if(!mainParticles.isPlaying)
            {
              mainParticles.Play();
            }
            if(!boost.isPlaying)
            {
                boost.PlayOneShot(Engine);
            
            }       
                 
    }

        void StopThrusting()
    {
        boost.Stop();
        mainParticles.Stop();
    }

    
   


       void PressA()
       {
         ApplyRotation(-rotateThrust);
            
              mainParticles.Stop();
            
              if(!leftParticles.isPlaying)
           {
              leftParticles.Play();
           }
       }

       void PressD()
       {
           ApplyRotation(rotateThrust);
           if(!rightParticles.isPlaying)
           {
              rightParticles.Play();
           }

                 
              mainParticles.Stop();
       }


    void ApplyRotation(float rotationThisFrame)
    {
         rb.freezeRotation =true; //stop natural rotation on collision
         transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);//rotate back
         rb.freezeRotation = false; //unfreezing rotation;
    }
}


