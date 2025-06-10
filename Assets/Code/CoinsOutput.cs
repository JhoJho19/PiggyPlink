using ProgressAndDataNamespace;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinsOutput : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] int targetAmount;
    [SerializeField] Image progressBar;

    private void Start()
    {
        UpdateCoinCounter();
    }

    public void UpdateCoinCounter()
    {
        coinsText.text = ProgressData.GoldCoinCounter.ToString();
        
        if(progressBar)
            progressBar.fillAmount = ProgressData.GoldCoinCounter / (targetAmount * .01f);
        
        if (ProgressData.GoldCoinCounter <= 0)
        {
            ProgressData.GoldCoinCounter = 10;
            coinsText.text = ProgressData.GoldCoinCounter.ToString();
        }
    }
}
