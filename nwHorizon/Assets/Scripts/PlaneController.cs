using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float lerpTime = 10.0f;

    void Start()
    {
        
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mouseX *= 100.0f;
        mouseY *= 100.0f;

        Quaternion xRotation = Quaternion.AngleAxis(-1 * mouseY, Vector3.right);
        Quaternion yRotation = Quaternion.AngleAxis(-1 * mouseX, Vector3.forward);
        
        Quaternion targetRotation = xRotation * yRotation;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, lerpTime * Time.deltaTime);

    }
}
