using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public float volume = 75.0f;
    public TMP_Text volumeText;
    public Slider volumeSlider;

    public float brightness = 75.0f;
    public TMP_Text brightnessText;
    public Slider brightnessSlider;

    public float yawSensitivity = 15.0f;
    public TMP_Text yawSensitivityText;
    public Slider yawSensitivitySlider;

    public float pitchSensitivity = 8.0f;
    public TMP_Text pitchSensitivityText;
    public Slider pitchSensitivitySlider;

    void Start()
    {
        volumeSlider.value = volume;
        brightnessSlider.value = brightness;
        yawSensitivitySlider.value = yawSensitivity;
        pitchSensitivitySlider.value = pitchSensitivity;

        // Initialize the slider values and text
        UpdateSliderText(volumeText, volumeSlider.value);
        UpdateSliderText(brightnessText, brightnessSlider.value);
        UpdateSliderText(yawSensitivityText, yawSensitivitySlider.value);
        UpdateSliderText(pitchSensitivityText, pitchSensitivitySlider.value);

        // Add listeners to respond to slider value changes
        volumeSlider.onValueChanged.AddListener(delegate { UpdateSliderText(volumeText, volumeSlider.value); });
        brightnessSlider.onValueChanged.AddListener(delegate { UpdateSliderText(brightnessText, brightnessSlider.value); });
        yawSensitivitySlider.onValueChanged.AddListener(delegate { UpdateSliderText(yawSensitivityText, yawSensitivitySlider.value); });
        pitchSensitivitySlider.onValueChanged.AddListener(delegate { UpdateSliderText(pitchSensitivityText, pitchSensitivitySlider.value); });
    }

    // Method to update the text of a slider
    void UpdateSliderText(TMP_Text textObject, float sliderValue)
    {
        if (textObject != null)
        {
            // Update the text with the slider value
            textObject.text = $"{textObject.name}: {sliderValue}";
        }
    }
}

