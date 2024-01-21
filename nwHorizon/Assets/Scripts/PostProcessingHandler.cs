using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingHandler : MonoBehaviour
{
    public delegate void TransitionFinished();
    public static event TransitionFinished OnTransitionFinished;

    public PostProcessVolume postProcessVolume;
    private Bloom bloomLayer;
    private bool intensify = false;

    private void Start()
    {
        if (!postProcessVolume.profile.TryGetSettings(out bloomLayer))
        {
            Debug.LogError("Bloom layer not found!");
            return;
        }
    }

    public void IncreaseBloom()
    {
        intensify = true;
        StartCoroutine(ChangeBloomIntensityOverTime(bloomLayer.intensity, 40f, 3.0f, false));
    }

    public void DecreaseBloom()
    {
        StartCoroutine(ChangeBloomIntensityOverTime(bloomLayer.intensity, 0f, 3.0f, true));
    }

    private System.Collections.IEnumerator ChangeBloomIntensityOverTime(float startIntensity, float targetIntensity, float time, bool stall)
    {
        if (stall) { //TODO remove this. only for testing
            yield return new WaitForSeconds(2.0f);
        }

        float t = 0f;

        while (t < time)
        {
            t += Time.deltaTime;
            bloomLayer.intensity.value = Mathf.Lerp(startIntensity, targetIntensity, t / time);
            yield return null;
        }

        if (stall) { //TODO remove this. only for testing
            OnTransitionFinished?.Invoke();
        }
    }

}
