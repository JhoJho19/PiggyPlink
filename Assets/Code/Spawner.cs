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
        if (isBallGenerate)
        {
            GameObject ball = Instantiate(playBall, pos, Quaternion.identity);

            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float randomForceX = Random.Range(-01f, 2f);
                float randomForceY = Random.Range(0.5f, 1f);
                Vector2 force = new Vector2(randomForceX, randomForceY);
                rb.AddForce(force, ForceMode2D.Impulse);
            }
        }
    }

    public void SpawnBut()
    {
        float xRange = Random.Range(-0.01f, 0.01f);
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
