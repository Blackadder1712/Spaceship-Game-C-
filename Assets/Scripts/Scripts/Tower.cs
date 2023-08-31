using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75; //cost of placing tower 
    [SerializeField] float buildDelay = 1;

    void Start()
    {
        StartCoroutine(Build());
    }

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

    IEnumerator Build()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false); //switch of turret parts 
            foreach(Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
        }

         foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true); //switch on turret parts 
            yield return new WaitForSeconds(buildDelay); // time it takes for turret to build 
            foreach(Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
        }
    }
}
