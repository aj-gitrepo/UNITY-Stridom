using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //for new Input System

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
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
        float horizontalThrow = movement.ReadValue<Vector2>().x;
        Debug.Log(horizontalThrow);
        
        float verticalThrow = movement.ReadValue<Vector2>().y;
        Debug.Log(verticalThrow);
        
        // Old Input System
        // float horizontalThrow = Input.GetAxis("Horizontal");
        // float verticalThrow = Input.GetAxis("Vertical");
        
    }
}
