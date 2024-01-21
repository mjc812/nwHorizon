using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public TMP_Text volumeText;
    public Slider volumeSlider;

    public TMP_Text brightnessText;
    public Slider brightnessSlider;

    public TMP_Text yawSensitivityText;
    public Slider yawSensitivitySlider;

    public TMP_Text pitchSensitivityText;
    public Slider pitchSensitivitySlider;

    void Start()
    {
        // Initialize the slider values and text
        UpdateSliderText(volumeText, volumeSlider.value);
        UpdateSliderText(brightnessText, brightnessSlider.value);
        UpdateSliderText(yawSensitivityText, yawSensitivitySlider.value);
        UpdateSliderText(pitchSensitivityText, pitchSensitivitySlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the text based on slider values
        UpdateSliderText(volumeText, volumeSlider.value);
        UpdateSliderText(brightnessText, brightnessSlider.value);
        UpdateSliderText(yawSensitivityText, yawSensitivitySlider.value);
        UpdateSliderText(pitchSensitivityText, pitchSensitivitySlider.value);
    }

    // Method to update the text of a slider
    void UpdateSliderText(TMP_Text textObject, float sliderValue)
    {
        if (textObject != null)
        {
            // Update the text with the slider value
            textObject.text = $"{textObject.name}: {sliderValue:F2}";
        }
    }
}

