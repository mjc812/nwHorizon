using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DynamicPostProcessing : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private ChromaticAberration chromaticAberration;
    public float normalIntensity = 0.15f;
    public float boostedIntensity = 0.5f;
    public float transitionSpeed = 0.5f;

    private void Start()
    {
        if (postProcessVolume == null)
        {
            Debug.LogError("Post Process Volume is not assigned!");
            return;
        }

        if (postProcessVolume.profile.TryGetSettings(out chromaticAberration))
        {
            chromaticAberration.intensity.value = normalIntensity;
        }
        else
        {
            Debug.LogError("Chromatic Aberration effect not found in the Post Process Volume!");
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, boostedIntensity, Time.deltaTime * transitionSpeed);
        }
        else
        {
            chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, normalIntensity, Time.deltaTime * transitionSpeed);
        }
    }
}
