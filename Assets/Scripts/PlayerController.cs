using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float _moveSpeed = 1f;

    PlayerControls _playerControls;
    Vector2 _movement;
    Rigidbody2D _rbody;

    private void Awake()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void PlayerInput()
    {
        _movement = _playerControls.Movement.Move.ReadValue<Vector2>();
    }

    void Move()
    {
        _rbody.MovePosition(_rbody.position + _movement * (_moveSpeed * Time.fixedDeltaTime));
    }
}
