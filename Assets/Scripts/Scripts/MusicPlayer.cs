using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
  void Awake()
  {
    int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;//check how many Musicplayers have been created in the array

    if(numMusicPlayers > 1)
    {
        Destroy(gameObject); //only have one musicplayer
    }
    else
    {
        DontDestroyOnLoad(gameObject); // dont delete or restart original track 
    }
  }
}
