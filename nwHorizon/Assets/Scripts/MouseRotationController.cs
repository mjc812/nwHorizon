using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotationController : MonoBehaviour
{
    public bool inverse = false;
    public float lerpTime = 10.0f;
    public float yawSensitivity = 5.0f;
    public float pitchSensitivity = 5.0f;
    public float smoothing = 2.0f;
    public float momentum = 0.95f;

    private float smoothMouseX;
    private float smoothMouseY;
    private bool lockPlayer = false;


    void Start()
    {
        CanvasController.OnPromptInputOpen += OnPromptInputOpenHandler;
        CanvasController.OnPromptInputClosed += OnPromptInputClosedHandler;
        PostProcessingHandler.OnTransitionFinished += OnTransitionFinishedHandler;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        if (lockPlayer) {
            mouseX = 0f;
            mouseY = 0f;
        }
        
        smoothMouseX = Mathf.Lerp(smoothMouseX, mouseX, Time.deltaTime * smoothing);
        smoothMouseY = Mathf.Lerp(smoothMouseY, mouseY, Time.deltaTime * smoothing);
        mouseX = smoothMouseX;
        mouseY = smoothMouseY;

        mouseX *= momentum;
        mouseY *= momentum;

        mouseX *= 100.0f * yawSensitivity;
        mouseY *= 100.0f * pitchSensitivity;

        if (inverse) {
            mouseX *= -1;
            mouseY *= -1;
        }

        Quaternion xRotation = Quaternion.AngleAxis(mouseY, Vector3.right);
        Quaternion yRotation = Quaternion.AngleAxis(mouseX, inverse ? Vector3.forward : Vector3.up);
        Quaternion targetRotation = xRotation * yRotation;
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, lerpTime * Time.deltaTime);
    }

    private void OnPromptInputOpenHandler() {
        lockPlayer = true;
    }

    private void OnPromptInputClosedHandler() {
        lockPlayer = false;
    }
    
    private void OnTransitionFinishedHandler() {
        lockPlayer = false;
    }

}
