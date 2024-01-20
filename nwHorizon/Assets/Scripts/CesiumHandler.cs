using UnityEngine;
using CesiumForUnity;
using System;

public class CesiumHandler : MonoBehaviour
{
    public CesiumGeoreference cesiumGeoreference;

    //TODO: remove
    // void Update() {
    //     if (Input.GetKeyDown(KeyCode.M))
    //     {
    //         SetNewLocation();
    //     }
    // }

    public void SetNewLocation(float latitude, float longitude, float altitude)
    {
        cesiumGeoreference.latitude = latitude;
        cesiumGeoreference.longitude = longitude;
        cesiumGeoreference.height = altitude;
    }
}

