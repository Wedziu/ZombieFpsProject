using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
   public  void ReloadTheScene()
    {
        var scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
    }
    public void MainMenuOpening()
    {
        SceneManager.LoadScene("MainMenu");
    }
   public void QuitTheGame()
    {
        Application.Quit();
    }
}
