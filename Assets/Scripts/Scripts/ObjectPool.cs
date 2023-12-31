using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f; //one enemy per second , control spawning rate 
    [SerializeField] [Range(0, 50)]int poolSize = 5; //holds 5 enemies /limit to 0-50

    GameObject[] pool; //hold destroyed enemies 

    void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);//put enemies in pool array
            pool[i].SetActive(false);//destroy enemy
        }
    }

    void EnableObjectInPool()
    {
        for(int i = 0; i < pool.Length; i++)
        {
           if(pool[i].activeInHierarchy == false)
           {
             pool[i].SetActive(true); //if enemy in heirachy inactive toggle active
             return;
           } 
        }
    }

    IEnumerator SpawnEnemy() //place enemy on field
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

}
