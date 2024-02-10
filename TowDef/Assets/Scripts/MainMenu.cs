using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.Services.Authentication;

public class MainMenu : MonoBehaviour
{
   public string levelToLoad = "MainLevel";

    public SceneFader sceneFader;
    public GameObject loginCanvas;

    public void Play ()
    {
        sceneFader .FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exciting...");  
        Application.Quit();
    }

    public void Login() 
    {
        loginCanvas.SetActive(true);
    }

     public void backToMenu() 
    {
        sceneFader.FadeTo("MainMenu");
            
    }
}
