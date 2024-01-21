using UnityEngine;

public class GameInputManager : MonoBehaviour
{
    public static GameInputManager Instance;

    // Shared variables
    public float volume;
    public float brightness;
    public float yawSensitivity;
    public float pitchSensitivity;

    void Awake()
    {
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

