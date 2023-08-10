using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75; //cost of placing tower 

    public bool CreateTower(Tower tower, Vector3 position) //depending on bank balance 
    {
        Bank bank = FindObjectOfType<Bank>();//access player bank 

        if(bank == null)
        {
            return false;
        }

        if(bank.CurrentBalance >= cost)//if player has enough money 
        {
            Instantiate(tower, position, Quaternion.identity); //build tower in correct position
            bank.Withdraw(cost); // pay for turret
            return true;
        }

        return false;//if no conditions met 
     
    }
}
