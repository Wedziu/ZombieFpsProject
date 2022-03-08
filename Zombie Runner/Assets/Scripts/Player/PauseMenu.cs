using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;
    private void Start()
    {
        pauseMenu.enabled = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenuOpen();
        }    
    }
    public void PauseMenuOpen()
    {
        pauseMenu.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.enabled = false;
        FindObjectOfType<WeaponSwitcher>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        
    }
}
