using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    private enum State {
        ROAMING
    }

    private State _state;
    private EnemyPathfinding _enemyPathFinding;

    [Header("Settings")]
    [SerializeField] private float _romaingCycleTime = 2.0f;

    private void Awake() {
        _state = State.ROAMING;
        _enemyPathFinding = this.GetComponent<EnemyPathfinding>();
    }

    private void Start() {
        StartCoroutine(RoamingRountine());
    }

    private IEnumerator RoamingRountine() {
        while (_state == State.ROAMING) {
            ChangeRoamingDirection();
            yield return new WaitForSeconds(_romaingCycleTime);
        }
    }

    private void ChangeRoamingDirection() {
        Vector2 newDir = new Vector2(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f)).normalized;
        _enemyPathFinding.SetMovingDirection(newDir);
    }
}
