using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Ok as long as it is the only script that loads scenes

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("Seconds")] [SerializeField] float levelLoadDelay = 2f;
    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Player triggered something");
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        Invoke("ReloadLevel", levelLoadDelay);
        deathFX.SetActive(true);
        gameObject.SendMessage("StopMovement");
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
