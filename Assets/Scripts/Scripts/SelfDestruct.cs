using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update

    float timeToDestroy = 3f;
    void Start()
    {
      Destroy(gameObject, timeToDestroy);
    }

}
