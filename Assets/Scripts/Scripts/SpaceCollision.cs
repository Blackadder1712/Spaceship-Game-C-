using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //restarting/loading scene

public class SpaceCollision : MonoBehaviour
{
   [SerializeField] float loadDelay = 1f;
   [SerializeField] ParticleSystem crashed ;

   public GameObject hand;
   public GameObject boddy;
   public GameObject boddybelt;
   public GameObject head;
   public GameObject nozzle;
   public GameObject nute;
  
   public GameObject mask;

  

 
  void OnCollisionEnter(Collision other)
   {
      if(other.gameObject.tag == "Enemy")
      {
         StartCrashSequence();
      }
   }

      void StartCrashSequence()
    {
       /* isTransitioning = true;
        bang.Stop();//stop after crash
        bang.PlayOneShot(Explode);
        ExplodeParticles.Play();*/
         Debug.Log("ouch");
         
         crashed.Play();// play explosion effect 
        GetComponent<PlayerController>().enabled = false;//remove control
        hand.GetComponent<MeshRenderer>().enabled =false;
        boddy.GetComponent<MeshRenderer>().enabled =false;
        boddybelt.GetComponent<MeshRenderer>().enabled =false;
        head.GetComponent<MeshRenderer>().enabled =false;
        nozzle.GetComponent<MeshRenderer>().enabled =false;
        nute.GetComponent<MeshRenderer>().enabled =false;
      
        mask.GetComponent<MeshRenderer>().enabled =false;
   
       
         Invoke("ReloadLevel", loadDelay);
        
        

    }


     void ReloadLevel()//reloads level on fail 
    {
       
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//return index of current scene
    }
}
