using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocationTextHandler : MonoBehaviour
{
    public GameObject locationText;
    public TMP_Text textMeshPro;

    public void SetLocationText(string city, string country) {
        textMeshPro.text = city + ", " + country; 
    }

    public void SetLocationTextAltitude(float altitude) {
        transform.position = new Vector3(0f, altitude, 0f);
    }
}
