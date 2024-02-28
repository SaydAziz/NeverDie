using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using System;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] TrinketManager tManager;

    public Vector3 GetCurrentMousePos()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        return mousePos;
    }

    public void RegisterNumber(InputAction.CallbackContext context)
    {
        string pressedButton = ((KeyControl)context.control).keyCode.ToString();
        pressedButton = pressedButton.Substring(pressedButton.Length - 1);

        controller.SelectTrinket(Int32.Parse(pressedButton));
    }

    public void RegisterMovement(InputAction.CallbackContext context)
    {
        controller.DoMovement(context.ReadValue<Vector2>()); 
    }

    public void RegisterMouseMove(InputAction.CallbackContext context)
    {
        tManager.UpdateCursorPos(context.ReadValue<Vector2>());

    }

    public void RegisterClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            controller.DoClick();
        }
    }
}
