using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{

    [SerializeField] int startingBalance = 150;//create bank account

    [SerializeField] int currentBalance; //player balance

    public int CurrentBalance{get{return currentBalance;}}//access balance 

    void Awake()
    {
        currentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount); //no negative numbers , balance is equal to amount add
    }

    public void Withdraw(int amount)
    {
       currentBalance -= Mathf.Abs(amount); // remouve amount from currentbalance 

       if(currentBalance < 0)
       {
         ReloadScene();
       }//if run out of pizza game ends 
    }

    void ReloadScene()//restart level on loss
    {
       Scene currentScene = SceneManager.GetActiveScene();//current scene variable 
       SceneManager.LoadScene(currentScene.buildIndex); // reload scene 
    }

}
