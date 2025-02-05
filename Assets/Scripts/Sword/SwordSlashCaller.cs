using UnityEngine;

public class SwordSlashCaller : MonoBehaviour {
    [SerializeField] private GameObject _slashObject;

    private Animator _slashAnim;

    private void Awake() {
        _slashAnim = _slashObject.GetComponent<Animator>();
    }

    public void PlaySlashAnimation() {
        _slashAnim.Play("Slash_Effect");
    }
}
