using UnityEngine;

public class CameraZone : MonoBehaviour
{
    // [SerializeField] private RectTransform _leftBorder;
    // [SerializeField] private RectTransform _rightBorder;
    // [SerializeField] private int _offsetX;
    //
    // private WeaponChooser _abilityChooser;
    // private Camera _camera;
    // private Vector2 _leftDownBorder;
    // private Vector2 _rightDownBorder;
    // private Vector2 _leftTopBorder;
    // private Vector2 _rightTopBorder;
    //
    // public Vector2 LeftDownBorder => _leftDownBorder;
    // public Vector2 RightDownBorder => _rightDownBorder;
    // public Vector2 LeftTopBorder => _leftTopBorder;
    // public Vector2 RightTopBorder => _rightTopBorder;
    //
    // private void Awake()
    // {
    //     _camera = Camera.main;
    //     _abilityChooser = GetComponentInChildren<WeaponChooser>();
    //     _leftDownBorder = _camera.ViewportToWorldPoint(new Vector2(0, 0));
    //     _rightDownBorder = _camera.ViewportToWorldPoint(new Vector2(1, 0));
    //     _leftTopBorder = _camera.ViewportToWorldPoint(new Vector2(0, 1));
    //     _rightTopBorder = _camera.ViewportToWorldPoint(new Vector2(1, 1));
    // }
    //
    // private void Start()
    // {
    //     _leftBorder.position = new Vector2(_abilityChooser.CardWidth + _offsetX, _leftBorder.position.y);
    //     _rightBorder.position = new Vector2(Screen.width - (_abilityChooser.CardWidth + _offsetX), _rightBorder.position.y);
    // }
}