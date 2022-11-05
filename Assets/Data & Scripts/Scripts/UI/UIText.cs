using TMPro;
using UnityEngine;

public class UIText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Animator _animator;
    private const string Pulse = nameof(Pulse);
    private const string Idle = nameof(Idle);

    public void SetText(string text)
    {
        _text.text = text;
    }

    public void SetTextColor(Color color)
    {
        _text.color = color;
    }

    public void PlayAnimation()
    {
        _animator.SetTrigger(Pulse);
    }
}