using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Скорость движения персонажа
    public float jumpForce;
    public float gravity = 9.8f;
    public float EnemysViewAngle;
    public float CameraViewAngle;
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
            EnemysViewAngle = 40;
            CameraViewAngle = 20;
            controller.height = 1f;
            moveSpeed = 2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            EnemysViewAngle = 70;
            CameraViewAngle = 30;
            controller.height = 2f;
            moveSpeed = 3f;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (controller.height == 2)
            {
                moveSpeed = 6f;
            }
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 3f;
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
