using ProgreaaAndDataNamespace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsOutput : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;

    private void Start()
    {
        UpdateCoinCounter();
    }

    public void UpdateCoinCounter()
    {
        coinsText.text = ProgressData.GoldCoinCounter.ToString();
        if (ProgressData.GoldCoinCounter <= 0)
        {
            ProgressData.GoldCoinCounter = 10;
            coinsText.text = ProgressData.GoldCoinCounter.ToString();
        }
    }
}
