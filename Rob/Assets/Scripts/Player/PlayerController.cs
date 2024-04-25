using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Скорость движения персонажа
    public float jumpForce;
    public float gravity = 9.8f;
    public UnityEvent OnTabPress;
    public UnityEvent OnTabRelease;

    private CharacterController controller;

    private float _fallVelocity = 0;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Получаем ввод от игрока
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Вычисляем направление движения
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        // Применяем гравитацию
        moveDirection.y -= gravity * Time.deltaTime;

        // Двигаем персонажа
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = 1f;
        }
        else
        {
            controller.height = 2f;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (controller.height == 2)
            {
                moveSpeed = 10f;
            }
        }
        else
        {
            moveSpeed = 5f;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OnTabPress.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            OnTabRelease.Invoke();
        }
    }
    void FixedUpdate()
    {
        _fallVelocity += gravity * Time.fixedDeltaTime;
        controller.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (controller.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
