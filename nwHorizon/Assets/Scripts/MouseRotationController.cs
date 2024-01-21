using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotationController : MonoBehaviour
{
    public bool inverse = false;
    public float lerpTime = 10.0f;
    public float yawSensitivity = 5.0f;
    public float pitchSensitivity = 5.0f;
    private float currentYawSensitivity = 5.0f;
    private float currentPitchSensitivity = 5.0f;
    public float slowFlyMultiplier = 0.75f;
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
        
        FlightController.OnSlowFly += OnSlowFlyHandler;
        FlightController.OnNormalFly += OnNormalFlyHandler;
    }

    void Update()
    {
        if (GameInputManager.Instance.disableMotionEffects) {
            return;
        }

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

        mouseX = Mathf.Clamp(mouseX, -50f, 50f);
        mouseY = Mathf.Clamp(mouseY, -20f, 20f);

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

    private void OnSlowFlyHandler() {
        // currentYawSensitivity = yawSensitivity * slowFlyMultiplier;
        // currentPitchSensitivity = pitchSensitivity * slowFlyMultiplier;
    }

    private void OnNormalFlyHandler() {
        // currentYawSensitivity = yawSensitivity;
        // currentPitchSensitivity = pitchSensitivity;
    }
}
