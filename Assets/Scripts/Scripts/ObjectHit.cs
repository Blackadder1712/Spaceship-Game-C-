using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
     [SerializeField] int pizza = 1; // increase score with 
     // [SerializeField] int hitPoints = 2; // 2 lives


      PizzaBoard pizzaBoard; //scoreboard reference 
  
    public GameObject player;
 

      MeshRenderer renderer;

    
  

      void Start()
      {
         pizzaBoard = FindObjectOfType<PizzaBoard>(); //sets and finds method scoreboard object 
          
         player = GameObject.Find("Player");

      
           
      renderer = GetComponent<MeshRenderer>();
     
        
      }
  
    private void OnCollisionEnter(Collision other) 
    {
        //change to red on collision 
           if(other.gameObject.name == "foxyRocket Variant")
           {
            pizzaHit();
            Debug.Log("Pizza");
           }
       
    }

        void pizzaHit() 
    {
            renderer.enabled = false;

             pizzaBoard.increaseScore(pizza); //increase by value in point variable 

        
             
              
    }



}
