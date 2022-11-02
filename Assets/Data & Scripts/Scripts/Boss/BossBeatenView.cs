using UnityEngine;

public class BossBeatenView : MonoBehaviour
{
    private const float BossBeatenValueMax = 100f;
    private const float BossBeatenValueMin = 0f;
    
    [SerializeField] private GameObject[] _stages;

    private int startIndexStage = 0;
    
    private void Awake()
    {
        DisableStages();
        _stages[startIndexStage].SetActive(true);
    }

    public void SetHitted(float value)
    {
        value = Mathf.Clamp(value, BossBeatenValueMin, BossBeatenValueMax);

        var valueDelta = BossBeatenValueMax / _stages.Length;

        var deltasCount = value / valueDelta;
        var stageIndex = (int) deltasCount;
        stageIndex = Mathf.Clamp(stageIndex, startIndexStage, _stages.Length - 1);
        
        DisableStages();
        _stages[stageIndex].SetActive(true);
    }

    private void DisableStages()
    {
        foreach (var stage in _stages) stage.SetActive(false);
    }
}