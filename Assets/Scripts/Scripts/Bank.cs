using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class Bank : MonoBehaviour
{

    [SerializeField] int startingBalance = 225;//create bank account

    [SerializeField] int currentBalance; //player balance

    public int CurrentBalance{get{return currentBalance;}}//access balance
    
    [SerializeField] TextMeshProUGUI displayBalance; //access UI

    [SerializeField] GameObject mothership;
    
    [SerializeField] float loadDelay = 0.5f;
    
    [SerializeField] GameObject head;
    
    [SerializeField] ParticleSystem dead;

    void Awake()
    {
      
        currentBalance = startingBalance;
        UpdateDisplay();//keep UI updates with score 
     
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount); //no negative numbers , balance is equal to amount add
        UpdateDisplay();//keep UI updates with score 
        
        if(currentBalance >= 200)
        {
            StartNextLevel();
        }
    }

    public void Withdraw(int amount)
    {
       currentBalance -= Mathf.Abs(amount); // remouve amount from currentbalance 
       UpdateDisplay();//keep UI updates with score 
       if(currentBalance < 0)
       {
         kill();
         
       } 

    }
    
    void UpdateDisplay()
    {
        displayBalance.text = "Fazcoins: " + currentBalance; //display balance in screen
      
    }

    void kill()
    {
        dead.Play();
       mothership.GetComponent<MeshRenderer>().enabled = false;
         head.GetComponent<MeshRenderer>().enabled = false;
               
         Invoke("ReloadScene", loadDelay);

    }
    void ReloadScene()//restart level on loss
    {
          
       Scene currentScene = SceneManager.GetActiveScene();//current scene variable 
       SceneManager.LoadScene(currentScene.buildIndex); // reload scene 
      
    }

    
    void StartNextLevel()
    {
       
     
        Invoke("NextLevel", loadDelay);
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

}
