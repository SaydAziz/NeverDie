using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    public void ReadMovement(InputAction.CallbackContext context)
    {
        controller.DoMove(context.ReadValue<Vector2>());
    }
    void ReadShoot(InputAction.CallbackContext context)
    {

    }

}
