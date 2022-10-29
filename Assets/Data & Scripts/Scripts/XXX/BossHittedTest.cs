using UnityEngine;
using UnityEngine.UI;

public class BossHittedTest : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private Slider _slider;

    private void Update()
    {
        _boss.BossBeatenView.SetHitted(_slider.value);
    }
}