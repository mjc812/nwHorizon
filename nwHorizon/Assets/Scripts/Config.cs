using UnityEngine;
using CesiumForUnity;
using System;

public class Config : MonoBehaviour
{
    public Cesium3DTileset cesium3DTileset;

    private void Awake() {
        string google_cloud_api = Keys.google_cloud_api;
        //cesium3DTileset.url = "https://tile.googleapis.com/v1/3dtiles/root.json?key=" + google_cloud_api;
    }
}

