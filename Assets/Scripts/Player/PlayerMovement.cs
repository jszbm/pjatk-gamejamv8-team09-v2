using Assets.Scripts.Controllers;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float x_speed = 10;
    [SerializeField] private float base_y_speed = 3;
    [SerializeField] private float additional_y_speed = 5;
    private InputAction speedUpAction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        speedUpAction = InputHandler.Instance.InputActions.Movement.SpeedUp;
    }
   
    private void FixedUpdate()
    {
        var moveDirection = InputHandler.Instance.InputActions.Movement.Direction.ReadValue<float>();

        float final_y_speed = base_y_speed;

        if (speedUpAction.IsPressed())
        {
            final_y_speed += additional_y_speed;
        }
        
        rb.linearVelocity = new Vector3(moveDirection * x_speed, -final_y_speed, 0);
    }
}
