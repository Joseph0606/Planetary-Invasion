﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 50f;
    [Tooltip("In m")][SerializeField] float xRestriction = 20f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 50f;
    [Tooltip("In m")] [SerializeField] float yRestriction = 12f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -30f;

    [SerializeField] GameObject[] guns;

    float xThrow;
    float yThrow;
    bool isControlEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        { 
            XMovement();
            YMovement();
            ProcessRotation();
            ProcessFiring();
        }
    }

    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            GunsActive(true);
        }
        else
        {
            GunsActive(false);
        }
    }

    private void GunsActive(bool isActive)
    {
       foreach(GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }


        

    private void StopMovement()  //Called by string reference
    {
        isControlEnabled = false;
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow *controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;


        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void XMovement()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewX = transform.localPosition.x + xOffset;
        float xPosition = Mathf.Clamp(rawNewX, -xRestriction, xRestriction);

        transform.localPosition = new Vector3(xPosition, transform.localPosition.y, transform.localPosition.z);
    }

    private void YMovement()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewY = transform.localPosition.y + yOffset;
        float yPosition = Mathf.Clamp(rawNewY, -yRestriction, yRestriction);

        transform.localPosition = new Vector3(transform.localPosition.x, yPosition, transform.localPosition.z);
    }

}

