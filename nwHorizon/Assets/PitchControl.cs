using UnityEngine;

public class PitchControl : MonoBehaviour
{
    public AudioSource audioSource;
    public float lowPitch = 0.7f;
    public float mediumPitch = 0.8f;
    public float highPitch = 0.9f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SetPitch(lowPitch);
        } else if (Input.GetKey(KeyCode.LeftShift))
        {
            SetPitch(highPitch);
        } else {
            SetPitch(mediumPitch);
        }
    }

    void SetPitch(float pitch)
    {
        if (audioSource != null)
        {
            audioSource.pitch = Mathf.Clamp(pitch, 0.1f, 3.0f);
        }
    }
}
