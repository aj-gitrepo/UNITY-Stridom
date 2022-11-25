using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //for new Input System

public class PlayerControls : MonoBehaviour
{
    [Header("Movement input Keys")]
    [SerializeField] InputAction movement;
    [Header("Firing input Key")]
    [SerializeField] InputAction firing;
    [Header("Laser gun Array")]
    [Tooltip("Add all player lasers here")]
    [SerializeField] GameObject[] lasers;
    [Header("General Setup Settings")]
    [Tooltip("How fast the ship moves on Player Input")]
    [SerializeField] float controlSpeed = 30f;
    [Tooltip("How far player moves horizontally")]
    [SerializeField] float xRange = 10f;
    [Tooltip("How far player moves vertically")]
    [SerializeField] float yRange = 7f; //based on aspect ratio
    [Header("Screen position based Tuning")]
    [SerializeField] float positionPitchFactor = -2f; //derived by testing the up/down movement
    [SerializeField] float positionYawFactor = 2f;
    [Header("User Input based Tuning")]
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -20f;

    float yThrow, xThrow;

    void OnEnable() 
    { //is a default unity function that comes After Awake in the order of execution
        movement.Enable(); //enabling this method on play
        firing.Enable();
    }

    void OnDisable() 
    {
        movement.Disable();
        firing.Disable();
    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

  void ProcessRotation()
    {
        // position impacting pitch
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor ;

        // control input impacting pitch
        float pitchDueToControlFlow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlFlow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

  void ProcessTranslation()
    {
        // New Input System - after setting up the 2D Vector keys
        xThrow = movement.ReadValue<Vector2>().x;
        yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); //(val to be Clamped, minValue, maxValue)

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
         if(firing.IsPressed()) //or firing.ReadValue<float>() > 0.5
         {
            SetLayersActive(true);
         }
         else
         {
            SetLayersActive(false);
         }
    }

    void SetLayersActive(bool isActive)
    {
        foreach(GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }

}

// transform.localRotation = Quaternion.Euler(pitch, yaw, roll)
// transform.localRotation = Quaternion.Euler(  x  ,  y ,  z  )

// when moving up or down adjust the pitch
// when moving left or right ajust the yaw

// Old Input System
// float xThrow = Input.GetAxis("Horizontal");
// float yThrow = Input.GetAxis("Vertical");
// Input.GetButton('fire1')
