using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIHandler : MonoBehaviour
{
    public ChatGPTHandler chatGPTHandler;
    public CesiumHandler cesiumHandler;

    void Start()
    {
        CanvasController.OnPromptInputSubmit += OnPromptInputSubmitHandler;
        ChatGPTHandler.OnRequestComplete += OnRequestCompleteHandler;
    }

    private void OnPromptInputSubmitHandler(string prompt) {
        StartCoroutine(chatGPTHandler.RequestLocation(prompt));
    }

    private void OnRequestCompleteHandler(Location location) {
        cesiumHandler.SetNewLocation(location.latitude, location.longitude, location.altitude);
    }
}
