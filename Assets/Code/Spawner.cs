using UnityEngine;
using ProgreaaAndDataNamespace;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public UnityEvent onFail;
    [SerializeField] private GameObject playBall;
    public static bool isBallGenerate;

    private void Start()
    {
        isBallGenerate = true;
    }

    private void SpawnABall(float x, float y)
    {
        Vector2 pos = new Vector2(x, y);
        if (isBallGenerate) { Instantiate(playBall, pos, Quaternion.identity); }
    }

    public void SpawnBut()
    {
        float xRange = Random.Range(-0.1f, 0.1f);
        SpawnABall(xRange, -0.215f);
    }

    //private void FixedUpdate()
    //{
    //    if (ProgressAndSettings.GoldCoinCounter <= 0)
    //    {
    //        if (FindFirstObjectByType<BallController>() == null)
    //        {
    //            onFail.Invoke();
    //            gameObject.SetActive(false);
    //        }
    //    }
    //}
}
