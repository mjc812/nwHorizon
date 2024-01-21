using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    public delegate void PromptInputOpen();
    public static event PromptInputOpen OnPromptInputOpen;
    public delegate void PromptInputClosed();
    public static event PromptInputClosed OnPromptInputClosed;
    public delegate void PromptInputSubmit(string prompt);
    public static event PromptInputSubmit OnPromptInputSubmit;

    public GameObject inputField;
    public TMP_InputField inputFieldText;
    public TMP_Text factText;
    public TMP_Text hint;
    public GameObject settings;

    void Awake() {
        inputField.SetActive(false);
        settings.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !settings.activeSelf)
        {
            inputField.SetActive(!inputField.activeSelf); //TODO check that settings is not open

            if (inputField.activeSelf)
            {
                inputFieldText.text = "";
                inputFieldText.Select();
                inputFieldText.ActivateInputField();
                OnPromptInputOpen?.Invoke();
            }
            else
            {
                OnPromptInputClosed?.Invoke();
            }
        } else if (Input.GetKeyDown(KeyCode.Return)) {
            if (inputField.activeSelf) {
                inputField.SetActive(false);
                string prompt = inputFieldText.text;
                OnPromptInputSubmit?.Invoke(prompt);
            }   
        } else if (Input.GetKeyDown(KeyCode.S) && !inputField.activeSelf) {
            settings.SetActive(!settings.activeSelf);
            if (settings.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                hint.text = "Press S to close settings";
                OnPromptInputOpen?.Invoke();
            } else {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                hint.text = "Press S to open settings";
                OnPromptInputClosed?.Invoke();
            }
        }
    }

    public void SetFactText(string fact) {
        factText.text = fact;
    }
}
