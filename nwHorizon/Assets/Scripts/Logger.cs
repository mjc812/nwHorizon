using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    void Start()
    {
        CanvasController.OnPromptInputOpen += OnPromptInputOpenHandler;
        CanvasController.OnPromptInputClosed += OnPromptInputClosedHandler;
        CanvasController.OnPromptInputSubmit += OnPromptInputSubmitHandler;
    }

    private void OnPromptInputOpenHandler() {
        Debug.Log("input open");
    }

    private void OnPromptInputClosedHandler() {
        Debug.Log("input closed");
    }
    
    private void OnPromptInputSubmitHandler(string prompt) {
        Debug.Log("input submit: " + prompt);
    }
}
