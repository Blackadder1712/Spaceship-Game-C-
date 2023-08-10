using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int pizzaReward = 25;
    [SerializeField] int pizzaPenalty = 25;    //rewards and fines for killing/not killing enemies 

    Bank bank;//access bank 
    void Start()
    {
        bank = FindObjectOfType<Bank>(); //access bank
    }

    public void RewardPizza() //add pizza points 
    {
        if(bank == null) {return;}
        bank.Deposit(pizzaReward);
    }

        public void StealPizza() //remove pizza points 
    {
        if(bank == null) {return;}
        bank.Withdraw(pizzaPenalty);
    }
}
