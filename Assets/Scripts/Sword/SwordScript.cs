using System.Collections;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    [SerializeField] private float _attackReloadTime = 2.0f;
    [SerializeField] private GameObject _swordObject;
    [SerializeField] private GameObject _handObject;

    private HandScript _handScript;

    private PlayerControls _playerControls;
    private Animator _swordAnim;
    private bool _attackAvailable = true;
    private void Awake() {
        _swordAnim = _swordObject.GetComponent<Animator>();
        _playerControls = new PlayerControls();
        _handScript = _handObject.GetComponent<HandScript>();
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
        _swordAnim.Play("Swing");
        _handScript.DisableRotateHand();
        _attackAvailable = false;
        yield return new WaitForSeconds(_attackReloadTime);
        _handScript.EnableRotateHand();
        _attackAvailable = true;
    }

    public void SetHandObject(GameObject handObject) {
        _handObject = handObject;
        _handScript = _handObject.GetComponent<HandScript>();
    }
}