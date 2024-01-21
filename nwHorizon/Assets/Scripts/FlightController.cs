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
}
