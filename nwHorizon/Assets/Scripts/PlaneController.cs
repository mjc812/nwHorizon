using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float lerpTime = 10.0f;
    public float yawSensitivity = 5.0f;
    public float pitchSensitivity = 5.0f;
    public float smoothing = 2.0f;
    public float momentum = 0.95f; // Adjust the momentum factor

    private float smoothMouseX;
    private float smoothMouseY;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        
        smoothMouseX = Mathf.Lerp(smoothMouseX, mouseX, Time.deltaTime * smoothing);
        smoothMouseY = Mathf.Lerp(smoothMouseY, mouseY, Time.deltaTime * smoothing);
        mouseX = smoothMouseX;
        mouseY = smoothMouseY;

        mouseX *= momentum;
        mouseY *= momentum;

        mouseX *= 100.0f * yawSensitivity;
        mouseY *= 100.0f * pitchSensitivity;

        Quaternion xRotation = Quaternion.AngleAxis(-1 * mouseY, Vector3.right);
        Quaternion yRotation = Quaternion.AngleAxis(-1 * mouseX, Vector3.forward);
        Quaternion targetRotation = xRotation * yRotation;
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, lerpTime * Time.deltaTime);

    }
}
