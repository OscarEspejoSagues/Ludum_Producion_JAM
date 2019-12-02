using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Camera mainCam;

    float shakeAmount = 0.0f;

    private void Awake()
    {
        if (mainCam == null)
        {
            mainCam = Camera.main;
        }
    }
    
    public void Shake(float power, float length)
    {

        shakeAmount = power;
        InvokeRepeating("BeginShake",0,0.01f);
        Invoke("StopShake", length);


    }

    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = mainCam.transform.position;

            float shakePowerX = Random.value * shakeAmount * 2 - shakeAmount;
            float shakePowerY = Random.value * shakeAmount * 2 - shakeAmount;

            camPos.x += shakePowerX;
            camPos.y += shakePowerY;

            mainCam.transform.position = camPos;

        }
    }

    public void StopShake()
    {
        CancelInvoke("BeginShake");
        mainCam.transform.localPosition = Vector3.zero;
    }
}
