using System;
using System.Collections;
using UnityEngine;

public class ParameterAnimator : MonoBehaviour
{
    private Coroutine changingCoroutine;

    public void ChangingParameterBy(Action<float> currentValue, float startValue, float targetValue, float duration)
    {
        if (changingCoroutine != null)
            StopCoroutine(changingCoroutine);

        changingCoroutine = StartCoroutine(ChangingParameter(currentValue, startValue, targetValue, duration));
    }

    private IEnumerator ChangingParameter(Action<float> currentValue, float startValue, float targetValue,
        float duration)
    {
        for (float i = 0; i < 1; i += Time.deltaTime / duration)
        {
            currentValue?.Invoke(Mathf.Lerp(startValue, targetValue, i));

            yield return null;
        }

        currentValue?.Invoke(targetValue);
    }
}