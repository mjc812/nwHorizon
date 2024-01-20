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


    void Awake() {
        inputField.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputField.SetActive(!inputField.activeSelf);

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
        }
    }   
}
