using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LoadScene
{

    public static void loadScene(string toLoad)
    {
        SceneManager.LoadSceneAsync(toLoad);
    }
}
