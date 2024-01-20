using UnityEngine;
using CesiumForUnity;
using System;

public class CesiumHandler : MonoBehaviour
{
    public CesiumGeoreference cesiumGeoreference;

    //TODO: remove
    void Update() {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetNewLocation();
        }
    }

    public void SetNewLocation()
    {
        cesiumGeoreference.latitude = 48.8566f;
        cesiumGeoreference.longitude = 2.3522f;
        cesiumGeoreference.height = 200f;
    }
}

