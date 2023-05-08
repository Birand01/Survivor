using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void PlayerInputHandler(Vector3 movement);
    public static event PlayerInputHandler OnPlayerInput;


    [SerializeField] private DynamicJoystick dynamicJoystick;
    private Vector3 movementVector;

    private void FixedUpdate()
    {
        JoyStickMovement(movementVector);
    }

    private void JoyStickMovement(Vector3 moveVector)
    {
        moveVector = Vector3.zero;
        moveVector.x = dynamicJoystick.HorizontalAxis();
        moveVector.z = dynamicJoystick.VerticalAxis();
        OnPlayerInput?.Invoke(moveVector);

    }
}
