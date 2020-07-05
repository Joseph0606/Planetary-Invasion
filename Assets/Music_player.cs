using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Music_player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("LoadFirstScene", 4f);
    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
