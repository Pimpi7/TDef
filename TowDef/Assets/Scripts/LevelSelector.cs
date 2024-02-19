using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";
    public Button[] levelButtons;
    public new AudioSource audio;
    public string menuSceneName = "MainMenu";
    public SceneFader sceneFader;
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for(int i=0; i<levelButtons.Length; i++)
        {
            if(i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
    }

    public void Select(string levelName)
    {
        sceneFader.FadeTo(levelName);
    }

    public void Menu()
    {
        sceneFader.FadeTo("MainMenu");
    }

    public void playSound() 
    {
        audio.Play();
    }
    public void Menu ()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
