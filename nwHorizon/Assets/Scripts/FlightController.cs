using UnityEngine;

public class FlightController : MonoBehaviour
{
    public float forwardForceMultiplier = 100.0f;
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
        CanvasController.OnPromptInputSubmit += OnPromptInputSubmitHandler;
        PostProcessingHandler.OnTransitionFinished += OnTransitionFinishedHandler;
    }

    void Update() {
              if (Input.GetKeyDown(KeyCode.T)) {
            if (forwardForceMultiplier == 0f) {
                forwardForceMultiplier = 100f;
            } else {
                forwardForceMultiplier = 0f;
            }
        }
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

        Vector3 forwardForce = transform.forward * forwardForceMultiplier;
        rb.AddForce(forwardForce);

        rb.angularVelocity *= angularDamping;
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

    private void OnTransitionFinishedHandler() {
        Debug.Log("transition ready");
    }
}
