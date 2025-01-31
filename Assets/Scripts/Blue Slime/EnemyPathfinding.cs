using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2.0f;
    private Vector2 _moveDirection;

    private Rigidbody2D _rb;
    
    private void Awake() {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        _rb.MovePosition(_rb.position + _moveDirection * _moveSpeed * Time.fixedDeltaTime);
    }

    public void SetMovingDirection(Vector2 movingDirection) {
        _moveDirection = movingDirection;
    }
}
