using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotateThrust = 100f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();     
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(0,1,0 * mainThrust * Time.deltaTime);// framerate independent 
        }

    }

    
    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
           ApplyRotation(rotateThrust);
        }

         else if(Input.GetKey(KeyCode.D))  //not going left and right at same time
        {
           ApplyRotation(-rotateThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
         rb.freezeRotation =true; //stop natural rotation on collision
         transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);//rotate back
         rb.freezeRotation = false; //unfreezing rotation;
    }

}
