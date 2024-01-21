using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocationTextHandler : MonoBehaviour
{
    public GameObject locationText;
    public TMP_Text countryText;
    public TMP_Text cityText;

    public void SetLocationText(string city, string country) {
        countryText.text = country;
        cityText.text = city;
    }

    public void SetLocationTextAltitude(float altitude) {
        transform.position = new Vector3(0f, altitude, 0f);
    }
}
