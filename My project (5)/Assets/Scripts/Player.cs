using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float power = 0f;
    [SerializeField] private float turningRate;
    private Vector3 direction = new Vector3(0f, 0f, 1f);
    //assigned rotationAxis to Vector3.up which is the shorthand for writing Vector3(0, 1, 0)
    private Vector3 rotationAxis = Vector3.up;

    private PlayerInput actions;
    private InputAction movementAction;

    private void Awake()
    {
        actions = new PlayerInput();
        movementAction = actions.GameWorld.Movement;
    }

    void OnEnable()
    {
        movementAction.Enable();
    }

    void OnDisable()
    {
        movementAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input for movement and rotation
        float acceleration = movementAction.ReadValue<Vector2>().y;
        float turn = movementAction.ReadValue<Vector2>().x;

        // Move and rotate the object
        transform.Translate(direction * power * acceleration * Time.deltaTime, Space.Self);
        transform.Rotate(rotationAxis * turningRate * turn * Time.deltaTime, Space.Self);
    }
}
