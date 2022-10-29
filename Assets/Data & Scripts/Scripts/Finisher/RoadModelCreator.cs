using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR

[ExecuteInEditMode]
public class RoadModelCreator : MonoBehaviour
{
    [SerializeField] private Vector3 _offset = Vector3.up;
    [SerializeField] [Min(1)] private int _count = 1;

    private void Start()
    {
        if (Application.isPlaying) Destroy(this);
    }

    private void Update()
    {
        CorrectChildCount();
    }

    private void CorrectChildCount()
    {
        _count = Mathf.Clamp(_count, 1, 1000);

        if (transform.childCount < _count)
            for (var i = transform.childCount; i < _count; i++)
                if (PrefabUtility.IsPartOfAnyPrefab(transform.GetChild(0)))
                {
                    var prefab = PrefabUtility.GetCorrespondingObjectFromOriginalSource(transform.GetChild(0))
                        .gameObject;

                    var instantiate = PrefabUtility.InstantiatePrefab(prefab, transform);
                    var instantiateObject = (GameObject) instantiate;
                    instantiateObject.transform.Translate(_offset * i);
                }
                else
                {
                    var instantiate = Instantiate(transform.GetChild(0), transform);
                    instantiate.Translate(_offset * i);
                }
        else if (_count < transform.childCount)
            for (var i = transform.childCount - 1; i >= _count; i--)
                DestroyImmediate(transform.GetChild(i).gameObject);
    }
}
#endif