using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private WallText _wallText;
    [SerializeField] private float _multiplierValue;
    [SerializeField] private BossTargetPoint _bossTargetPoint;
    [SerializeField] private BossTargetPoint _bossTargetPointLast;
    [SerializeField] private WallPhysics _wallPhysics;
    [SerializeField] [Min(0)] private float _appearDuration;
    [SerializeField] private float _appearanceOffsetY;

    private Coroutine _appearanceCoroutine;
    private Vector3 _defaultPosition;

    public WallText Text => _wallText;
    public float MultiplierValue => _multiplierValue;
    public Vector3 BossTargetPoint => _bossTargetPoint.transform.position;
    public Vector3 BossTargetPointLast => _bossTargetPointLast.transform.position;
    public WallPhysics WallPhysics => _wallPhysics;

    private void Awake()
    {
        _defaultPosition = transform.localPosition;
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _appearanceCoroutine = StartCoroutine(AppearingAnimation());
    }

    public void Hide()
    {
        if (_appearanceCoroutine != null)
            StopCoroutine(_appearanceCoroutine);
        gameObject.SetActive(false);
    }

    private IEnumerator AppearingAnimation()
    {
        var appearanceOffset = new Vector3(_defaultPosition.x, _appearanceOffsetY, _defaultPosition.z);
        
        for (float i = 0; i < 1; i += Time.deltaTime / _appearDuration)
        {
            transform.localPosition = Vector3.Lerp(appearanceOffset, _defaultPosition, i);

            yield return null;
        }

        transform.localPosition = _defaultPosition;
    }
}