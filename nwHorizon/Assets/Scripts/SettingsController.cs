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
//public float brightness = 75.0f;
    public TMP_Text contrastText;
    public Slider contrastSlider;

    public TMP_Text fontSizeText;
    public Slider fontSizeSlider;

   // public float yawSensitivity = 15.0f;
    public TMP_Text yawSensitivityText;
    public Slider yawSensitivitySlider;
    public TMP_Text sensitivityText;
    public Slider sensitivitySlider;

   // public float pitchSensitivity = 8.0f;
    public TMP_Text pitchSensitivityText;
    public Slider pitchSensitivitySlider;
    public Toggle disableMotionEffects;

    public Button resetPlane;


    void Start()
    {
        // Initialize the slider values and text
        UpdateSliderText(volumeText, GameInputManager.Instance.volume);
        UpdateSliderText(brightnessText, GameInputManager.Instance.brightness);
        UpdateSliderText(contrastText, GameInputManager.Instance.contrast);
        UpdateSliderText(fontSizeText, GameInputManager.Instance.fontSize);
        UpdateSliderText(sensitivityText, GameInputManager.Instance.sensitivity);
        UpdateSliderText(yawSensitivityText, GameInputManager.Instance.yawSensitivity);
        UpdateSliderText(pitchSensitivityText, GameInputManager.Instance.pitchSensitivity);
        disableMotionEffects.isOn = GameInputManager.Instance.disableMotionEffects;
        resetPlane.onClick.AddListener(resetPlaneHandler);

        volumeSlider.value = GameInputManager.Instance.volume;
        sensitivitySlider.value = GameInputManager.Instance.sensitivity;
        contrastSlider.value = GameInputManager.Instance.contrast;
        fontSizeSlider.value = GameInputManager.Instance.fontSize;
        brightnessSlider.value = GameInputManager.Instance.brightness;
        yawSensitivitySlider.value = GameInputManager.Instance.yawSensitivity;
        pitchSensitivitySlider.value = GameInputManager.Instance.pitchSensitivity;

        // Add listeners to respond to slider value changes
        volumeSlider.onValueChanged.AddListener(delegate { UpdateSliderText(volumeText, volumeSlider.value); });
        brightnessSlider.onValueChanged.AddListener(delegate { UpdateSliderText(brightnessText, brightnessSlider.value); });
        contrastSlider.onValueChanged.AddListener(delegate { UpdateSliderText(contrastText, contrastSlider.value); });
        sensitivitySlider.onValueChanged.AddListener(delegate { UpdateSliderText(sensitivityText, sensitivitySlider.value); });
        fontSizeSlider.onValueChanged.AddListener(delegate { UpdateSliderText(fontSizeText, fontSizeSlider.value); });
        yawSensitivitySlider.onValueChanged.AddListener(delegate { UpdateSliderText(yawSensitivityText, yawSensitivitySlider.value); });
        pitchSensitivitySlider.onValueChanged.AddListener(delegate { UpdateSliderText(pitchSensitivityText, pitchSensitivitySlider.value); });
        disableMotionEffects.onValueChanged.AddListener(delegate { ToggleMotionSickness(disableMotionEffects.isOn); });
    }

    void Update() {
        GameInputManager.Instance.volume = volumeSlider.value;
        GameInputManager.Instance.brightness = brightnessSlider.value;
        GameInputManager.Instance.contrast = contrastSlider.value;
        GameInputManager.Instance.fontSize = fontSizeSlider.value;
        GameInputManager.Instance.sensitivity = sensitivitySlider.value;
        GameInputManager.Instance.yawSensitivity = yawSensitivitySlider.value;
        GameInputManager.Instance.pitchSensitivity = pitchSensitivitySlider.value;
        GameInputManager.Instance.disableMotionEffects = disableMotionEffects.isOn;
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

    void ToggleMotionSickness(bool isOn)
    {
        GameInputManager.Instance.disableMotionEffects = isOn;

    }

    void resetPlaneHandler() {
        Debug.Log("reset player");
    }
}

