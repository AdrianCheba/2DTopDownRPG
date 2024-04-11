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
    Animator _playerAnimator;
    SpriteRenderer _playerSpriteRenderer;

    private void Awake()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _playerControls = new PlayerControls();
        _playerAnimator = GetComponent<Animator>();
        _playerSpriteRenderer = GetComponent<SpriteRenderer>();
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
        AdjustPlayerFacingDirection();
        Move();
    }

    void PlayerInput()
    {
        _movement = _playerControls.Movement.Move.ReadValue<Vector2>();

        _playerAnimator.SetFloat("moveX", _movement.x);
        _playerAnimator.SetFloat("moveY", _movement.y);
    }

    void Move()
    {
        _rbody.MovePosition(_rbody.position + _movement * (_moveSpeed * Time.fixedDeltaTime));
    }

    void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if(mousePos.x < playerScreenPoint.x)
            _playerSpriteRenderer.flipX = true;
        else
            _playerSpriteRenderer.flipX = false;
    }
}
