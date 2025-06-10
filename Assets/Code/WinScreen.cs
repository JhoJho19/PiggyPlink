using UnityEngine;
using ProgressAndDataNamespace;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    void Start()
    {
        int maxSceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        if (ProgressData.LevelCount == SceneManager.GetActiveScene().buildIndex &&
            ProgressData.LevelCount < maxSceneIndex)
        {
            ProgressData.LevelCount++;
        }
    }
}
