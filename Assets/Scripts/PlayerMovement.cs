using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float _moveSpeed = 2.0f;
    private Rigidbody2D _rb;
    private PlayerControls _playerControls;

    private Vector2 _movementVector;

    private void Awake() {
        _rb = this.GetComponent<Rigidbody2D>();
        _playerControls = new PlayerControls();
    }

    private void OnEnable() {
        _playerControls.Enable();
    }

    private void Update() {
        GetInput();
    }

    private void FixedUpdate() {
        Move();
    }

    private void GetInput() {
        _movementVector = _playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move() {
        _rb.MovePosition(_rb.position + _movementVector * _moveSpeed * Time.fixedDeltaTime);
    }
}
