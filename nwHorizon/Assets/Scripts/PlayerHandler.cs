using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public Transform playerTransform;

    public void ZeroPlayerRotation() {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void SetPlayerPosition(float x, float y, float z) {
        transform.position = new Vector3(x, y, z);
    }
}
