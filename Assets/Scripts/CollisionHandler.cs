using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        Debug.Log("done");
        switch (other.gameObject.tag)
        {
            case "friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                Debug.Log("Congrats, yo, you finished!");
                break;
            case "Fuel":
                Debug.Log("You picked up fuel");
                break;
            default:
                Debug.Log("Sorry, you blew up!");
                break;
        }
    }
}
