using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 8f;
    public float turnSmoothTime = 0.1f;

    [Header("Gravity Settings")]
    public float gravity = -9.81f;
    public float groundCheckDistance = 0.2f;
    public LayerMask groundMask;

    private CharacterController controller;
    private float turnSmoothVelocity;
    private float currentSpeed;
    private Vector3 velocity;
    private bool isGrounded;

    

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
        transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
    }

    void Update()
    {
        HandleMovement();
        //ApplyGravity();
        transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
    }

    private void HandleMovement()
    {
        transform.rotation = Quaternion.Euler(-90f, 0f, 0f);

        // Entrada del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Cambiar entre caminar y correr
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

        // Movimiento y rotación
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * currentSpeed * Time.deltaTime);
        }
    }

    private void ApplyGravity()
    {
        // Verifica si el personaje está en el suelo
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Mantener al personaje pegado al suelo
        }

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    
}

