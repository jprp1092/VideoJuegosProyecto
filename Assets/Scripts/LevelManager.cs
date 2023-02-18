using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private bool circularNavigation = true;

    /// <summary>
    /// Returns the current scene index.
    /// </summary>
    /// <returns>The current scene index.</returns>
    public int GetCurrentSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    /// <summary>
    /// Returns the index of the last scene in the build settings.
    /// </summary>
    /// <returns>The index of the last scene in the build settings.</returns>
    public int GetLastSceneIndex()
    {
        return SceneManager.sceneCountInBuildSettings - 1;
    }

    /// <summary>
    /// Loads the first scene in the build settings.
    /// </summary>
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Loads the last scene in the build settings.
    /// </summary>
    public void LoadLastScene()
    {
        int lastSceneIndex = GetLastSceneIndex();
        SceneManager.LoadScene(lastSceneIndex);
    }

    /// <summary>
    /// Loads the next scene in the build settings.
    /// </summary>
    public void LoadNextScene()
    {
        int currentSceneIndex = GetCurrentSceneIndex();
        int lastSceneIndex = GetLastSceneIndex();

        int nextSceneIndex = currentSceneIndex + 1;
        bool isAtLastScene = currentSceneIndex == lastSceneIndex;

        if (isAtLastScene)
        {
            if (circularNavigation)
            {
                LoadFirstScene();
            }
        }
        else
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    /// <summary>
    /// Loads the previous scene in the build settings.
    /// </summary>
    
    public void LoadPreviousScene()
    {
        int currentSceneIndex = GetCurrentSceneIndex();
        int previousSceneIndex = currentSceneIndex - 1;

        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
    }

}
