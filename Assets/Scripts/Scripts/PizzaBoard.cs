using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PizzaBoard : MonoBehaviour
{

    int pizzaScore; //score variable
    TextMeshProUGUI pizzaScoreText;

     void Start() 
    {
        
        pizzaScoreText = GetComponent<TextMeshProUGUI>();
     
    } 

    public void increaseScore(int amountToIncrease)
    {
        pizzaScore += amountToIncrease; // add points to current score 
        pizzaScoreText.text = pizzaScore.ToString();
        
    }


}
