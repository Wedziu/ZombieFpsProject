using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject settings;
    // Start is called before the first frame update
    void Start()
    {
        settings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScreenRes()
    {
        string index = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch (index)
        {
            case "0":
                Screen.SetResolution(800, 600, true);
                break;
            case "1":
                Screen.SetResolution(1366, 768, true);
                break;
            case "2":
                Screen.SetResolution(1920, 1080, true);
                break;
        }
    }
 
}
