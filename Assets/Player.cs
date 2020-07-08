using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 50f;
    [Tooltip("In m")][SerializeField] float xRestriction = 20f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 50f;
    [Tooltip("In m")] [SerializeField] float yRestriction = 12f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNewX = transform.localPosition.x + xOffset;
        float xPosition = Mathf.Clamp(rawNewX, -xRestriction, xRestriction);

        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNewY = transform.localPosition.y + yOffset;
        float yPosition = Mathf.Clamp(rawNewY, -yRestriction, yRestriction);

        transform.localPosition = new Vector3(transform.localPosition.x, yPosition, transform.localPosition.z);
        transform.localPosition = new Vector3(xPosition, transform.localPosition.y, transform.localPosition.z);
    }
}
