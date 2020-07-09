using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Music_player : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene", 4f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
