using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2.0f;
    private Rigidbody2D _rb;
    private PlayerControls _playerControls;
    private Animator _anim;
    private Transform _trans;
    private SpriteRenderer _spRen;

    private Vector2 _movementVector;

    private void Awake() {
        _rb = this.GetComponent<Rigidbody2D>();
        _playerControls = new PlayerControls();
        _anim = this.GetComponent<Animator>();
        _trans = this.GetComponent<Transform>();
        _spRen = this.GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        _playerControls.Enable();
    }

    private void Update() {
        GetInput();
    }

    private void FixedUpdate() {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void GetInput() {
        _movementVector = _playerControls.Movement.Move.ReadValue<Vector2>();
    }

    private void Move() {
        if (_movementVector.magnitude > .0f) 
            _anim.SetBool("isRunning",true); 
        else 
            _anim.SetBool("isRunning",false);

        _rb.MovePosition(_rb.position + _movementVector * _moveSpeed * Time.fixedDeltaTime);
    }

    private void AdjustPlayerFacingDirection() {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x < _trans.position.x) _spRen.flipX = true;
        else _spRen.flipX = false;
    }
}