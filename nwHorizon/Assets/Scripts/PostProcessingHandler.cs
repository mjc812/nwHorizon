using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingHandler : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private Bloom bloomEffect;

    public float changeDuration = 3.0f;

    private void Start()
    {
        if (postProcessVolume == null)
        {
            Debug.LogError("Post-Processing Volume not assigned!");
            return;
        }

        postProcessVolume.profile.TryGetSettings(out bloomEffect);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(ChangeBloomAsync(5.0f));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(ChangeBloomAsync(0.0f));
        }
    }

    private IEnumerator ChangeBloomAsync(float targetIntensity)
    {
        if (bloomEffect != null)
        {
            float elapsedTime = 0f;
            float startIntensity = bloomEffect.intensity.value;

            while (elapsedTime < changeDuration)
            {
                bloomEffect.intensity.value = Mathf.Lerp(startIntensity, targetIntensity, elapsedTime / changeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            bloomEffect.intensity.value = targetIntensity;
        }
    }
}
