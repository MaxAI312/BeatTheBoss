using TMPro;
using UnityEngine;

public class MultiplierView : MonoBehaviour
{
    private const string Change = nameof(Change);

    [SerializeField] private TMP_Text _multiplierText;
    [SerializeField] private Animator _animator;

    private BossCollisionHandler _bossCollisionHandler;

    private void OnEnable()
    {
        if (_bossCollisionHandler != null)
            _bossCollisionHandler.WallTaken += SetText;
    }

    private void OnDisable()
    {
        if (_bossCollisionHandler != null)
            _bossCollisionHandler.WallTaken -= SetText;
    }

    public void Initialize(BossCollisionHandler bossCollisionHandler)
    {
        _bossCollisionHandler = bossCollisionHandler;
    }

    private void SetText(Wall wall)
    {
        _multiplierText.text = wall.Text.Text;
        _animator.SetTrigger(Change);
    }
}