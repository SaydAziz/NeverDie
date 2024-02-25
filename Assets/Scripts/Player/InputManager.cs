using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

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
