using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 35f;
    [SerializeField] Slider flashlightSlider;
    Light myLight;
    private void Start()
    {
        myLight = GetComponent<Light>();
    }
    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
        DisplayFlashlight();
    }

    private void DisplayFlashlight()
    {
        flashlightSlider.minValue = 0f;
        flashlightSlider.maxValue = 3.5f;   
        flashlightSlider.value = myLight.intensity;
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        myLight.spotAngle = restoreAngle;
    }
   public void RestoreLightIntensity(float intensityAmount)
    {
        myLight.intensity += intensityAmount; 
    }

    void DecreaseLightAngle()
    {
        if (minimumAngle >= myLight.spotAngle)
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }
    void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay *Time.deltaTime;
    }
}
