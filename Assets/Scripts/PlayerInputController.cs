using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public InputControls inputActions;
    public InputControls.PlayerActions playerActions;
    

    private void Awake()
    {
        inputActions = new();
        playerActions = inputActions.Player;
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
