using UnityEngine;
using ProgressAndDataNamespace;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public UnityEvent onFail;
    [SerializeField] private GameObject playBall;
    public static bool isBallGenerate;

    // время последнего спавна
    private float _lastSpawnTime = -Mathf.Infinity;

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
                float randomForceX = Random.Range(-0.1f, 0.1f);
                float randomForceY = Random.Range(0.5f, 1f);
                Vector2 force = new Vector2(randomForceX, randomForceY);
                rb.AddForce(force, ForceMode2D.Impulse);
            }
        }
    }

    public void SpawnBut()
    {
        if (!BonusesController.IsFasterBonus && Time.time - _lastSpawnTime < 1f)
            return;

        _lastSpawnTime = Time.time;

        float xRange = Random.Range(-0.05f, 0.05f);
        SpawnABall(xRange, -0.215f);
    }
}
