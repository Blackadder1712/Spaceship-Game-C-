using UnityEngine;
using UnityEngine.SceneManagement; //restarting/loading scene

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] AudioClip Explode;
    [SerializeField] AudioClip Win;
     AudioSource bang;
     AudioSource Complete;
    void Start()
    {
       bang = GetComponent<AudioSource>();   
       Complete = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other) 
    {
        Debug.Log("done");
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

    void StartCrashSequence()
    {
        bang.PlayOneShot(Explode);
        GetComponent<movement>().enabled = false;//remove control
         Invoke("ReloadLevel", levelLoadDelay);

    }

    void ReloadLevel()//reloads level on fail 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//return index of current scene
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

    void StartNextLevel()
    {
         GetComponent<movement>().enabled = false;
        Invoke("NextLevel", levelLoadDelay);
    }
}
