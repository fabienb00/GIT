using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevels : MonoBehaviour
{
    private int levelToLoad = 0;

    //Always make the beginning level the one at index 0.
    [SerializeField] private string[] levels;
    private string mainMenu = "MainMenu";

    public void loadNextLevel()
    {
        levelToLoad++;
        if(levels[levelToLoad] != null)
            LoadScene.loadScene(levels[levelToLoad]);
    }

    public void loadMainMenu()
    {
        LoadScene.loadScene(mainMenu);
    }
}
