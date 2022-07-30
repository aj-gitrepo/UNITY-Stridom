using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //for new Input System

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 30f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f; //based on aspect ratio
    void Start()
    {
        
    }

    void OnEnable() { //is a default unity function that comes After Awake in the order of execution
        movement.Enable(); //enabling this method on play
        Debug.Log("enabled");
    }

    void OnDisable() {
        movement.Disable();
        Debug.Log("disabled");
    }

    void Update()
    {

        // New Input System - after setting up the 2D Vector keys
        float xThrow = movement.ReadValue<Vector2>().x;
        float yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); //(val to be Clamped, minValue, maxValue)

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3 (clampedXPos, clampedYPos, transform.localPosition.z);
        
        // Old Input System
        // float xThrow = Input.GetAxis("Horizontal");
        // float yThrow = Input.GetAxis("Vertical");
        
    }
}
