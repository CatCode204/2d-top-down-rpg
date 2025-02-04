using UnityEngine;

public class HandScript : MonoBehaviour
{
    private Transform _playerTrans;
    private Transform _trans;

    private void Awake() {
        _playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _trans = GetComponent<Transform>();
    }

    private void Update() {
        FacingMouseDirection();
    }

    private void FacingMouseDirection() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - _playerTrans.position.y,mousePos.x - _playerTrans.position.x) * Mathf.Rad2Deg;

        if (mousePos.x < _playerTrans.position.x)
            _trans.rotation = Quaternion.Euler(0,180,180 - angle);
        else
            _trans.rotation = Quaternion.Euler(0,0,angle);
    }
}
