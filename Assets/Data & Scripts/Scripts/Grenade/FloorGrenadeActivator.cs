using UnityEngine;

public class FloorGrenadeActivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var grenade = other.GetComponent<Grenade>();
        if (grenade)
            grenade.Destroy();
    }
}