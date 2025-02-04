using System.Collections;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [SerializeField] private float _attackReloadTime = 2.0f;

    private PlayerControls _playerControls;
    private Animator _anim;
    private bool _attackAvailable = true;
    private void Awake() {
        _anim = GetComponent<Animator>();
        _playerControls = new PlayerControls();
    }

    private void Start() {
        _playerControls.Combat.Attack.started += _ => Attack();
    }

    private void OnEnable() {
        _playerControls.Enable();
    }

    private void Attack() {
        if (_attackAvailable) StartCoroutine(IAttack());
    }

    private IEnumerator IAttack() {
        _anim.Play("Swing");
        _attackAvailable = false;
        yield return new WaitForSeconds(_attackReloadTime);
        _attackAvailable = true;
    }
}
