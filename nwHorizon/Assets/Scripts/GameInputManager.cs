using UnityEngine;

public class GameInputManager : MonoBehaviour
{
    public static GameInputManager Instance;

    // Shared variables
    public float volume;
    public float defaultVolume = 75f;
    public float brightness;
    public float defaultBrightness = 75f;
    public float yawSensitivity;
    public float defaultYawSensitivity = 15f;
    public float pitchSensitivity;
    public float defaultPitchSensitivity = 8f;
    public float contrast;
    public float defaultContrast = 5f;
    public bool disableMotionEffects;
    public bool defaultDisableMotionEffects = false;

    void Awake()
    {
        volume = defaultVolume;
        brightness = defaultBrightness;
        yawSensitivity = defaultYawSensitivity;
        pitchSensitivity = defaultPitchSensitivity;
        contrast = defaultContrast;
        disableMotionEffects = defaultDisableMotionEffects;

        if (Instance == null)
        {
            // If an instance doesn't exist, set this as the instance
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }
    }
}

