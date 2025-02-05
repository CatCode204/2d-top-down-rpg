using UnityEngine;

public class SwordSlashCaller : MonoBehaviour {
    [SerializeField] private GameObject _slashObject;
    [SerializeField] private GameObject _hitboxObject;

    private Animator _slashAnim;

    private void Awake() {
        _slashAnim = _slashObject.GetComponent<Animator>();
    }

    private void Start() {
        _slashObject.SetActive(false);
    }

    public void PlaySlashAnimation() {
        _slashObject.SetActive(true);
        _slashAnim.Play("Slash_Effect");
    }

    public void StopSlashAnimation() {
        _slashAnim.Play("Entry");
        _slashObject.SetActive(false);
    }

    public void EnableHitbox() {
        _hitboxObject.SetActive(true);
    }

    public void DisableHitbox() {
        _hitboxObject.SetActive(false);
    }
}
