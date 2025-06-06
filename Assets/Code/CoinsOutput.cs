using ProgreaaAndDataNamespace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;

    private void Start()
    {
        UpdateCoinCounter();
    }

    public void UpdateCoinCounter()
    {
        coinsText.text = ProgressAndSettings.GoldCoinCounter.ToString();
        if (ProgressAndSettings.GoldCoinCounter <= 0)
        {
            coinsText.text = "0";
        }
    }
}
