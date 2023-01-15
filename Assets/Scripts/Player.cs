using Photon.Pun;
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
    PlayerAttackGenerater attackGenerator;

    private void OnEnable()
    {
        playerInputController = GetComponentInParent<PlayerInputController>();
        playerMovementController = GetComponent<PlayerMovementController>();
        attackGenerator =GetComponent<PlayerAttackGenerater>();


    }
    private void Start()
    {
        playerInputController.playerActions.Movement.started += Move;
        playerInputController.playerActions.Movement.canceled += Move;
        playerInputController.playerActions.Jump.started += Jump;
        playerInputController.playerActions.Action.started += Fire;
    }

    private void Fire(InputAction.CallbackContext obj)
    {
        attackGenerator.Fire(playerMovementController.direction);
            }

    private void Jump(InputAction.CallbackContext obj)
    {
        playerMovementController.Jump();    
    }

    private void OnDisable()
    {
        playerMovementController = null;

    }

    private void Move(InputAction.CallbackContext obj)
    {
        playerMovementController.SetMoveDirection(obj.ReadValue<Vector2>());
    }
}
