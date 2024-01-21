using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    public SettingsController settingsController;
    void Start()
    {
        CanvasController.OnPromptInputOpen += OnPromptInputOpenHandler;
        CanvasController.OnPromptInputClosed += OnPromptInputClosedHandler;
        CanvasController.OnPromptInputSubmit += OnPromptInputSubmitHandler;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            Debug.Log(GameInputManager.Instance.volume);
        }
    }

    private void OnPromptInputOpenHandler() {
        //Debug.Log("input open");
    }

    private void OnPromptInputClosedHandler() {
       // Debug.Log("input closed");
    }
    
    private void OnPromptInputSubmitHandler(string prompt) {
        //Debug.Log("input submit: " + prompt);
    }
}
