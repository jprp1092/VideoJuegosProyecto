using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    bool CircularNavigation = true;


    /// <summary>
    /// Returns Current Scene Index.
    /// </summary>
    /// <returns> Current Scene Index </returns>
    /// 

    public void ReloadLevel()
    {
        SceneManager.LoadScene(GetCurrentScene());
    }

    public int GetCurrentScene()
    {

        return SceneManager.GetActiveScene().buildIndex;

    }


    public int GetLastScene()
    {


        return SceneManager.sceneCountInBuildSettings - 1;
    }


    /// <summary>
    /// Navigates to First Scene
    /// </summary>

    public void FirstScene()
    {

        SceneManager.LoadScene(0);

    }

    /// <summary>
    /// Navigates to Last Scene
    /// </summary>


    public void LastScene()
    {

        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);


    }

    /// <summary>
    /// Navigates to Next Scene
    /// </summary>

    public void NextScene()
    {
        // Almacena el valor del incide de la escena actual
        int currentScene = GetCurrentScene();
        // Almacena el valor del incide de la ultima escena
        int lastScene = GetLastScene();

        if (currentScene < lastScene)
        {


            SceneManager.LoadScene(currentScene + 1);


        }
        else if (CircularNavigation)
        {

            // Cargue la primera escena
            FirstScene();

        }


    }

    public void PreviousScene()
    {

        int currentScene = GetCurrentScene();

        if (currentScene > 0)
        {

            SceneManager.LoadScene(currentScene - 1);
        }

    }


}
