using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float zoomedIn = 30;
    [SerializeField]public float zoomedOut = 60;
    [SerializeField] float mouseSensZIn = 1;
    [SerializeField] float mouseSensZOut = 2;
    [SerializeField] RigidbodyFirstPersonController rbPlayer;
    [SerializeField] GameObject CCVolumeScope;
    [SerializeField] GameObject Light;
    bool zoomedInToggle = false;

    private void OnEnable()
    {
        //CCVolumeScope.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                CCVolumeScope.SetActive(true);
               Light.GetComponent<Light>().range = 20f;
                zoomedInToggle = true;
                playerCamera.fieldOfView = zoomedIn;
                rbPlayer.mouseLook.XSensitivity = mouseSensZIn;
                rbPlayer.mouseLook.YSensitivity = mouseSensZIn;
            }
            else
            {
               Light.GetComponent<Light>().range = 10f;
                CCVolumeScope.SetActive(false);
                zoomedInToggle = false;
                playerCamera.fieldOfView = zoomedOut;
                rbPlayer.mouseLook.XSensitivity = mouseSensZOut;
                rbPlayer.mouseLook.YSensitivity = mouseSensZOut;
            }
        }
    }
    private void OnDisable()
    {
        Light.GetComponent<Light>().range = 10f;
        CCVolumeScope.SetActive(false);
        zoomedInToggle = false;
        playerCamera.fieldOfView = zoomedOut;
        rbPlayer.mouseLook.XSensitivity = mouseSensZOut;
        rbPlayer.mouseLook.YSensitivity = mouseSensZOut;    
    }
}
