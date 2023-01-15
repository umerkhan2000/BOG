using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    PlayerMovementController playerMovementController;
    PlayerInputController playerInputController;

    private void OnEnable()
    {
        playerInputController = GetComponentInParent<PlayerInputController>();
        playerMovementController = GetComponent<PlayerMovementController>();
       
    }
    private void Start()
    {
        playerInputController.playerActions.Movement.started += Move;
        playerInputController.playerActions.Movement.canceled += Move;
        playerInputController.playerActions.Jump.started += Jump;
    }
    private void Jump(InputAction.CallbackContext obj)
    {
        playerMovementController.Jump();    
    }

    private void OnDisable()
    {
        playerMovementController = null;

        //playerInputController.playerActions.Movement.canceled -= Move;

    }

    private void Move(InputAction.CallbackContext obj)
    {
        playerMovementController.SetMoveDirection(obj.ReadValue<Vector2>());
    }
}
