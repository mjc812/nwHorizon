using UnityEngine;
using System;
using System.Collections;

public class FlightController : MonoBehaviour
{
    private float currentforwardForceMultiplier = 70.0f;  
    public float normalForwardForceMultiplier = 70.0f;
    public float slowForwardForceMultiplier = 10.0f;
    public float fastForwardForceMultiplier = 400.0f;
    public float torqueForce = 5.0f;
    public float maxPitchAngle = 80.0f;
    public float angularDamping = 0.95f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found. Attach a Rigidbody to the GameObject.");
        }
        CanvasController.OnPromptInputOpen += OnPromptInputOpenHandler;
        CanvasController.OnPromptInputClosed += OnPromptInputClosedHandler;
        //CanvasController.OnPromptInputSubmit += OnPromptInputSubmitHandler;
        PostProcessingHandler.OnTransitionFinished += OnTransitionFinishedHandler;
    }

    void Update() {
        Vector3 rotation = transform.rotation.eulerAngles;
        
        rotation.x = (rotation.x > 180) ? rotation.x - 360 : rotation.x;
        rotation.x = Mathf.Clamp(rotation.x, -60f, 60f);

        rotation.z = 0;

        transform.rotation = Quaternion.Euler(rotation);
    }

    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rb.AddTorque(transform.up * mouseX * torqueForce);
        rb.AddTorque(transform.right * -mouseY * torqueForce);

        Vector3 forwardForce = transform.forward * currentforwardForceMultiplier;
        rb.AddForce(forwardForce);

        rb.angularVelocity *= angularDamping;
    }

    private void OnPromptInputOpenHandler() {
        currentforwardForceMultiplier = slowForwardForceMultiplier;
        
    }

    private void OnPromptInputClosedHandler() {
        currentforwardForceMultiplier = normalForwardForceMultiplier;
    }
    
    // private void OnPromptInputSubmitHandler(string prompt) {
    //     //
    // }

    private void OnTransitionFinishedHandler() {
        Debug.Log("transition finished called");
        currentforwardForceMultiplier = normalForwardForceMultiplier;
    }

    private IEnumerator ChangeValueOverTime(float targetValue, float duration)
    {
        Debug.Log("called");
        float elapsedTime = 0f;
        float startValue = currentforwardForceMultiplier;

        while (elapsedTime < duration)
        {
            float newValue = Mathf.Lerp(startValue, targetValue, elapsedTime / duration);
            ApplyNewValue(newValue);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ApplyNewValue(targetValue);
    }

    private void ApplyNewValue(float newValue)
    {
        currentforwardForceMultiplier = newValue;
        Debug.Log("Current Value: " + currentforwardForceMultiplier);
    }
}
