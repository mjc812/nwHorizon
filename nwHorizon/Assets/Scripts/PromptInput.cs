using UnityEngine;
using TMPro;

public class PromptInput : MonoBehaviour
{
    public GameObject inputField;
    public TMP_InputField inputFieldText;

    void Awake() {
        inputField.SetActive(false);
    }

    void Update()
    {
        Debug.Log("Called");
        if (Input.GetKeyDown(KeyCode.T))
        {
            inputField.SetActive(!inputField.activeSelf);

            if (inputField.activeSelf)
            {
                inputFieldText.text = "";
                inputFieldText.Select();
                inputFieldText.ActivateInputField();
                Debug.Log("Input field opened");
            }
            else
            {
                Debug.Log("Input field closed");
            }
        }
    }   
}
