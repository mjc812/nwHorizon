using UnityEngine;
using CesiumForUnity;
using System;

public class CesiumHandler : MonoBehaviour
{
    public CesiumGeoreference cesiumGeoreference;

    //just for testing
    void Update() {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SetNewLocation();
        }
    }

    public void SetNewLocation()
    {
        cesiumGeoreference.latitude = 48.8566f;
        cesiumGeoreference.longitude = 2.3522f;
        cesiumGeoreference.height = 200f;
        // cameraMove.transform.position = new Vector3(0f, altitudeOffset, -1500f);
    }
}

