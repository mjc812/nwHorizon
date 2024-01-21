using UnityEngine;

public class DynamicFOV : MonoBehaviour
{
    public Camera mainCamera;
    public float normalFOV = 80.0f;
    public float boostedFOV = 90.0f;
    public float transitionSpeed = 0.2f;

    private void Start()
    {
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera is not assigned!");
            return;
        }

        // Set the initial FOV
        mainCamera.fieldOfView = normalFOV;
    }

    private void Update()
    {
        // Check if the left shift key is held down
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // Gradually increase the FOV
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, boostedFOV, Time.deltaTime * transitionSpeed);
        }
        else
        {
            // Gradually return to the normal FOV
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, normalFOV, Time.deltaTime * transitionSpeed);
        }
    }
}
