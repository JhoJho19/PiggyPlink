using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rbrb;
    private float timetime = 0f;

    void FixedUpdate()
    {
        if (rbrb.velocity.x == 0)
        {
            timetime += Time.fixedDeltaTime;
            if (timetime >= 1.0f)
            {
                int ent = Random.Range(0, 2) * 2 - 1;
                rbrb.AddForce(new Vector2(0.01f * ent, 0));
            }
        }
    }
}
