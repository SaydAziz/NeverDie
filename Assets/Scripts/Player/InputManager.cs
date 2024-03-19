using System;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] TrinketManager tManager;

    private void Update()
    {
        tManager.UpdateCursorPos(Input.mousePosition);
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

    public void RegisterClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            controller.DoClick();
        }
    }
}
