using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] [Min(0)] private int _value;

    public int Value => _value;

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}