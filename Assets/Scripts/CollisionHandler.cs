using UnityEngine;
using UnityEngine.SceneManagement; //restarting/loading scene

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip Explode;
    [SerializeField] AudioClip Win;
     AudioSource bang; // fail sound 
     AudioSource Complete; // success sound

    [SerializeField] ParticleSystem ExplodeParticles; //explosion effects 
    [SerializeField] ParticleSystem WinParticles;

    bool isTransitioning = false;//stop audio on collision/explosion (true/false)

    void Start()
    {
       bang = GetComponent<AudioSource>();   
       Complete = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other) 
    {
            if(!isTransitioning) //only if sounds not already active 
        {
            
            switch (other.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("This thing is friendly");
                    break;
                case "Finish":
                      Debug.Log("Congrats, yo, you finished!");
                        Complete.PlayOneShot(Win);
                        StartNextLevel();
                        break;
                case "Fuel":
                     Debug.Log("You picked up fuel");
                     break;
                default:
                    Debug.Log("Sorry, you blew up!");
                    StartCrashSequence();// 1 sec delay
                
                    break;
            }

        }   
    }

   


    void StartNextLevel()
    {
        isTransitioning = true;
        Complete.Stop(); //stop all audio on page load
        Complete.PlayOneShot(Win);
        WinParticles.Play();
         GetComponent<movement>().enabled = false;
        Invoke("NextLevel", levelLoadDelay);
    }


    void StartCrashSequence()
    {
        isTransitioning = true;
        bang.Stop();//stop after crash
        bang.PlayOneShot(Explode);
        ExplodeParticles.Play();
        GetComponent<movement>().enabled = false;//remove control
         Invoke("ReloadLevel", levelLoadDelay);

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

    void ReloadLevel()//reloads level on fail 
    {
       
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//return index of current scene
    }



}
