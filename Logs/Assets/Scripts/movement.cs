using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float mainThrust = 100f;

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
            transform.Rotate(Vector3.forward);//rotate back
        }

         else if(Input.GetKey(KeyCode.D))  //not going left and right at same time
        {
          transform.Rotate(Vector3.back);//rotate forward
        }
    }

}
