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
    


    void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();//keep UI updates with score 
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount); //no negative numbers , balance is equal to amount add
        UpdateDisplay();//keep UI updates with score 
    }

    public void Withdraw(int amount)
    {
       currentBalance -= Mathf.Abs(amount); // remouve amount from currentbalance 
       UpdateDisplay();//keep UI updates with score 
       if(currentBalance < 0)
       {
         ReloadScene();
       }//if run out of pizza game ends 
    }
    
    void UpdateDisplay()
    {
        displayBalance.text = "Fazcoins: " + currentBalance; //display balance in screen

    }
    void ReloadScene()//restart level on loss
    {
       Scene currentScene = SceneManager.GetActiveScene();//current scene variable 
       SceneManager.LoadScene(currentScene.buildIndex); // reload scene 
    }

}
