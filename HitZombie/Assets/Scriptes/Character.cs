using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpHeight = 5f;
    [SerializeField] private float _rotationSpeed = 360f;
    [SerializeField] private Transform _groundCheckerPivot;
    [SerializeField] private float _checkGroundRadius = 0.4f;
    [SerializeField] private LayerMask _groundMask;

    private CharacterController _controller;
    private float _velocity;
    private Vector3 _moveDirection;
    private bool _isGrounded;
    public Transform _cameraTransform;
    public float yMaxLimit = 45.0f;
    public float yMinLimit = -50.0f;
    float rotationX = 0.0f;
    float rotationY = 0.0f;



    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        _isGrounded = IsOnTheGround();
        if (_isGrounded && _velocity < 0)
        {
            _velocity = -2f;
        }

        Move(_moveDirection);
        DoGravity();
    }
    private void Update()
    {

        //
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        _moveDirection = _cameraTransform.TransformDirection(_moveDirection);
        rotationX += Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;
        rotationY -= Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, yMinLimit, yMaxLimit);
        transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }
    private bool IsOnTheGround()
    {
        bool result = Physics.CheckSphere(_groundCheckerPivot.position, _checkGroundRadius, _groundMask);
        return result;
    }
    private void Move(Vector3 direction)
    {
        _controller.Move(direction * _speed * Time.fixedDeltaTime);
    }
    private void Jump()
    {
        _velocity = Mathf.Sqrt(_jumpHeight * -2 * _gravity);
    }
    private void DoGravity()
    {
        _velocity += _gravity * Time.fixedDeltaTime;

        _controller.Move(Vector3.up * _velocity * Time.fixedDeltaTime);
    }
}

