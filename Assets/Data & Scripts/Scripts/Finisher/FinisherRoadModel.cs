using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinisherRoadModel : MonoBehaviour
{
    [SerializeField] [Min(0.1f)] private float _appearDuration;
    [SerializeField] [Min(0.001f)] private float _wallsAppearInterval;
    [SerializeField] private Vector3 _appearanceOffset;
    [SerializeField] private Wall[] _walls;

    private Coroutine _appearCoroutine;
    private Coroutine _wallsAppearing;

    public IReadOnlyList<Wall> Walls => _walls;

    public void Show()
    {
        gameObject.SetActive(true);
        _appearCoroutine = StartCoroutine(AppearingRoad());
        _wallsAppearing = StartCoroutine(AppearingWalls());
    }

    public void Hide()
    {
        if (_appearCoroutine != null)
            StopCoroutine(_appearCoroutine);
        if (_wallsAppearing != null)
            StopCoroutine(_wallsAppearing);
        gameObject.SetActive(false);
    }

    private IEnumerator AppearingRoad()
    {
        for (float i = 0; i < 1; i += Time.deltaTime / _appearDuration)
        {
            transform.localPosition = Vector3.Lerp(_appearanceOffset, Vector3.zero, i);

            yield return null;
        }

        transform.localPosition = Vector3.zero;
    }

    private IEnumerator AppearingWalls()
    {
        for (var i = _walls.Length - 1; i >= 0; --i)
        {
            _walls[i].Show();

            yield return new WaitForSeconds(_wallsAppearInterval);
        }
    }
}