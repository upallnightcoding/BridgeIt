using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public static event Action<Vector2> OnSelection = delegate {};

    private InputActions inputActions;

    private void Awake()
    {
        inputActions = new InputActions();    
    }

    private void Select(InputAction.CallbackContext mouse)
    {
        OnSelection.Invoke(Mouse.current.position.ReadValue());
    }

    private void OnEnable() 
    {
        inputActions.Player.Select.performed += Select;

        inputActions.Player.Enable();
    }

    private void OnDisable() 
    {
        inputActions.Player.Select.performed -= Select;
        
        inputActions.Player.Disable();
    }

}
