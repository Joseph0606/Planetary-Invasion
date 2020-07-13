using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        NonTriggerBoxCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject explosion = Instantiate(deathFX, transform.position, Quaternion.identity);
        explosion.transform.parent = parent;
        Destroy(gameObject);
    }

    private void NonTriggerBoxCollider()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }
}
