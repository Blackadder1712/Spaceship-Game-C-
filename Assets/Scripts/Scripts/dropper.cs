using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropper : MonoBehaviour
{
    MeshRenderer renderer;
    Rigidbody Body;
      bool collisionDisable = false; // turn collidors on and off 
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
      
     
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player" && !collisionDisable) //|| collisionDisable)
        {    
           this.gameObject.SetActive(false);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
      
          if(Input.GetKeyDown(KeyCode.C))
        {
                collisionDisable = !collisionDisable; //toggle collision
        }
    }
}
