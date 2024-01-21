using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocationTextHandler : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 5.0f;
    public GameObject locationText;
    public TMP_Text countryText;
    public TMP_Text cityText;
    private bool shouldFaceAway = false;

    // void Update()
    // {
    //     if (shouldFaceAway)
    //     {
    //         Vector3 directionToPlayer = player.position - transform.position;
    //         directionToPlayer.y = 0;

    //         Quaternion targetRotation = Quaternion.LookRotation(-directionToPlayer);

    //         transform.rotation = Quaternion.Slerp(
    //             transform.rotation, targetRotation, rotationSpeed * Time.deltaTime
    //         );
    //     }
    // }

    public void SetLocationText(string city, string country) {
        countryText.text = country;
        cityText.text = city;
        //shouldFaceAway = false;
        //Invoke("StartFacingAway", 10f);
    }

    private void StartFacingAway() {
        shouldFaceAway = true;
    }

    public void SetLocationTextAltitude(float altitude) {
        transform.position = new Vector3(0f, altitude, 0f);
    }
}
