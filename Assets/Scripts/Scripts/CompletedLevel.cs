using UnityEngine;
using UnityEngine.SceneManagement; //restarting/loading scene

public class CompletedLevel : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;

    [SerializeField] AudioClip Win;

     AudioSource Complete; // success sound

    [SerializeField] ParticleSystem WinParticles;

    bool isTransitioning = false;//stop audio on collision/explosion (true/false)
    bool collisionDisable = false; // turn collidors on and off 

    void Start()
    {
       Complete = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other) 
    {
         
            if(other.gameObject.tag == "Finish")
            {
                
                      Debug.Log("Congrats, yo, you finished!");
                        Complete.PlayOneShot(Win);
                        StartNextLevel();
                      
               
            }
                
                
         
    }

    

  

   


    void StartNextLevel()
    {
        isTransitioning = true;
        Complete.Stop(); //stop all audio on page load
        Complete.PlayOneShot(Win);
        WinParticles.Play();
     
        Invoke("NextLevel", levelLoadDelay);
    }



        void NextLevel()
    {
         int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
         int nextSceneIndex = currentSceneIndex + 1;
         if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)//loop through levels 
         {
            nextSceneIndex = 0;
         }

         SceneManager.LoadScene(nextSceneIndex); //load first level

    }


    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            NextLevel();
        }

        else if(Input.GetKeyDown(KeyCode.C))
        {
            collisionDisable = !collisionDisable; //toggle collision
        }
    }


}
