using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerController controller;

    public void RegisterMovement(InputAction.CallbackContext context)
    {
        controller.DoMovement(context.ReadValue<Vector2>()); 
    }
}
