using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Music_player : MonoBehaviour
{
    private void Awake()
    {
        int numMusicPlayer = FindObjectsOfType<Music_player>().Length;
        if (numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

    // Start is called before the first frame update

