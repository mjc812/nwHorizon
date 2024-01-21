using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CesiumForUnity;

public class APIHandler : MonoBehaviour
{
    public GameObject Player;
    public Transform playerTransform;
    public PlayerHandler playerHandler;
    public ChatGPTHandler chatGPTHandler;
    public CesiumHandler cesiumHandler;
    public Cesium3DTileset cesium3DTileset;
    public LocationTextHandler locationTextHandler;

    public float playerAltitudeOffset = 200f;
    public float playerLatitudeOffset = -600f;
    public float locationTextAltitudeOffset = 300f;

    private bool logProgress = false;

    void Start()
    {
        CanvasController.OnPromptInputSubmit += OnPromptInputSubmitHandler;
        ChatGPTHandler.OnRequestComplete += OnRequestCompleteHandler;
    }

    void Update() {
        if (logProgress) {
            Debug.Log(cesium3DTileset.ComputeLoadProgress());
        }
    }

    private void OnPromptInputSubmitHandler(string prompt) {
        logProgress = true;
        StartCoroutine(chatGPTHandler.RequestLocation(prompt));
    }

    private void OnRequestCompleteHandler(Location location) {
        logProgress = false;
        playerHandler.ZeroPlayerRotation();
        cesiumHandler.SetNewLocation(location.latitude, location.longitude, location.altitude);
        SetPlayerLocation(location.altitude);
        locationTextHandler.SetLocationTextAltitude(location.altitude + locationTextAltitudeOffset);
        locationTextHandler.SetLocationText("tokyo", "japan");
    }

    private void SetPlayerLocation(float altitude) {
        playerHandler.SetPlayerPosition(0f, altitude + playerAltitudeOffset, playerLatitudeOffset);
    }
}
