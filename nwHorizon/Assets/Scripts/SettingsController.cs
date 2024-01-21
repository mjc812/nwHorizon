using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    //public float volume = 75.0f;
    public TMP_Text volumeText;
    public Slider volumeSlider;

    //public float brightness = 75.0f;
    public TMP_Text brightnessText;
    public Slider brightnessSlider;

   // public float yawSensitivity = 15.0f;
    public TMP_Text yawSensitivityText;
    public Slider yawSensitivitySlider;

   // public float pitchSensitivity = 8.0f;
    public TMP_Text pitchSensitivityText;
    public Slider pitchSensitivitySlider;

    void Start()
    {
        // Initialize the slider values and text
        UpdateSliderText(volumeText, GameInputManager.Instance.volume);
        UpdateSliderText(brightnessText, GameInputManager.Instance.brightness);
        UpdateSliderText(yawSensitivityText, GameInputManager.Instance.yawSensitivity);
        UpdateSliderText(pitchSensitivityText, GameInputManager.Instance.pitchSensitivity);

        volumeSlider.value = GameInputManager.Instance.volume;
        brightnessSlider.value = GameInputManager.Instance.brightness;
        yawSensitivitySlider.value = GameInputManager.Instance.yawSensitivity;
        pitchSensitivitySlider.value = GameInputManager.Instance.pitchSensitivity;

        // Add listeners to respond to slider value changes
        volumeSlider.onValueChanged.AddListener(delegate { UpdateSliderText(volumeText, volumeSlider.value); });
        brightnessSlider.onValueChanged.AddListener(delegate { UpdateSliderText(brightnessText, brightnessSlider.value); });
        yawSensitivitySlider.onValueChanged.AddListener(delegate { UpdateSliderText(yawSensitivityText, yawSensitivitySlider.value); });
        pitchSensitivitySlider.onValueChanged.AddListener(delegate { UpdateSliderText(pitchSensitivityText, pitchSensitivitySlider.value); });
    }

    void Update() {
        GameInputManager.Instance.volume = volumeSlider.value;
        GameInputManager.Instance.brightness = brightnessSlider.value;
        GameInputManager.Instance.yawSensitivity = yawSensitivitySlider.value;
        GameInputManager.Instance.pitchSensitivity = pitchSensitivitySlider.value;
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

