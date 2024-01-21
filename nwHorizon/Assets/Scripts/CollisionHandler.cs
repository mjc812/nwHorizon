using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BoxCollider>() != null)
        {
            Debug.Log("Collision with a GameObject with a BoxCollider occurred.");
            Debug.Log("Collided with: " + collision.gameObject.name);
        }
    }
}
