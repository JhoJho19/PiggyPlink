using ProgressAndDataNamespace;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadSceneForStart()
    {
        SceneManager.LoadScene(ProgressData.LevelCount);
    }
}
