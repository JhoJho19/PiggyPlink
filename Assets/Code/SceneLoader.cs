using ProgressAndDataNamespace;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneByIndex(int sceneIndex)
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        if (sceneIndex >= 0 && sceneIndex < sceneCount)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

    public void LoadSceneForStart()
    {
        SceneManager.LoadScene(ProgressData.LevelCount);
    }
}
