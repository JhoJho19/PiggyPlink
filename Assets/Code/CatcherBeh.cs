using ProgreaaAndDataNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcherBeh : MonoBehaviour
{
    [SerializeField] float coefficient;
    [SerializeField] CoinsOutput CoinsOutput;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            ProgressData.GoldCoinCounter = (int)Mathf.Round(ProgressData.GoldCoinCounter * coefficient);
            Debug.Log(ProgressData.GoldCoinCounter);
            CoinsOutput.UpdateCoinCounter();
            Destroy(collision.gameObject);
        }
    }
}
